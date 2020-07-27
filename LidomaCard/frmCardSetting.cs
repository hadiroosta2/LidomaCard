using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LidomaCard
{
    public partial class frmCardSetting : Form
    {
        public int DAwidth=100;
        public int DAheight=100;
        public frmCardSetting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAwidth =Convert.ToInt32( numericUpDown1.Value);
            DAheight =Convert.ToInt32( numericUpDown2.Value);
            this.Close();
        }

        private void frmCardSetting_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = DAwidth;
            numericUpDown2.Value = DAheight;
        }
    }
}