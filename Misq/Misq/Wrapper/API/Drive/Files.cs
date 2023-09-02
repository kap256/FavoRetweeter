using Misq.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Misq.Wrapper
{
    public class Files
    {
        Me Me;

        internal Files(Me me)
        {
            Me = me;
        }

        /// <summary>
        /// ログイン中のユーザのドライブにファイルをアップロードします。
        /// https://misskey-hub.net/docs/api/endpoints/drive/files/create.html
        /// </summary>
        public async Task<string> Create(
            string name,
            string file_path,
            Dictionary<string, object> other_option = null)
        {
            var param = other_option ?? new();
            param.Add("name", name);

            var content = new MultipartFormDataContent();
            foreach (var p in param) {
                content.Add(new StringContent(p.Value.ToString()), p.Key);
            }

            using (var stream = File.OpenRead(file_path))
            using (var reader = new BinaryReader(stream)) {
                var data = reader.ReadBytes((int)stream.Length);
                content.Add(new ByteArrayContent(data, 0, data.Length), "file", "blob");
            }

            var result = await Me.RequestWithBinary("drive/files/create", content);
            return API.SafeGetObject<string>(result as JObject, "id");
        }
    }
}
