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
        public Image bImage;
        graphicList gl;
        public drawArea()
        {
            InitializeComponent();
            gl = new graphicList();
            bImage = null;
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
