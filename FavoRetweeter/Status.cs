using Mastonet;
using KAPLibNet;
using System;

namespace FavoRetweeter
{
    public class Status
    {
        public string Text = "";
        public string RTText = "";
        public string RTURL = "";
        public List<string> Images = null;
        public FRVisibility Visi = null;

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


        public string FormatedText {
            get {
                var text = Text;

                //RTが含まれる場合
                if (!String.IsNullOrEmpty(RTText)) {
                    var rt_text = RTText.TrimEnd('…');
                    text += $"{Environment.NewLine}{Environment.NewLine}RT:";
                    text += $"{Environment.NewLine}{rt_text}";
                }
                if (!String.IsNullOrEmpty(RTURL)) {
                    text += $"{Environment.NewLine}[{RTURL}]";
                }

                //整形して返す
                return text.Replace("\\n", Environment.NewLine).Replace("\\\\", "￥").Replace("\\", "");
            }
        }

    }
}
