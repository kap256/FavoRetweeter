
using KAPLibNet;
using System.Text;

namespace FavoRetweeter
{
    internal class Program
    {
        Logger Log= Logger.GetInstance();

        static void Main(string[] args)
        {
            var pg = new Program();

            var work = pg.Work(args);
            work.Wait();
        }
        async Task Work(string[] args)
        {

            //Log.Lv = ILogger.Level.TRACE;

            Log.Info($"--- {DateTime.Now} @ {Environment.CurrentDirectory}---");
            Log.Info($"start{StrsToStr(args)}");

            Console.InputEncoding = Encoding.UTF8;


            using (var stdin = new BinaryReader(Console.OpenStandardInput())) {

                char[] buf = new char[4];
                var size_byte = stdin.ReadBytes(4);
                int size = size_byte[0] + size_byte[1] * 256 + size_byte[2] * 256 * 256;//1MBまでしか送れないので、3バイトまで(<16MB)読めば十分説。
                Log.Debug($"data size - {size}");

                var data_byte = stdin.ReadBytes(size);
                var data = Encoding.UTF8.GetString(data_byte);
                Log.Debug($"data - {data}");

                var st = new Status();
                st.ParseHanahudaFormat(data);
                st.Log(Log);

                var result = new List<Record>();
                if (Config.IsSendMastodon) {
                    var mastodon = Mastodon.Instance;
                    await mastodon.Init();
                    result.Add(mastodon.Post(st));
                }
                if (Config.IsSendMisskey) {
                    var misskey = Misskey.Instance;
                    await misskey.Init();
                    result.Add(misskey.Post(st));
                }
                Records.SaveAppend(result);
            }
        }
        string StrsToStr(string[] strs)
        {
            var builder = new StringBuilder();
            foreach (var str in strs) {
                builder.Append(" - ");
                builder.Append(str);
            }
            return builder.ToString();
        }

    }
}