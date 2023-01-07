using KAPLibNet;
using Mastonet;
using static KAPLibNet.IConfig;

namespace FavoRetweeter
{
    public class Config : ConfigBase, ISingletonLike<Config>
    {
        public static Config Instance => ISingletonLike<Config>.Instance;

        public static ConfBool IsSendMastodon;
        public static ConfStr MastodonInstance;
        public static ConfStr MastodonAccessToken;
        public static ConfEnum<Visibility> MastodonVisibility;

        public static ConfPoint ClientPos;
        public static ConfPoint ClientSize;
        public static ConfInt WebviewZoomDefault;
        public static ConfInt TwitterFocusInterval;
        public static ConfInt TwitterActiveReloadInterval;
        public static ConfInt TwitterDeactiveReloadInterval;


        public Config() : base("FavoRetweeter.conf")
        {
        }
        static Config()
        {
            var ins = Instance;
            IsSendMastodon = new(ins, "send_mastodon",true);
            MastodonInstance = new(ins, "mastodon_instance", "mstdn.jp/");
            MastodonAccessToken = new(ins, "mastodon_access_token", "");
            MastodonVisibility = new(ins, "mastodon_visibility", Visibility.Public);

            ClientPos = new(ins, "client_pos", 0, 0);
            ClientSize = new(ins, "client_size", 0, 0);
            WebviewZoomDefault = new(ins, "webview_zoom_default", 100, 10, 1000);
            TwitterFocusInterval = new(ins, "twitter_focus_interval", 15);
            TwitterActiveReloadInterval = new(ins, "twitter_active_reload_interval", 60,60);
            TwitterDeactiveReloadInterval = new(ins, "twitter_deactive_reload_interval", 60*10,60);
        }
    }
}
