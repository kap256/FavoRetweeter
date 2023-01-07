using FavoRetweeter;
using Mastonet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRClient
{
    internal static class State
    {
        static FRClientForm Client;

        public static void SetClient(FRClientForm client)
        {
            Client = client;
        }

        public static Uri PostUri => Client.PostUri;
        public static ListBox.ObjectCollection Images => Client.Images;
        public static bool IsPostStop => Client.IsPostStop;
        public static Visibility? Visi => Config.MastodonVisibility;
    }
}
