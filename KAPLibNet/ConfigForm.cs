using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KAPLibNet.IConfig;

namespace KAPLibNet.ConfigForm
{
    public class TextboxConfig
    {
        ConfStr Conf;
        TextBox Box;
        public TextboxConfig(ConfStr conf, TextBox box)
        {
            Conf = conf;
            Box = box;
            Box.Text = Conf;
            Box.PlaceholderText = Conf.GetDefault();
            Box.LostFocus += Box_LostFocus;
        }

        private void Box_LostFocus(object sender, EventArgs e)
        {
            Conf.Set(Box.Text);
        }
    }
    public class CheckboxConfig
    {
        ConfBool Conf;
        CheckBox Box;
        public CheckboxConfig(ConfBool conf, CheckBox box)
        {
            Conf = conf;
            Box = box;
            Box.Checked = Conf;
            Box.CheckedChanged += Box_CheckedChanged;
        }

        private void Box_CheckedChanged(object sender, EventArgs e)
        {
            Conf.Set(Box.Checked);
        }
    }
    public class NumericConfig
    {
        ConfInt Conf;
        NumericUpDown Box;
        public NumericConfig(ConfInt conf, NumericUpDown box)
        {
            Conf = conf;
            Box = box;
            Box.Maximum = Conf.Max;
            Box.Minimum = Conf.Min;
            Box.Value = Conf;
            Box.ValueChanged += Box_ValueChanged; ;
        }

        private void Box_ValueChanged(object sender, EventArgs e)
        {
            Conf.Set((int)Box.Value);
        }
    }
    public class ComboboxConfig<E>
    {
        ConfEnumlike<E> Conf;
        ComboBox Box;
        public ComboboxConfig(ConfEnumlike<E> conf, ComboBox box)
        {
            Conf = conf;
            Box = box;
            Box.Items.AddRange(conf.Names());
            Box.SelectedItem = (string)conf;
            Box.SelectedIndexChanged += Box_SelectedIndexChanged;
        }

        private void Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conf.Set(Box.SelectedItem.ToString());
        }
    }
}
