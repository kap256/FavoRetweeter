using FavoRetweeter;
using KAPLibNet.ConfigForm;
using Mastonet;
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
    public partial class GrobalSettingForm
        : Form
    {

        CheckboxConfig IsSendMastodon;
        TextboxConfig MastodonInstance;
        TextboxConfig MastodonAccessToken;
        ComboboxConfig<FRVisibility> MastodonVisibility;

        CheckboxConfig IsSendMisskey;
        TextboxConfig MisskeyInstance;
        TextboxConfig MisskeyAccessToken;
        ComboboxConfig<FRVisibility> MisskeyVisibility;

        CheckboxConfig IsCloseDeactive;
        CheckboxConfig IsMute;
        NumericConfig Zoom;
        NumericConfig FocusInterval;
        NumericConfig ActiveReload;
        NumericConfig DeactiveReload;

        public GrobalSettingForm()
        {
            InitializeComponent();

            IsSendMastodon = new(Config.IsSendMastodon, checkBoxSendMastodon);
            MastodonInstance = new(Config.MastodonInstance, textBoxMSInstance);
            MastodonAccessToken = new(Config.MastodonAccessToken, textBoxMSToken);
            MastodonVisibility = new(Config.MastodonVisibility, comboBoxMSVisible);
            comboBoxMSVisible.Items.RemoveAt(0);

            IsSendMisskey = new(Config.IsSendMisskey, checkBoxSendMisskey);
            MisskeyInstance = new(Config.MisskeyInstance, textBoxMKInstance);
            MisskeyAccessToken = new(Config.MisskeyAccessToken, textBoxMKToken);
            MisskeyVisibility = new(Config.MisskeyVisibility, comboBoxMKVisible);
            comboBoxMKVisible.Items.RemoveAt(0);

            IsCloseDeactive = new(Config.IsCloseDeactive, checkBoxCloseDeactive);
            IsMute = new(Config.IsMute, checkBoxMute);
            Zoom = new(Config.WebviewZoomDefault, numericZoom);
            FocusInterval = new(Config.TwitterFocusInterval, numericFocus);
            ActiveReload = new(Config.TwitterActiveReloadInterval, numericActiveReload);
            DeactiveReload = new(Config.TwitterDeactiveReloadInterval, numericDeactiveReload);
        }

        private void checkBoxSendMastodon_CheckedChanged(object sender, EventArgs e)
        {
            textBoxMSInstance.Enabled = checkBoxSendMastodon.Checked;
            textBoxMSToken.Enabled = checkBoxSendMastodon.Checked;
            comboBoxMSVisible.Enabled = checkBoxSendMastodon.Checked;
        }

        private void checkBoxSendMisskey_CheckedChanged(object sender, EventArgs e)
        {
            textBoxMKInstance.Enabled = checkBoxSendMisskey.Checked;
            textBoxMKToken.Enabled = checkBoxSendMisskey.Checked;
            comboBoxMKVisible.Enabled = checkBoxSendMisskey.Checked;
        }

    }
}
