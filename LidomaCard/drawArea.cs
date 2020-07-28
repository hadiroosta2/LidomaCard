using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LidomaCard
{
    public partial class drawArea : UserControl
    {
        private const int CS_DROPSHADOW = 0x00020000;
        public Image bImage;
        graphicList gl;
        public drawArea()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer, true);
            UpdateStyles();
            gl = new graphicList();
            bImage = null;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                // add the drop shadow flag for automatically drawing
                // a drop shadow around the form
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        public void add(shape s)
        {
            gl.add(s);
            this.Refresh();
        }
        private void drawArea_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            if (bImage != null)
            {
                
                g.DrawImage(bImage, 0, 0,this.Width,this.Height);
            }
            //foreach (shape s in gl)
            //{
            //    s.draw(g);
            //}
           
        }
    }
}
