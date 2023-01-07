using FRClient.Properties;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System.Resources;

namespace FRClient
{
    public class FRPostWebView:FRWebView
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

        public FRPostWebView()
        {
            CSS.CSS = Resources.style_twitter_post;
        }

        protected override bool IsBlockRequest(CoreWebView2 core, CoreWebView2WebResourceRequestedEventArgs e)
        {
            var uri = State.PostUri.ToString();
            if (e.Request.Uri == uri) return false;
            if (core.Source == uri) {
                //放置しているだけで定期的に通信するようなもの以外は通す
                if (e.Request.Uri.Contains("api/2/notifications/")) return true;
                if (e.Request.Uri.Contains("api/2/badge_count/")) return true;
                return false;
            }
            //もともとのURIに絡まない者は全て通さない
            return true;
        }
        protected override async Task OnSourceChange()
        {

            if (State.PostUri != Source) {
                //遷移を拒否する
                GoBack();
                return;
            }

            await base.OnSourceChange();
        }
    }
}
