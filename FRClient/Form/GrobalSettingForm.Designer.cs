namespace FRClient
{
    partial class GrobalSettingForm
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
            GroupBox groupBox1;
            Label label9;
            Label label2;
            Label label1;
            GroupBox groupBox2;
            GroupBox groupBox3;
            Label label5;
            Label label7;
            Label label6;
            Label label4;
            Label label3;
            Label label8;
            GroupBox groupBox4;
            Label label10;
            Label label11;
            Label label12;
            comboBoxMSVisible = new ComboBox();
            textBoxMSToken = new TextBox();
            textBoxMSInstance = new TextBox();
            checkBoxSendMastodon = new CheckBox();
            checkBoxCloseDeactive = new CheckBox();
            numericDeactiveReload = new NumericUpDown();
            numericActiveReload = new NumericUpDown();
            numericFocus = new NumericUpDown();
            numericZoom = new NumericUpDown();
            comboBoxMKVisible = new ComboBox();
            textBoxMKToken = new TextBox();
            textBoxMKInstance = new TextBox();
            checkBoxSendMisskey = new CheckBox();
            buttonExit = new Button();
            groupBox1 = new GroupBox();
            label9 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            label5 = new Label();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label8 = new Label();
            groupBox4 = new GroupBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericDeactiveReload).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericActiveReload).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericFocus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericZoom).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(comboBoxMSVisible);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxMSToken);
            groupBox1.Controls.Add(textBoxMSInstance);
            groupBox1.Controls.Add(checkBoxSendMastodon);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(589, 113);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 83);
            label9.Name = "label9";
            label9.Size = new Size(108, 15);
            label9.TabIndex = 8;
            label9.Text = "デフォルトの表示範囲";
            // 
            // comboBoxMSVisible
            // 
            comboBoxMSVisible.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMSVisible.FormattingEnabled = true;
            comboBoxMSVisible.Location = new Point(120, 80);
            comboBoxMSVisible.Name = "comboBoxMSVisible";
            comboBoxMSVisible.Size = new Size(138, 23);
            comboBoxMSVisible.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 54);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 4;
            label2.Text = "アクセストークン";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 1;
            label1.Text = "インスタンスURL";
            // 
            // textBoxMSToken
            // 
            textBoxMSToken.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMSToken.Location = new Point(94, 51);
            textBoxMSToken.Name = "textBoxMSToken";
            textBoxMSToken.Size = new Size(489, 23);
            textBoxMSToken.TabIndex = 3;
            // 
            // textBoxMSInstance
            // 
            textBoxMSInstance.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMSInstance.Location = new Point(94, 22);
            textBoxMSInstance.Name = "textBoxMSInstance";
            textBoxMSInstance.Size = new Size(489, 23);
            textBoxMSInstance.TabIndex = 2;
            // 
            // checkBoxSendMastodon
            // 
            checkBoxSendMastodon.AutoSize = true;
            checkBoxSendMastodon.Location = new Point(6, 0);
            checkBoxSendMastodon.Name = "checkBoxSendMastodon";
            checkBoxSendMastodon.Size = new Size(153, 19);
            checkBoxSendMastodon.TabIndex = 1;
            checkBoxSendMastodon.Text = "Mastodonへの連動を行う";
            checkBoxSendMastodon.UseVisualStyleBackColor = true;
            checkBoxSendMastodon.CheckedChanged += checkBoxSendMastodon_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(checkBoxCloseDeactive);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(numericZoom);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(12, 250);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(589, 183);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "表示";
            // 
            // checkBoxCloseDeactive
            // 
            checkBoxCloseDeactive.AutoSize = true;
            checkBoxCloseDeactive.Location = new Point(19, 22);
            checkBoxCloseDeactive.Name = "checkBoxCloseDeactive";
            checkBoxCloseDeactive.Size = new Size(164, 19);
            checkBoxCloseDeactive.TabIndex = 7;
            checkBoxCloseDeactive.Text = "放置したときにポスト部を畳む";
            checkBoxCloseDeactive.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(numericDeactiveReload);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(numericActiveReload);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(numericFocus);
            groupBox3.Controls.Add(label6);
            groupBox3.Location = new Point(6, 86);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(577, 88);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "更新頻度(s)";
            // 
            // numericDeactiveReload
            // 
            numericDeactiveReload.Location = new Point(316, 51);
            numericDeactiveReload.Name = "numericDeactiveReload";
            numericDeactiveReload.Size = new Size(77, 23);
            numericDeactiveReload.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(200, 53);
            label5.Name = "label5";
            label5.Size = new Size(110, 15);
            label5.TabIndex = 7;
            label5.Text = "取得（非アクティブ）";
            // 
            // numericActiveReload
            // 
            numericActiveReload.Location = new Point(117, 51);
            numericActiveReload.Name = "numericActiveReload";
            numericActiveReload.Size = new Size(77, 23);
            numericActiveReload.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 53);
            label7.Name = "label7";
            label7.Size = new Size(98, 15);
            label7.TabIndex = 5;
            label7.Text = "取得（アクティブ）";
            // 
            // numericFocus
            // 
            numericFocus.Location = new Point(117, 22);
            numericFocus.Name = "numericFocus";
            numericFocus.Size = new Size(77, 23);
            numericFocus.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 24);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 2;
            label6.Text = "検出";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(189, 60);
            label4.Name = "label4";
            label4.Size = new Size(17, 15);
            label4.TabIndex = 4;
            label4.Text = "%";
            // 
            // numericZoom
            // 
            numericZoom.Location = new Point(106, 58);
            numericZoom.Name = "numericZoom";
            numericZoom.Size = new Size(77, 23);
            numericZoom.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 60);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 2;
            label3.Text = "標準ズーム倍率";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(318, 459);
            label8.Name = "label8";
            label8.Size = new Size(196, 15);
            label8.TabIndex = 6;
            label8.Text = "※一部項目は再起動時に反映されます";
            label8.TextAlign = ContentAlignment.TopRight;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(label10);
            groupBox4.Controls.Add(comboBoxMKVisible);
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(textBoxMKToken);
            groupBox4.Controls.Add(textBoxMKInstance);
            groupBox4.Controls.Add(checkBoxSendMisskey);
            groupBox4.Location = new Point(12, 131);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(589, 113);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 83);
            label10.Name = "label10";
            label10.Size = new Size(108, 15);
            label10.TabIndex = 8;
            label10.Text = "デフォルトの表示範囲";
            // 
            // comboBoxMKVisible
            // 
            comboBoxMKVisible.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMKVisible.FormattingEnabled = true;
            comboBoxMKVisible.Location = new Point(120, 80);
            comboBoxMKVisible.Name = "comboBoxMKVisible";
            comboBoxMKVisible.Size = new Size(138, 23);
            comboBoxMKVisible.TabIndex = 7;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 54);
            label11.Name = "label11";
            label11.Size = new Size(78, 15);
            label11.TabIndex = 4;
            label11.Text = "アクセストークン";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 25);
            label12.Name = "label12";
            label12.Size = new Size(82, 15);
            label12.TabIndex = 1;
            label12.Text = "インスタンスURL";
            // 
            // textBoxMKToken
            // 
            textBoxMKToken.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMKToken.Location = new Point(94, 51);
            textBoxMKToken.Name = "textBoxMKToken";
            textBoxMKToken.Size = new Size(489, 23);
            textBoxMKToken.TabIndex = 3;
            // 
            // textBoxMKInstance
            // 
            textBoxMKInstance.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMKInstance.Location = new Point(94, 22);
            textBoxMKInstance.Name = "textBoxMKInstance";
            textBoxMKInstance.Size = new Size(489, 23);
            textBoxMKInstance.TabIndex = 2;
            // 
            // checkBoxSendMisskey
            // 
            checkBoxSendMisskey.AutoSize = true;
            checkBoxSendMisskey.Location = new Point(6, 0);
            checkBoxSendMisskey.Name = "checkBoxSendMisskey";
            checkBoxSendMisskey.Size = new Size(141, 19);
            checkBoxSendMisskey.TabIndex = 1;
            checkBoxSendMisskey.Text = "Misskeyへの連動を行う";
            checkBoxSendMisskey.UseVisualStyleBackColor = true;
            checkBoxSendMisskey.CheckedChanged += checkBoxSendMisskey_CheckedChanged;
            // 
            // buttonExit
            // 
            buttonExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonExit.DialogResult = DialogResult.OK;
            buttonExit.Location = new Point(520, 455);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(75, 23);
            buttonExit.TabIndex = 1;
            buttonExit.Text = "完了";
            buttonExit.UseVisualStyleBackColor = true;
            // 
            // GrobalSettingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonExit;
            ClientSize = new Size(613, 490);
            Controls.Add(groupBox4);
            Controls.Add(label8);
            Controls.Add(groupBox2);
            Controls.Add(buttonExit);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GrobalSettingForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "全体設定";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericDeactiveReload).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericActiveReload).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericFocus).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericZoom).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxMSInstance;
        private CheckBox checkBoxSendMastodon;
        private TextBox textBoxMSToken;
        private Button buttonExit;
        private NumericUpDown numericFocus;
        private NumericUpDown numericZoom;
        private NumericUpDown numericDeactiveReload;
        private NumericUpDown numericActiveReload;
        private ComboBox comboBoxMSVisible;
        private CheckBox checkBoxCloseDeactive;
        private ComboBox comboBoxMKVisible;
        private TextBox textBoxMKToken;
        private TextBox textBoxMKInstance;
        private CheckBox checkBoxSendMisskey;
    }
}