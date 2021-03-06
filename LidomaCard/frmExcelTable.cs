using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LidomaCard
{
    public partial class frmExcelTable : Form
    {
        DataTable table;
        public frmExcelTable(DataTable dt)
        {
            InitializeComponent();
            table = dt;
        }

        private void frmExcelTable_Load(object sender, EventArgs e)
        {
            GroupBox gb = new GroupBox();
            gb.RightToLeft = RightToLeft.Yes;
            gb.Left = 10;
            gb.Text = "انتخاب فیلد ";
            gb.Height = (table.Columns.Count * 40) + 80;
            this.Height = gb.Height + 50;
            this.Controls.Add(gb);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                CheckBox c = new CheckBox();
                c.Text = table.Columns[i].ColumnName;
                c.Left = 50;
                c.Top = 40 * i + 30;
                gb.Controls.Add(c);
            }
            Button b = new Button();
            b.Text = "انتخاب";
            b.Width = 100;
            b.Height = 40;
            b.Left = 50;
            b.Top = gb.Height - 50;
            gb.Controls.Add(b);
            b.Click += new EventHandler(b_Click);
        }

        void b_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}