using Mastonet;
using Mastonet.Entities;
using KAPLibNet;

namespace FavoRetweeter
{
    public partial class Mastodon : ISingletonLike<Mastodon>
    {

        public static Mastodon Instance => ISingletonLike< Mastodon > .Instance;

        MastodonClient Client;
        Visibility Visi;
        Logger Log;

        public Mastodon()
        {
            Log = Logger.GetInstance();
        }
        public Mastodon(Logger log)
        {
            Log = log;
        }
        public async Task Init()
        {
            await Init(Config.MastodonInstance,
                 Config.MastodonAccessToken,
                 Config.MastodonVisibility.Get().Mastodon?? Visibility.Private);
        }
        public async Task Init(string instance, string token, Visibility visi)
        {
            try {
                Visi = visi;
                Log.Debug($"instance - {instance}");
                Log.Debug($"token - {token}");
                Client = new MastodonClient(
                    instance,
                    token);
#if DEBUG
                var account =await Client.GetCurrentUser();
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

            var text = st.FormatedText;

            //投稿
            try {
                var t_pub = Client.PublishStatus(
                    text,
                    st.Visi?.Mastodon ?? Visi,
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
