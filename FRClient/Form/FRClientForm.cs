using FavoRetweeter;
using KAPLibNet;
using Mastonet;
using System;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace FRClient
{
    public partial class FRClientForm : Form, WebViewBlockHandler
    {
        Logger Log = Logger.GetInstance();

        public ListBox.ObjectCollection Images => listImages.Items;
        public bool IsPostStop => checkPostStop.Checked;
        public FRVisibility Visibility {
            get {
                FRVisibility ret;

                if (!FRVisibility.TryParse(comboBoxVisble.SelectedItem.ToString(), out ret)) {
                    return FRVisibility.Default;
                }
                return ret;
            }
        }

        public readonly Uri PostUri;
        private readonly float ExpandWidth;
        private float ExpandGoal;
        private float ExpandSpeed = SPEED.FAST;

        private Timer ReloadTimer = new();
        private Timer ExpandTimer = new();
        private Timer AnimeTimer = new();

        private WebViewBlock OldImageParent = null;

        static class SPEED
        {
            public const float FAST = 48;
            public const float SLOW = 4;
        }

        public FRClientForm()
        {
            _=InitAPIs();
            InitializeComponent();
#if DEBUG
            this.Text = $"{this.Text}-Debug";
#endif
            ExpandWidth = tableLayoutPanel.ColumnStyles[0].Width;
            ExpandGoal = ExpandWidth;
            webViewPost.PostUri = webViewPost.Source;
            webViewPost.Handler = this;

            Log.Info($"====== Start @ {DateTime.Now} ======");

            this.Size = Config.ClientSize;
            this.Location = Config.ClientPos;


            comboBoxVisble.Items.AddRange(FRVisibility.Values);
            comboBoxVisble.SelectedIndex = 0;

            InitTimers();

            ResetViewers();
        }

        private async Task InitAPIs()
        {
            var mastodon = Mastodon.Instance.Init();
            var misskey = Misskey.Instance.Init();

            await Task.WhenAll(mastodon, misskey);
        }

        private void InitTimers()
        {
            ReloadTimer.Tick += ReloadTimer_Tick;
            ReloadTimer.Interval = 1000;
            ReloadTimer.Start();

            ExpandTimer.Tick += ExpandTimer_Tick;
            ExpandTimer.Interval = 30 * 1000;

            AnimeTimer.Tick += AnimeTimer_Tick;
            AnimeTimer.Interval = 10;
        }


        #region listImages-------------------------------------
        private void FRClientForm_DragEnter(object sender, DragEventArgs e)
        {
            //このフォームにドラッグ&ドロップされてきた画像ファイルは、
            //おそらくツイートに添付されるだろう事を予期する。
            string[] files = (string[])e.Data.GetData("FileNameW");
            if (files == null) return;

            foreach (var file in files) {
                var info = new FileInfo(file);
                switch (info.Extension.ToLower()) {
                    case ".png":
                    case ".jpg":
                    case ".jpeg":
                    case ".gif":
                    case ".bmp":
                    case ".jfif":
                        //なんか雑だわ
                        break;
                    default:
                        continue;
                }

                IsExpand = true;
                if (!listImages.Items.Contains(file)) {
                    listImages.Items.Add(file);
                }
            }
        }

        private void listImages_DoubleClick(object sender, EventArgs e)
        {
            var list = (ListBox)sender;
            list.Items.Remove(list.SelectedItem);
        }

        #endregion
        #region flowLayout-------------------------------------

        private void ClearViewers()
        {
            foreach (Control c in flowLayoutPanel.Controls) {
                c.Dispose();
            }
            flowLayoutPanel.Controls.Clear();

        }
        private void ResetViewers()
        {
            ClearViewers();

            foreach (var v in ViewerSetting.Viewers) {
                var view_block = new WebViewBlock(v, this);
                flowLayoutPanel.Controls.Add(view_block);
            }
        }

        private void flowLayoutPanel_Resize(object sender, EventArgs e)
        {
            // TODO:（とくに急激に）縮んだときに、パネルの下の方のサイズが再反映されず、スクロールバーが出てしまう。
            var panel = (FlowLayoutPanel)sender;
            var s = panel.Size;
            foreach (Control child in panel.Controls) {
                child.Height = panel.ClientSize.Height - 1;
            }
        }

        private void ReloadTwitter()
        {
            if (this.WindowState == FormWindowState.Minimized) {
                return; //最小化している時に使ってやるAPIはねぇ！
            }
            foreach (var c in flowLayoutPanel.Controls) {
                var view_block = c as WebViewBlock;
                view_block?.ReloadTwitter();
            }
        }
        private void ReloadTimer_Tick(object sender, EventArgs e)
        {
            Log.Debug(this);
            var min_interval = Config.TwitterActiveReloadInterval * 1000;
            if (ReloadTimer.Interval < min_interval) {
                ReloadTimer.Stop();
                ReloadTimer.Interval = min_interval;
                ReloadTimer.Start();
            }
            ReloadTwitter();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new ViewerSettingForm(null);
            var result = form.ShowDialog();
            if (result == DialogResult.OK) {
                var v = form.Setting;
                ViewerSetting.Viewers.Add(v);
                var view_block = new WebViewBlock(v, this);
                flowLayoutPanel.Controls.Add(view_block);
                view_block.Height = flowLayoutPanel.ClientSize.Height - 1;
            }
            ViewerSetting.Save();
        }
        public void OnDelete(WebViewBlock sender)
        {
            var setting = sender.Setting;
            ViewerSetting.Viewers.Remove(setting);
            flowLayoutPanel.Controls.Remove(sender);
            sender.Dispose();
            ViewerSetting.Save();
        }

        public void OnMove(WebViewBlock sender, int dir)
        {
            var setting = sender.Setting;
            var index = ViewerSetting.Viewers.IndexOf(setting);
            if (index + dir < 0 || index + dir >= ViewerSetting.Viewers.Count) {
                return;
            }
            ViewerSetting.Viewers.RemoveAt(index);
            ViewerSetting.Viewers.Insert(index + dir, setting);

            flowLayoutPanel.Controls.SetChildIndex(sender, index + dir);
            ViewerSetting.Save();
        }

        #endregion
        #region ポスト処理-------------------------------------


        public void OnPost(FRWebView sender, string data)
        {
            try {
                if (string.IsNullOrEmpty(data)) {
                    return;
                }

                //連動中かどうか？
                if (IsPostStop) {
                    Log.Info($"PostStop...");
                    return;
                }

                //画像はあるかな？
                var images = new List<string>(Images.Count);
                foreach (var image in Images) {
                    images.Add(image.ToString());
                }

                //表示範囲はfinaly前に確保しておく。
                var visi = Visibility;

                //APIを叩く処理は別スレで。
                Task.Run(() =>
                {
                    RepostTweet(data, images, visi);
                });

            } finally {
                Images.Clear();
                comboBoxVisble.SelectedIndex = 0;
            }
        }

        private void RepostTweet(string data, List<string> images, FRVisibility visi)
        {
            var st = new Status();
            st.ParseHanahudaFormat(data);
            st.Images = images;
            st.Visi = visi;
            st.Log(Log);

            if (Config.IsSendMastodon) {
                var mastodon = Mastodon.Instance;
                mastodon.Post(st);
            }

            if (Config.IsSendMisskey) {
                var misskey = Misskey.Instance;
                misskey.Post(st);
            }

        }
        #endregion
        #region その他-------------------------------------

        private void FRClientForm_Activated(object sender, EventArgs e)
        {
            Log.Debug(this);
            ReloadTimer.Stop();
            ExpandTimer.Stop();
            ReloadTwitter();
            ReloadTimer.Interval = 2 * 1000;
            ReloadTimer.Start();
        }
        private void FRClientForm_Deactivate(object sender, EventArgs e)
        {
            Log.Debug(this);
            ReloadTimer.Interval = Config.TwitterDeactiveReloadInterval * 1000;
            if (Config.IsCloseDeactive) {
                ExpandTimer.Start();
            }
        }

        private void ExpandTimer_Tick(object sender, EventArgs e)
        {
            ExpandTimer.Stop();
            IsExpand = false;
            ExpandSpeed = SPEED.SLOW;
        }
        private void buttonConfig_Click(object sender, EventArgs e)
        {
            var form = new GrobalSettingForm();
            form.ShowDialog();

            _ = InitAPIs();
        }

        private void FRClientForm_ResizeEnd(object sender, EventArgs e)
        {
            Config.ClientSize.Set(this.Size);
            Config.ClientPos.Set(this.Location);
        }

        bool IsExpand {
            get {
                return (ExpandGoal >= ExpandWidth - 10);
            }
            set {
                ExpandGoal = (value ? ExpandWidth : 50);
                buttonExpand.Text = (value ? "<<<" : ">>>");
                if (value) {
                    webViewPost.Focus();
                    ExpandSpeed = SPEED.FAST;
                }
                AnimeTimer.Start();
            }

        }

        private void buttonExpand_Click(object sender, EventArgs e)
        {
            SwitchExpand();
        }

        private void SwitchExpand()
        {
            IsExpand = !IsExpand;
            ExpandSpeed = SPEED.FAST;
        }

        private void AnimeTimer_Tick(object sender, EventArgs e)
        {
            float diff = ExpandGoal - tableLayoutPanel.ColumnStyles[0].Width;
            if (MathF.Abs(diff) < ExpandSpeed) {
                tableLayoutPanel.ColumnStyles[0].Width = ExpandGoal;
                AnimeTimer.Stop();
                return;
            }
            if (diff < 0) {
                tableLayoutPanel.ColumnStyles[0].Width -= ExpandSpeed;
            } else {
                tableLayoutPanel.ColumnStyles[0].Width += ExpandSpeed;
            }

        }

        public void OnImageOpen(FRWebView sender)
        {
            Log.Debug(this);

            Control parent = sender.Parent;
            while (parent != null) {
                OldImageParent = parent as WebViewBlock;
                if (OldImageParent != null) break;
                parent = parent.Parent;
            }
            if (OldImageParent == null) return;
            sender.Parent.Controls.Remove(sender);
            this.Controls.Add(sender);
            sender.BringToFront();
        }

        public void OnImageClose(FRWebView sender)
        {
            Log.Debug(this);
            if (OldImageParent == null) return;
            this.Controls.Remove(sender);
            OldImageParent.ReaddViewer(sender);
        }

        #endregion
    }
}