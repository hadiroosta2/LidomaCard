using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LidomaCard
{
   public class textLable:shape
    {
        
        public textLable()
        {

        }
       
        public override void draw(Graphics g)
        {
            if (active)
            {
                g.DrawRectangle(Pens.Red, left, top, width, height);
            }
            else
            {
                g.DrawRectangle(Pens.Black, left, top, width, height);
            }
            
            g.DrawString(text, new Font("tahoma", 12), new SolidBrush(Color.Black), left, top);
        }
    }
}
