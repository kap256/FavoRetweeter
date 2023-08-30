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
            //画像付きツイートへの対応
            var mids = new List<string>();
            if (st.Images != null) {
                for(int i=0;i< st.Images.Count;i++){
                    var image = st.Images[i];
                    try {
                        var task = MisskeyAPI.Drive.Files.Create(
                            $"{DateTime.Now.ToString("yyyyMMdd_hhmmss")}_{i}{Path.GetExtension(image)}",
                            image);
                        task.Wait();
                        mids.Add(task.Result);
                    } catch (Exception ex) {
                        Log.Ex(ex);
                        return null;
                    }
                }
            }


            //投稿
            var text = st.FormatedText;
            try {
                var task = MisskeyAPI.Note.Create(
                    text,
                    (st.Visi?.Misskey ?? Visi).ToString(),
                    mids.ToArray());
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
