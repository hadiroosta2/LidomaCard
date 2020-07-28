using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace LidomaCard
{
    [Serializable]
    public class CreateLogo : rect
    {
        Image img;
        public override void Draw(DrawArea area, Graphics g, float zoom)
        {
            try
            {
                img = Image.FromFile(LogoImage);
                base.Draw(area, g,zoom);
                Bitmap bp = new Bitmap(img, new Size(Width, Height));
                g.DrawImage(bp, X, Y, Width, Height);
                bp.Dispose();
                img.Dispose();
            }
            catch { }
        }
     
        public override void print(DrawArea drawArea, Graphics g, int j,bool border)
        {
            try
            {
                base.print(drawArea, g, j, border);
                img = Image.FromFile(LogoImage);
                Bitmap bp = new Bitmap(img, new Size(Width, Height));
                g.DrawImage(bp, X, Y, Width, Height);
                bp.Dispose();
                img.Dispose();
            }
            catch { }
        }
        public override string name()
        {
            return "logo";
        }
       
    }
}
