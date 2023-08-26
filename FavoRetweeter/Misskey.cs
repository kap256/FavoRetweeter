using KAPLibNet;

using Misq.Wrapper;

namespace FavoRetweeter
{
    public enum MisskeyVisiblity
    {
        @public,    //こんな予約語めいた……
        home,
        followers,
        specified
    }


    public class Misskey : ISingletonLike<Misskey>
    {
        public static Misskey Instance => ISingletonLike<Misskey>.Instance;


        API MisskeyAPI;
        MisskeyVisiblity Visi;
        Logger Log;

        public Misskey()
        {
            Log = Logger.GetInstance();
        }
        public Misskey(Logger log)
        {
            Log = log;
        }

        public async Task Init()
        {
            await Init(Config.MisskeyInstance,
                 Config.MisskeyAccessToken,
                 Config.MisskeyVisibility.Get().Misskey ?? MisskeyVisiblity.specified);
        }
        public async Task Init(string instance, string token, MisskeyVisiblity visi)
        {
            try {
                Visi = visi;

                var me = new Misq.Me("https://" + instance, token);
                MisskeyAPI = new(me);

            } catch (Exception ex) {
                Log.Ex(ex);
                MisskeyAPI = null;
            }
        }

        public string Post(Status st)
        {
            if (MisskeyAPI == null) {
                Log.Info($"Client not found.");
                return null;
            }
#if DEBUG
            //return null;
#endif
            //画像付きツイートへの対応は、現状できませんね。


            //投稿
            var text = st.FormatedText;
            try {
                var task = MisskeyAPI.Note.Create(
                    text,
                    (st.Visi?.Misskey ?? Visi).ToString());
                task.Wait();
                Log.Info($"Created - {text}");
                return task.Result;

            } catch (Exception ex) {
                Log.Ex(ex);
                return null;
            }
        }
    }
}
