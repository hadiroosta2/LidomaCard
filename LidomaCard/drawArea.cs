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
        public drawArea()
        {
            InitializeComponent();
            bImage = null;
        }

        private void drawArea_Paint(object sender, PaintEventArgs e)
        {
            if (bImage != null)
            {
                Graphics g = e.Graphics;
                g.DrawImage(bImage, 0, 0,this.Width,this.Height);
            }
           
        }
    }
}
