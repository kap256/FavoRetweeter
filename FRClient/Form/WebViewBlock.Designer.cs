namespace FRClient
{
    partial class WebViewBlock
    {
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            TableLayoutPanel tableLayoutPanel1;
            buttonSetting = new Button();
            buttonLeft = new Button();
            buttonRight = new Button();
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.Controls.Add(buttonSetting, 1, 0);
            tableLayoutPanel1.Controls.Add(buttonLeft, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonRight, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 375);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(400, 25);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // buttonSetting
            // 
            buttonSetting.Dock = DockStyle.Fill;
            buttonSetting.Location = new Point(25, 0);
            buttonSetting.Margin = new Padding(0);
            buttonSetting.Name = "buttonSetting";
            buttonSetting.Size = new Size(350, 25);
            buttonSetting.TabIndex = 1;
            buttonSetting.Text = "⚙";
            buttonSetting.TextAlign = ContentAlignment.MiddleLeft;
            buttonSetting.UseVisualStyleBackColor = false;
            buttonSetting.Click += buttonSetting_Click;
            // 
            // buttonLeft
            // 
            buttonLeft.Dock = DockStyle.Fill;
            buttonLeft.Location = new Point(0, 0);
            buttonLeft.Margin = new Padding(0);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(25, 25);
            buttonLeft.TabIndex = 2;
            buttonLeft.Text = "◀";
            buttonLeft.TextAlign = ContentAlignment.MiddleLeft;
            buttonLeft.UseVisualStyleBackColor = false;
            buttonLeft.Click += buttonLeft_Click;
            // 
            // buttonRight
            // 
            buttonRight.Dock = DockStyle.Fill;
            buttonRight.Location = new Point(375, 0);
            buttonRight.Margin = new Padding(0);
            buttonRight.Name = "buttonRight";
            buttonRight.Size = new Size(25, 25);
            buttonRight.TabIndex = 3;
            buttonRight.Text = "▶";
            buttonRight.TextAlign = ContentAlignment.MiddleRight;
            buttonRight.UseVisualStyleBackColor = false;
            buttonRight.Click += buttonRight_Click;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(tableLayoutPanel1, 0, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 0F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel.Size = new Size(400, 400);
            tableLayoutPanel.TabIndex = 4;
            // 
            // WebViewBlock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tableLayoutPanel);
            Margin = new Padding(0);
            Name = "WebViewBlock";
            Size = new Size(400, 400);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonSetting;
        private Button buttonLeft;
        private Button buttonRight;
        private TableLayoutPanel tableLayoutPanel;
    }
}
