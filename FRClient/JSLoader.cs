
using Microsoft.Web.WebView2.WinForms;
using FRClient.Properties;
using KAPLibNet;
using Microsoft.VisualBasic.Logging;

namespace FRClient
{
    public abstract class IJSLoader
    {
        static Logger Log = Logger.GetInstance();
        private string Script = null;
        private string InitScript = null;
        private long DocumentCode = -1;

        public virtual string LoadScript()=>"";
        public virtual string LoadInit()=>"";

        private static string LogStr(FRWebView webv,string script)
        {
            script = script.Replace(Environment.NewLine, " ");
            if (script.Length > 128) {
                script = script.Substring(0, 128) + " ...";
            }
            return $"{script} @ {webv.Source}";
        }

        public async Task ExecScript(FRWebView webv, Action<string> act = null)
        {
            var doc_code = webv.DocumentCode;
            if (doc_code != DocumentCode) {
                if (InitScript == null) {
                    InitScript = LoadInit();
                }
                Log.Debug($"exec_init:{LogStr(webv, InitScript)} ");
                DocumentCode = doc_code;
                var init = ExecScript(webv, InitScript);
                await init.ContinueWith(ExecBody);
            } else {
                await ExecBody(null);
            }

            async Task ExecBody(Task t)
            {
                if (Script == null) {
                    Script = LoadScript();
                }
                Log.Debug($"exec_script:{LogStr(webv, Script)} ");
                await ExecScript(webv, Script, act);
            }
        }
        protected async Task ExecScript(FRWebView webv,string script, Action<string> act = null)
        {
            if (String.IsNullOrEmpty(script))   return;

            while (webv.IsNavigating) {
                Log.Debug($"exec waiting... :{LogStr(webv, script)}");
                await Task.Delay(10);
            }

            var core = webv.CoreWebView2;
            if (core == null) return;
            var result = core.ExecuteScriptAsync(script);
            _=result.ContinueWith((task) =>
            {
                Log.Debug($"exec complete :{LogStr(webv, script)}");
                if (act != null) {
                    act(task.Result.Trim('"'));
                }
            });
            await result;
        }
        protected void ResetScript()
        {
            InitScript = null;
            Script = null;
        }
    }

    public class CommonJSLoader : IJSLoader
    {
        string _Script = "";
        public string Script {
            get { return _Script; }
            set {
                _Script = value ?? "";
                ResetScript();
            }
        }
        string _Init = "";
        public string Init {
            get { return _Init; }
            set {
                _Init = value ?? "";
                ResetScript();
            }
        }

        public CommonJSLoader()
        {
        }
        public override string LoadInit()
        {
            return Init;
        }
        public override string LoadScript()
        {
            return Script;
        }
    }

    public class FRJSLoader : IJSLoader
    {
        public override string LoadInit()
        {
            return $"{Resources.fr_net} {Resources.fr_common}";
        }
    }

    public class CSSLoader : IJSLoader
    {
        string _CSS="";
        public string CSS {
            get { return _CSS; }
            set {
                _CSS = value;
                ResetScript();
            }
        }

        public override string LoadInit()
        {
            return Resources.css_init;
        }
        public override string LoadScript()
        {
            return Resources.css_reload.Replace("__css_string__", CSS);
        }
    }

    public class ReloadTweetLoader : IJSLoader
    {
        private int _FocusInterval = 60*3;
        public int FocusInterval {
            get { return _FocusInterval; }
            set {
                _FocusInterval = value;
                ResetScript();
            }
        }

        public override string LoadInit()
        {
            var script = Resources.tweet_reloader;
            script = script.Replace("__focus_interval__", FocusInterval.ToString());
            return script;
        }
        public override string LoadScript()
        {
            return "FRWEBVIEW_RELOAD_TWITTER();";
        }
    }
}
