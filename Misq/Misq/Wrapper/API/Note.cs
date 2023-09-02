using Misq.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misq.Wrapper
{
    public class Note
    {
        Me Me;

        internal Note(Me me)
        {
            Me = me;
        }

        /// <summary>
        /// ノートを作成します。返信やRenoteもこのAPIで行います。
        /// https://misskey-hub.net/docs/api/endpoints/notes/create.html
        /// </summary>
        public async Task<string> Create(
            string text ,
            string visibility="public",
            string[] fileIds=null,
            Dictionary<string, object> other_option =null)
        {
            var param = other_option ?? new();
            param.Add("text", text);
            param.Add("visibility", visibility);
            if (fileIds != null && fileIds.Count()>0) {
                param.Add("fileIds", fileIds);
            }

            var result = await Me.Request("notes/create", param) as JObject;
            var note = API.SafeGetToken(result,"createdNote") as JObject;
            return API.SafeGetObject<string>(note, "id");
        }
    }
}
