using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace LidomaCard
{
    [Serializable]
    public class StringObject : rect
    {
        public StringObject()
        {
            FontSize = 15;
            Height = (int)FontSize + 20;
            FontColor = Color.Black;
            Select = true;
            Text = "متن شما";
            FontName = "Tahoma";
            Style = FontStyle.Regular;
        }
        
      
        public override string name()
        {
            return "Textlable";
        }
        public override void onKeyPress(DrawArea drawArea, KeyPressEventArgs e)
        {
          if(e.KeyChar!=Convert.ToChar( Keys.Back))
                this.Text += e.KeyChar;

        }
      
        public override void Draw(DrawArea drawArea, System.Drawing.Graphics g,float zoom)
        {
            StrAv = true;
            base.Draw(drawArea, g,zoom);
            g.DrawString(Text, new System.Drawing.Font(FontName, FontSize, Style), new SolidBrush(FontColor), new Rectangle(X, Y,Convert.ToInt32(this.Width*zoom),Convert.ToInt32( Height*zoom)));
        }
        public override void print(DrawArea drawArea, Graphics g, int j,bool border)
        {
            base.print(drawArea, g, j, border);
            g.DrawString(Text, new System.Drawing.Font(FontName, FontSize, Style), new SolidBrush(FontColor), new Rectangle(X, Y, Width, Height));

        }
       
    }
}
