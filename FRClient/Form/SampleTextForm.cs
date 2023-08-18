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
    public partial class SampleTextForm : Form
    {
        public SampleTextForm(string text)
        {
            InitializeComponent();

            this.textBox.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
