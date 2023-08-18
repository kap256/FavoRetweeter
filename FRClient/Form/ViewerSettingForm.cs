using FRClient.Properties;
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
    public partial class ViewerSettingForm : Form
    {
        const string CANCEL_TEXT = "キャンセル";
        public ViewerSetting.Viewer Setting { get; private set; }

        SampleTextForm Sample = null;

        #region 初期化-----------------------------------------------
        public ViewerSettingForm(ViewerSetting.Viewer v)
        {
            InitializeComponent();

            if (v == null) {
                Setting = new();
                buttonDelete.Text = CANCEL_TEXT;
            } else {
                Setting = v;
            }
            SetValues();
        }
        private void SetValues()
        {
            textBoxUrl.Text = Setting.URI;
            numericWidth.Value = Setting.Width;
            trackBarWidth.Value = Setting.Width;

            checkBoxHalf.Checked = Setting.IsHalf;
            textBoxHalf.Text = Setting.HalfURI;
            textBoxHalf.Enabled = Setting.IsHalf;

            textBoxProfile.Text = Setting.Profile;

            textBoxCSS.Text = Setting.Style;
            textBoxScript.Text = Setting.Script;
        }
        #endregion

        #region 値の変更-----------------------------------------------
        private void textBoxUrl_TextChanged(object sender, EventArgs e)
        {
            Setting.URI = textBoxUrl.Text;
        }

        private void numericWidth_ValueChanged(object sender, EventArgs e)
        {
            Setting.Width = (int)numericWidth.Value;
            trackBarWidth.Value = Setting.Width;
        }

        private void trackBarWidth_Scroll(object sender, EventArgs e)
        {
            Setting.Width = trackBarWidth.Value;
            numericWidth.Value = Setting.Width;
        }

        private void checkBoxHalf_CheckedChanged(object sender, EventArgs e)
        {
            Setting.IsHalf = checkBoxHalf.Checked;
            textBoxHalf.Enabled = Setting.IsHalf;
        }

        private void textBoxHalf_TextChanged(object sender, EventArgs e)
        {
            Setting.HalfURI = textBoxHalf.Text;
        }

        private void textBoxProfile_TextChanged(object sender, EventArgs e)
        {
            Setting.Profile = textBoxProfile.Text;
        }

        private void textBoxScript_TextChanged(object sender, EventArgs e)
        {
            Setting.Script = textBoxScript.Text;
        }

        private void textBoxCSS_TextChanged(object sender, EventArgs e)
        {
            Setting.Style = textBoxCSS.Text;
        }
        #endregion

        #region 終了-----------------------------------------------
        private void buttonComplete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Setting.URI)) {
                var result = MessageBox.Show(
                    "URLは必須です",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            //反映は上で行う
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (buttonDelete.Text != CANCEL_TEXT) {
                var result = MessageBox.Show(
                    "本当に削除してもよろしいですか？",
                    "確認",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.OK) {
                    return;
                }
            }

            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
        private void ViewerSettingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Sample != null) {
                Sample.Close();
            }
        }
        #endregion

        private void buttonSampleCSS_Click(object sender, EventArgs e)
        {
            if (Sample != null) {
                Sample.Close();
            }
            Sample = new SampleTextForm(Resources.sample_css);
            Sample.Show();
        }

    }
}
