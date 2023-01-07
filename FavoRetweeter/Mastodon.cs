using Mastonet;
using Mastonet.Entities;
using KAPLibNet;

namespace FavoRetweeter
{
    public class Mastodon : ISingletonLike<Mastodon>
    {

        public static Mastodon Instance => ISingletonLike< Mastodon > .Instance;

        MastodonClient Client;
        Visibility Visi;
        Logger Log;

        public class Status
        {
            public string Text = "";
            public string RTText = "";
            public string RTURL = "";
            public List<string> Images = null;
            public Visibility? Visi=null;

            public void ParseHanahudaFormat(string data)
            {


                var message = data.Trim('\"').Split("🎴");
                try {
                    Text = message[0];
                    RTText = message[1];
                    RTURL = message[2];
                } catch {
                    //無視する
                }
            }
            public void Log(Logger l)
            {
                l.Debug($"  text - {Text}");
                l.Debug($"  rt - {RTText}");
                l.Debug($"  rturl - {RTURL}");
            }
        }

        public Mastodon()
        {
            Log = Logger.GetInstance();
        }
        public Mastodon(Logger log)
        {
            Log = log;
        }
        public void Init()
        {
            Init(Config.MastodonInstance,
                 Config.MastodonAccessToken,
                 Config.MastodonVisibility);
        }
        public void Init(string instance, string token, Visibility visi)
        {
            try {
                Visi = visi;
                Log.Debug($"instance - {instance}");
                Log.Debug($"token - {token}");
                Client = new MastodonClient(
                    instance,
                    token);
#if DEBUG
                var task = Client.GetCurrentUser();
                task.Wait();
                var account = task.Result;
                Log.Debug($"account - {account.DisplayName}");
#endif
            } catch (Exception ex) {
                Log.Ex(ex);
                Client = null;
            }
        }


        public string Post(Status st)
        {
            if (Client == null) {
                Log.Info($"Client not found.");
                return null;
            }
#if DEBUG
            //return null;
#endif
            //画像付きツイートへの対応
            var mids = new List<string>();
            if (st.Images != null) {
                foreach (var image in st.Images) {
                    try {
                        using (var stream = File.OpenRead(image)) {
                            var t_media = Client.UploadMedia(stream);
                            t_media.Wait();
                            mids.Add(t_media.Result.Id);
                        }
                    } catch (Exception ex) {
                        Log.Ex(ex);
                        return null;
                    }
                }
            }

            var text = st.Text;

            //RTが含まれる場合
            if (!String.IsNullOrEmpty(st.RTText)) {
                var rt_text = st.RTText.TrimEnd('…');
                text += $"{Environment.NewLine}{Environment.NewLine}RT:";
                text += $"{Environment.NewLine}{rt_text}";
                text += $"{Environment.NewLine}[{st.RTURL}]";
            }

            //整形
            text = text.Replace("\\n", Environment.NewLine).Replace("\\\\", "￥").Replace("\\", "");

            //投稿
            try {
                var t_pub = Client.PublishStatus(
                    text,
                    st.Visi ?? Visi,
                    null,
                    mids);
                t_pub.Wait();
                Log.Info($"Published - {text}");
                return t_pub.Result.Id;

            } catch (Exception ex) {
                Log.Ex(ex);
                return null;
            }
        }


    }
}
