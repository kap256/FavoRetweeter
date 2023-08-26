
using KAPLibNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KAPLibNet.IConfig;

namespace FavoRetweeter
{
    public class FRVisibility: IEnumlikeObject<FRVisibility>
    {
        public static FRVisibility[] Values => new[] {
            Default,
            Public,
            Unlisted, 
            Private,
            Direct
        };

        public static FRVisibility Default 
            = new("デフォルト", null, null);
        public static FRVisibility Public 
            = new("公開", Mastonet.Visibility.Public, MisskeyVisiblity.@public);
        public static FRVisibility Unlisted 
            = new("未収載", Mastonet.Visibility.Unlisted, MisskeyVisiblity.home);
        public static FRVisibility Private 
            = new("フォロワーのみ", Mastonet.Visibility.Private, MisskeyVisiblity.followers);
        public static FRVisibility Direct 
            = new("自分のみ", Mastonet.Visibility.Direct, MisskeyVisiblity.specified);

        public readonly string Japanese;
        public readonly Mastonet.Visibility? Mastodon;
        public readonly MisskeyVisiblity? Misskey;

        private FRVisibility(string j, Mastonet.Visibility? mst, MisskeyVisiblity? mis)
        {
            Japanese = j;
            Mastodon = mst;
            Misskey = mis;
        }

        public FRVisibility[] GetValues()
        {
            return Values;
        }
        public static bool TryParse(string value, out FRVisibility result)
        {
            return ((IEnumlikeObject<FRVisibility>)Default).TryParse(value,out result);
        }

        public override string ToString()
        {
            return Japanese;
        }


        public static implicit operator Mastonet.Visibility?(FRVisibility e)
        {
            return e.Mastodon;
        }


    }
}
