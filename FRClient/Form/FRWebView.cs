using FavoRetweeter;
using FRClient.Properties;
using KAPLibNet;
using Mastonet.Entities;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System.Diagnostics;
using System.Text;
using static System.Windows.Forms.Design.AxImporter;

namespace FRClient
{
    public class FRWebView : WebView2
    {
        #region コンポーネント デザイナーで生成されたコード
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion

        private static CoreWebView2Environment Env;

        protected Logger Log = Logger.GetInstance();
        public WebViewBlockHandler Handler { protected get; set; }

        protected FRJSLoader FRJS = new();
        protected ReloadTweetLoader ReloadJS = new();
        protected CSSLoader CSS = new();
        protected CommonJSLoader CommonJS = new();

        //CoreWebView2Controller Controller;
        DateTime LastReload = DateTime.MinValue;
        TimeSpan ReloadMinInterval = new(0, 1, 0);

        public long DocumentCode { get; private set; } = 0;
        public bool IsNavigating = false;

        bool IsImage = false;

        static FRWebView()
        {
            var task = CoreWebView2Environment.CreateAsync();
            task.Wait();
            Env = task.Result;
        }
        public FRWebView(WebViewBlockHandler h=null,string profile = "")
            :base()
        {

            ReloadJS.FocusInterval = Config.TwitterFocusInterval;
            Handler = h;

            InitializeComponent();

            CoreWebView2InitializationCompleted += frWebView_CoreWebView2InitializationCompleted;
            WebMessageReceived += frWebView_WebMessageReceived;
            SourceChanged += frWebView_SourceChanged;
            NavigationStarting += frWebView_NavigationStarting;
            NavigationCompleted += frWebView_NavigationCompleted;

            var prop = new CoreWebView2CreationProperties();
            prop.ProfileName = profile;
            this.CreationProperties = prop;

            /*
            if (!DesignMode) {
                //ソースの指定などをすると自動でEnsureされてしまうので、できる限り早く、早く。
                //早すぎてデザイナーモードでも表示されてしまう、どうする、どうする。
                var options = Env.CreateCoreWebView2ControllerOptions();
                options.ProfileName = "not_default";
                _ = this.EnsureCoreWebView2Async(Env, options);
            }
            */
        }
        public void InitByViewerSetting(string uri, ViewerSetting.Viewer setting)
        {
            this.Name = $"webView_{uri}";
            this.Source = new Uri(uri);

            var css_builder = new StringBuilder();
            if (IsTwitter()) {
                css_builder.AppendLine(Resources.style_twitter_common);
            }
            css_builder.AppendLine(setting.Style);

            CommonJS.Init = setting.Script;
            CSS.CSS = css_builder.ToString();
        }
        private void frWebView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            var webv = ((FRWebView)sender);
            webv.ZoomFactor = Config.WebviewZoomDefault / 100.0;

            var core = webv.CoreWebView2;

            core.AddWebResourceRequestedFilter("*", CoreWebView2WebResourceContext.All);
            core.WebResourceRequested += coreWebView2_WebResourceRequested;
            core.NewWindowRequested += coreWebView2_NewWindowRequested;

            /*使うかどうか分からんが……
            var bp = new BreakPrivate<WebView2>(webv);
            var ctrl = bp.FieldGet("_coreWebView2Controller") as CoreWebView2Controller;
            if (ctrl != null) {
                Controller = ctrl;
            }
            */

            if (webv.IsTwitterHome()) {
                webv.Focus();
            }
        }

        protected virtual bool IsBlockRequest(CoreWebView2 core, CoreWebView2WebResourceRequestedEventArgs e)
        {
            return false;
        }
        protected bool IsTwitter()
        {
            if (Source.Host != "twitter.com") return false;
            return true;
        }
        protected bool IsTwitterHome()
        {
            if (!IsTwitter()) return false;
            if (!Source.AbsoluteUri.EndsWith("home")) return false;
            return true;
        }
        protected bool IsTwitterImage()
        {
            if (!IsTwitter()) return false;
            if (!Source.AbsoluteUri.Contains("/photo/")) return false;
            return true;
        }

        public void ReloadTwitter()
        {
            if (!IsTwitterHome()) return;
            var interval = DateTime.Now - LastReload;
            if (interval < ReloadMinInterval) return;

            _=ReloadJS.ExecScript(this, (result) =>
            {
                if (result != "false") {
                    Log.Debug($"Reload success.");
                    LastReload = DateTime.Now;
                }
            });
        }

        #region イベント------------------------------------



        protected virtual async Task OnSourceChange()
        {
            if (IsTwitter()) {
                await FRJS.ExecScript(this);
                if (IsTwitterHome()) {
                    await ReloadJS.ExecScript(this);
                }
            }

            await CSS.ExecScript(this);
            await CommonJS.ExecScript(this);
        }


        private void coreWebView2_WebResourceRequested(object sender, CoreWebView2WebResourceRequestedEventArgs e)
        {
            //POSTしてからSourceChangedまでに何も通信が無いので、ここでブロックすることも出来なかった……(多少通信量は減るか？)
            var core = ((CoreWebView2)sender);
            Log.Trace($"{core.Source} {e.Request.Method} - {e.Request.Uri}");

            if (IsBlockRequest(core, e)) {

                Log.Debug($"Block : {core.Source} {e.Request.Method} - {e.Request.Uri}");
                e.Response = core.Environment.CreateWebResourceResponse(
                    null, 404, "not found", "Content-Type: text/html");
            }
        }

        private void coreWebView2_NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            //新しいウィンドウを開かなくする
            e.Handled = true;

            //外部ブラウザに投げる
            var info = new ProcessStartInfo(e.Uri);
            info.UseShellExecute = true;
            Process.Start(info);
        }

        private void frWebView_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            IsNavigating = true;
            Log.Debug($"navi start. {e.Uri}");
        }
        private void frWebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            Log.Debug($"navi complete. ");
            UpdateDocumentCode();
            IsNavigating = false;

            _=OnSourceChange();
        }
        private void frWebView_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            //ナビゲートする前にキャンセルするより反応が鈍くなるが、仕方あるまい……。
            Log.Debug($"source changed. {Source}");
            if (e.IsNewDocument) {
                UpdateDocumentCode();
            }
            var is_image = IsTwitterImage();
            if (IsImage != is_image) {
                if (is_image) {
                    Handler?.OnImageOpen(this);
                } else {
                    Handler?.OnImageClose(this);
                }
            }
            IsImage = is_image;

            _ =OnSourceChange();
        }
     
        private void UpdateDocumentCode()
        {
            DocumentCode = Source.GetHashCode() + (DateTime.Now.Ticks << 32);
            Log.Debug($"NewDocument :{DocumentCode}");
        }

        private void frWebView_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            var data = e.TryGetWebMessageAsString();

            var code = data.Substring(0, 2);
            data = data.Substring(2);
            switch (code) {
                case "MS":
                    Handler?.OnPost(this, data);
                    break;
                case "LG":
                    Log.Info($"Browser < {data}");
                    break;
                case "SK":
                    Log.Info($"skip:{data}");
                    Handler?.OnPost(this, null);
                    break;
                default:
                    Log.Info($"Unkwon Message!  - {code}:{data}");
                    break;

            }
        }

        #endregion

    }
}
