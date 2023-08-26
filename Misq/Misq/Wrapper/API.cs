using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace Misq.Wrapper
{
    public class API
    {
        Me Me;

        public readonly Note Note;

        public API(Me me)
        {
            Me = me;

            Note = new(Me);
        }

        public async Task<DateTimeOffset> Ping()
        {
            var result = await Me.Request("ping") as JObject;
            var value = SafeGetValue<long>(result, "pong");


            if (value == null) return DateTime.MinValue;
            return DateTimeOffset.FromUnixTimeMilliseconds(value ?? 0).ToLocalTime();
        }



        public static JToken SafeGetToken(JObject obj, string key)
        {
            if (obj == null) return null;
            JToken token;
            if (!obj.TryGetValue(key, out token)) {
                return null;
            }
            return token;
        }
        public static T? SafeGetValue<T>(JObject obj, string key) where T : struct
        {
            var jval = SafeGetToken(obj, key) as JValue;
            if (jval == null) return null;
            var val = jval.Value;
            if (val is T) return (T)val;
            return null;
        }
        public static T SafeGetObject<T>(JObject obj, string key) where T : class
        {
            var jval = SafeGetToken(obj, key) as JValue;
            if (jval == null) return null;
            var val = jval.Value;
            if (val is T) return (T)val;
            return null;
        }
    }

}
