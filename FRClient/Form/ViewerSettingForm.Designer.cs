namespace FRClient
{
    partial class ViewerSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label label1;
            Label label2;
            Label label3;
            Label label4;
            TableLayoutPanel tableLayoutPanel1;
            Panel panel3;
            Panel panel2;
            Panel panel1;
            FlowLayoutPanel flowLayoutPanel1;
            textBoxCSS = new TextBox();
            textBoxScript = new TextBox();
            checkBoxHalf = new CheckBox();
            textBoxHalf = new TextBox();
            textBoxUrl = new TextBox();
            trackBarWidth = new TrackBar();
            numericWidth = new NumericUpDown();
            buttonComplete = new Button();
            buttonDelete = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericWidth).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 0;
            label1.Text = "URL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 38);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 1;
            label2.Text = "横幅";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 5;
            label3.Text = "カスタムスクリプト";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 6;
            label4.Text = "カスタムCSS";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(panel3, 0, 2);
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(624, 441);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBoxCSS);
            panel3.Controls.Add(label4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 263);
            panel3.Name = "panel3";
            panel3.Size = new Size(618, 144);
            panel3.TabIndex = 2;
            // 
            // textBoxCSS
            // 
            textBoxCSS.AcceptsReturn = true;
            textBoxCSS.AcceptsTab = true;
            textBoxCSS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxCSS.Location = new Point(7, 18);
            textBoxCSS.MaxLength = 0;
            textBoxCSS.Multiline = true;
            textBoxCSS.Name = "textBoxCSS";
            textBoxCSS.ScrollBars = ScrollBars.Both;
            textBoxCSS.Size = new Size(608, 123);
            textBoxCSS.TabIndex = 7;
            textBoxCSS.WordWrap = false;
            textBoxCSS.TextChanged += textBoxCSS_TextChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBoxScript);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 113);
            panel2.Name = "panel2";
            panel2.Size = new Size(618, 144);
            panel2.TabIndex = 1;
            // 
            // textBoxScript
            // 
            textBoxScript.AcceptsReturn = true;
            textBoxScript.AcceptsTab = true;
            textBoxScript.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxScript.Location = new Point(7, 18);
            textBoxScript.MaxLength = 0;
            textBoxScript.Multiline = true;
            textBoxScript.Name = "textBoxScript";
            textBoxScript.ScrollBars = ScrollBars.Both;
            textBoxScript.Size = new Size(608, 123);
            textBoxScript.TabIndex = 6;
            textBoxScript.WordWrap = false;
            textBoxScript.TextChanged += textBoxScript_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(checkBoxHalf);
            panel1.Controls.Add(textBoxHalf);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBoxUrl);
            panel1.Controls.Add(trackBarWidth);
            panel1.Controls.Add(numericWidth);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(618, 104);
            panel1.TabIndex = 0;
            // 
            // checkBoxHalf
            // 
            checkBoxHalf.AutoSize = true;
            checkBoxHalf.Location = new Point(3, 70);
            checkBoxHalf.Name = "checkBoxHalf";
            checkBoxHalf.Size = new Size(86, 19);
            checkBoxHalf.TabIndex = 7;
            checkBoxHalf.Text = "ハーフ&ハーフ";
            checkBoxHalf.UseMnemonic = false;
            checkBoxHalf.UseVisualStyleBackColor = true;
            checkBoxHalf.CheckedChanged += checkBoxHalf_CheckedChanged;
            // 
            // textBoxHalf
            // 
            textBoxHalf.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxHalf.Location = new Point(95, 68);
            textBoxHalf.Name = "textBoxHalf";
            textBoxHalf.Size = new Size(514, 23);
            textBoxHalf.TabIndex = 6;
            textBoxHalf.TextChanged += textBoxHalf_TextChanged;
            // 
            // textBoxUrl
            // 
            textBoxUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxUrl.Location = new Point(62, 7);
            textBoxUrl.Name = "textBoxUrl";
            textBoxUrl.Size = new Size(547, 23);
            textBoxUrl.TabIndex = 2;
            textBoxUrl.TextChanged += textBoxUrl_TextChanged;
            // 
            // trackBarWidth
            // 
            trackBarWidth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBarWidth.AutoSize = false;
            trackBarWidth.Location = new Point(154, 36);
            trackBarWidth.Maximum = 1000;
            trackBarWidth.Minimum = 100;
            trackBarWidth.Name = "trackBarWidth";
            trackBarWidth.Size = new Size(455, 23);
            trackBarWidth.TabIndex = 4;
            trackBarWidth.TickStyle = TickStyle.None;
            trackBarWidth.Value = 100;
            trackBarWidth.Scroll += trackBarWidth_Scroll;
            // 
            // numericWidth
            // 
            numericWidth.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numericWidth.Location = new Point(62, 36);
            numericWidth.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericWidth.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numericWidth.Name = "numericWidth";
            numericWidth.Size = new Size(83, 23);
            numericWidth.TabIndex = 3;
            numericWidth.Value = new decimal(new int[] { 100, 0, 0, 0 });
            numericWidth.ValueChanged += numericWidth_ValueChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(buttonComplete);
            flowLayoutPanel1.Controls.Add(buttonDelete);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 413);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(618, 25);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.WrapContents = false;
            // 
            // buttonComplete
            // 
            buttonComplete.DialogResult = DialogResult.OK;
            buttonComplete.Location = new Point(540, 3);
            buttonComplete.Name = "buttonComplete";
            buttonComplete.Size = new Size(75, 22);
            buttonComplete.TabIndex = 2;
            buttonComplete.Text = "完了";
            buttonComplete.UseVisualStyleBackColor = true;
            buttonComplete.Click += buttonComplete_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(459, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 22);
            buttonDelete.TabIndex = 1;
            buttonDelete.Text = "削除";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // ViewerSettingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 441);
            Controls.Add(tableLayoutPanel1);
            MinimizeBox = false;
            MinimumSize = new Size(640, 480);
            Name = "ViewerSettingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "カラムの設定";
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericWidth).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBoxUrl;
        private NumericUpDown numericWidth;
        private TrackBar trackBarWidth;
        private TextBox textBoxCSS;
        private TextBox textBoxScript;
        private Button buttonDelete;
        private Button buttonComplete;
        private CheckBox checkBoxHalf;
        private TextBox textBoxHalf;
    }
}