using FavoRetweeter;
using KAPLibNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KAPLibNet.IConfig;

namespace FRClient
{
    public static class ViewerSetting
    {
        public class Viewer
        {
            public string URI;
            public StrInt Width=320;

            public StrBool IsHalf=false;
            public string HalfURI;

            public string Script;
            public string Style;
            

        }

        private static ConfList<ConfClass<Viewer>, Viewer> ViewerConfig;

        public static IList<Viewer> Viewers => ViewerConfig;

        static ViewerSetting()
        {
            ViewerConfig = new(Config.Instance, "viewers");
            if (Viewers.Count == 0) {
                Viewer v;

                v = new Viewer();
                v.URI = "https://twitter.com/home";
                v.Width = 400;
                Viewers.Add(v);

#if DEBUG
                v = new Viewer();
                v.URI = "https://social.vivaldi.net/";
                v.Width = 400;
                Viewers.Add(v);


                v = new Viewer();
                v.URI = "https://twitter.com/notifications";
                v.Width = 400;
                Viewers.Add(v);

                ViewerConfig.FlushList();
#endif
            }
        }

        public static void Save()
        {
            ViewerConfig.FlushList();
        }
    }
}
