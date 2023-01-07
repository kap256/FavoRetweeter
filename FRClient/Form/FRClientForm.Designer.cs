namespace FRClient
{
    partial class FRClientForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label label1;
            Panel panel1;
            Panel panel2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRClientForm));
            webViewPost = new FRPostWebView();
            buttonExpand = new Button();
            buttonAdd = new Button();
            checkPostStop = new CheckBox();
            buttonConfig = new Button();
            listImages = new ListBox();
            flowLayoutPanel = new FlowLayoutPanel();
            tableLayoutPanel = new TableLayoutPanel();
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webViewPost).BeginInit();
            panel2.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(191, 430);
            label1.Name = "label1";
            label1.Size = new Size(166, 15);
            label1.TabIndex = 3;
            label1.Text = "(おそらく)アップロードする気の画像";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.BackColor = SystemColors.Control;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(webViewPost);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(420, 422);
            panel1.TabIndex = 5;
            // 
            // webViewPost
            // 
            webViewPost.AllowExternalDrop = true;
            webViewPost.BackColor = SystemColors.Control;
            webViewPost.CreationProperties = null;
            webViewPost.DefaultBackgroundColor = Color.Empty;
            webViewPost.Dock = DockStyle.Fill;
            webViewPost.ImeMode = ImeMode.NoControl;
            webViewPost.Location = new Point(0, 0);
            webViewPost.Name = "webViewPost";
            webViewPost.Size = new Size(418, 420);
            webViewPost.Source = new Uri("https://twitter.com/compose/tweet", UriKind.Absolute);
            webViewPost.TabIndex = 3;
            webViewPost.ZoomFactor = 1D;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonExpand);
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(buttonAdd);
            panel2.Controls.Add(checkPostStop);
            panel2.Controls.Add(buttonConfig);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(listImages);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(444, 595);
            panel2.TabIndex = 6;
            // 
            // buttonExpand
            // 
            buttonExpand.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            buttonExpand.FlatAppearance.BorderSize = 0;
            buttonExpand.FlatAppearance.MouseDownBackColor = Color.RoyalBlue;
            buttonExpand.FlatAppearance.MouseOverBackColor = Color.LightSkyBlue;
            buttonExpand.FlatStyle = FlatStyle.Flat;
            buttonExpand.Font = new Font("Yu Gothic UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonExpand.ForeColor = Color.DarkBlue;
            buttonExpand.Location = new Point(425, 4);
            buttonExpand.Margin = new Padding(0);
            buttonExpand.Name = "buttonExpand";
            buttonExpand.Size = new Size(19, 552);
            buttonExpand.TabIndex = 6;
            buttonExpand.Text = "<<<";
            buttonExpand.UseVisualStyleBackColor = true;
            buttonExpand.Click += buttonExpand_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonAdd.BackColor = Color.FromArgb(255, 250, 245);
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAdd.Location = new Point(409, 559);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(32, 32);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "➕";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // checkPostStop
            // 
            checkPostStop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkPostStop.Appearance = Appearance.Button;
            checkPostStop.BackColor = Color.FromArgb(255, 250, 245);
            checkPostStop.FlatAppearance.BorderColor = Color.Black;
            checkPostStop.FlatAppearance.CheckedBackColor = Color.Salmon;
            checkPostStop.FlatAppearance.MouseDownBackColor = Color.Brown;
            checkPostStop.FlatStyle = FlatStyle.Flat;
            checkPostStop.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            checkPostStop.ImageAlign = ContentAlignment.MiddleRight;
            checkPostStop.Location = new Point(4, 448);
            checkPostStop.Name = "checkPostStop";
            checkPostStop.Size = new Size(171, 32);
            checkPostStop.TabIndex = 0;
            checkPostStop.Text = "連動の一時停止";
            checkPostStop.TextAlign = ContentAlignment.MiddleCenter;
            checkPostStop.UseVisualStyleBackColor = false;
            // 
            // buttonConfig
            // 
            buttonConfig.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonConfig.BackColor = Color.FromArgb(255, 250, 245);
            buttonConfig.FlatStyle = FlatStyle.Flat;
            buttonConfig.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonConfig.Location = new Point(4, 560);
            buttonConfig.Name = "buttonConfig";
            buttonConfig.Size = new Size(171, 32);
            buttonConfig.TabIndex = 1;
            buttonConfig.Text = "設定";
            buttonConfig.UseVisualStyleBackColor = false;
            buttonConfig.Click += buttonConfig_Click;
            // 
            // listImages
            // 
            listImages.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            listImages.FormattingEnabled = true;
            listImages.ItemHeight = 15;
            listImages.Location = new Point(191, 448);
            listImages.Name = "listImages";
            listImages.Size = new Size(233, 79);
            listImages.TabIndex = 1;
            listImages.TabStop = false;
            listImages.DoubleClick += listImages_DoubleClick;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(453, 3);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(328, 595);
            flowLayoutPanel.TabIndex = 4;
            flowLayoutPanel.WrapContents = false;
            flowLayoutPanel.Resize += flowLayoutPanel_Resize;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(panel2, 0, 0);
            tableLayoutPanel.Controls.Add(flowLayoutPanel, 1, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(784, 601);
            tableLayoutPanel.TabIndex = 7;
            // 
            // FRClientForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 155, 240);
            ClientSize = new Size(784, 601);
            Controls.Add(tableLayoutPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(800, 640);
            Name = "FRClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FRClient";
            Activated += FRClientForm_Activated;
            Deactivate += FRClientForm_Deactivate;
            ResizeEnd += FRClientForm_ResizeEnd;
            DragEnter += FRClientForm_DragEnter;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webViewPost).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FRPostWebView webViewPost;
        private FlowLayoutPanel flowLayoutPanel;
        private ListBox listImages;
        private CheckBox checkPostStop;
        private Button buttonConfig;
        private Button buttonAdd;
        private TableLayoutPanel tableLayoutPanel;
        private Button buttonExpand;
    }
}