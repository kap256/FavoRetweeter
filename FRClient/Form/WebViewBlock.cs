using Mastonet.Entities;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRClient
{
    public interface WebViewBlockHandler
    {
        void OnDelete(WebViewBlock sender);
        void OnMove(WebViewBlock sender, int dir);

        void OnImageOpen(FRWebView sender);
        void OnImageClose(FRWebView sender);
    }
    public partial class WebViewBlock : UserControl
    {
        public ViewerSetting.Viewer Setting { get; private set; }
        WebViewBlockHandler Handler;

        private FRWebView webViewFirst = null;
        private FRWebView webViewSecond = null;

        public WebViewBlock(ViewerSetting.Viewer v, WebViewBlockHandler h)
        {
            InitializeComponent();

            Setting = v;
            Handler = h;

            ResetViewer();
        }

        private void ResetViewer()
        {
            this.Width = Setting.Width;

            RemoveWebView(ref webViewFirst);
            webViewFirst = CreateWebView(Setting.URI, Setting);
            webViewFirst.SourceChanged += webView_SourceChanged;
            webView_SourceChanged(webViewFirst, null);
            tableLayoutPanel.Controls.Add(webViewFirst, 0, 0);

            RemoveWebView(ref webViewSecond);
            if (Setting.IsHalf
                && (!string.IsNullOrEmpty(Setting.HalfURI))
                ) {
                tableLayoutPanel.RowStyles[0].Height = 50F;
                tableLayoutPanel.RowStyles[1].Height = 50F;
                webViewSecond = CreateWebView(Setting.HalfURI, Setting);
                tableLayoutPanel.Controls.Add(webViewSecond, 0, 1);
            } else {
                tableLayoutPanel.RowStyles[0].Height = 100F;
                tableLayoutPanel.RowStyles[1].Height = 0F;
            }
        }
        public void ReaddViewer(FRWebView webview)
        {
            if (webview == webViewSecond) {
                tableLayoutPanel.Controls.Add(webViewSecond, 0, 1);
            } else {
                tableLayoutPanel.Controls.Add(webViewFirst, 0, 0);
            }
        }
        private void RemoveWebView(ref FRWebView webview)
        {
            if (webview != null) {
                tableLayoutPanel.Controls.Remove(webview);
                webview.Dispose();
                webview = null;
            }
        }
        private FRWebView CreateWebView(string uri, ViewerSetting.Viewer setting)
        {
            var ret = new FRWebView(Handler);
            ((ISupportInitialize)ret).BeginInit();

            ret.AllowExternalDrop = true;
            ret.Dock = DockStyle.Fill;
            ret.Margin = new Padding(0);

            ret.InitByViewerSetting(uri, setting);

            ((ISupportInitialize)ret).EndInit();

            return ret;
        }

        public void ReloadTwitter()
        {
            webViewFirst?.ReloadTwitter();
            webViewSecond?.ReloadTwitter();
        }

        private void webView_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            //セカンダリのソース変更は反映しなくていい。
            //長すぎると折り返される……。不要不急なスペースなどの区切り文字は使わないようにしとこう。
            var url = $"⚙{webViewFirst?.Source.Host}{webViewFirst?.Source.AbsolutePath}";
            buttonSetting.Text = url;
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            var form = new ViewerSettingForm(Setting);
            var result = form.ShowDialog();
            switch (result) {
                case DialogResult.OK:
                    ResetViewer();
                    ViewerSetting.Save();
                    break;
                case DialogResult.Abort:
                    Handler.OnDelete(this);
                    break;
            }
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            Handler.OnMove(this, -1);
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            Handler.OnMove(this, +1);
        }

    }
}
