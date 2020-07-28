using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace LidomaCard
{
    [Serializable]
    public class labelObject : rect
    {
        
        public labelObject()
        {

            FontSize = 15;
            Height = (int)FontSize + 20;
            FontColor = Color.Black;
            Select = true;
            Text = "100";
            FontName = "Tahoma";
            Style = FontStyle.Regular;
          
        }

        string reverse;

        //private void DrawReverse(Graphics g)
        //{
        //    char[] character = Text.ToArray();
        //    int i = 0;
        //    int j = character.Length - 1;
        //    while (i < j)
        //    {
        //        char t = character[i];
        //        character[i] = character[j];
        //        character[j] = t;
        //        i++;
        //        j--;
        //    }
        //    reverse = new string(character);
        //    int total = ZeroNumber + Text.Length;
        //    g.DrawString(string.Format("{0:D" + total + "}", Convert.ToInt32(reverse))
        //       , new Font(FontName, FontSize, Style), new SolidBrush(FontColor), new Rectangle(X, Y, Width, Height));
        //}

        private void DrawMirror(Graphics g,int j)
        {
            int total = ZeroNumber + Text.Length;
            float w = g.MeasureString(Text, new Font(FontName, FontSize, Style)).Width + X + (ZeroNumber * total);
            g.ScaleTransform(-1, 1);
            int a = Convert.ToInt32(Text) + j;
            //int total = ZeroNumber + Text.Length;
            g.DrawString(string.Format("{0:D" + total + "}", Convert.ToInt32(a))
               , new Font(FontName, FontSize, Style), new SolidBrush(FontColor), new Rectangle(Convert.ToInt32(-w), Y, Width, Height));
        }

        //private void DrawMirror2(Graphics g)
        //{
        //    int total = ZeroNumber + Text.Length;
        //    float w = g.MeasureString(Text, new Font(FontName, FontSize, Style)).Width + X + (ZeroNumber * total);
        //    g.ScaleTransform(-1, 1);
        //    DrawReverse(g);
        //    g.DrawString(string.Format("{0:D" + total + "}", Convert.ToInt32(reverse))
        //       , new Font(FontName, FontSize, Style), new SolidBrush(FontColor), new Rectangle(Convert.ToInt32(-w), Y, Width, Height));
        //}

        public override void onKeyPress(DrawArea drawArea, KeyPressEventArgs e)
        {
            if ( char.IsDigit(e.KeyChar))
            this.Text += e.KeyChar;
        }
        public override string name()
        {
            return "lable";
        }
        public override void print(DrawArea drawArea,Graphics g,int j,bool border)
        {
            try
            {
                
                StrAv = false;
                WhichObject = false;
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.FormatFlags = StringFormatFlags.FitBlackBox;

                base.print(drawArea, g, j, border);
                if (N2S)
                {
                    int a = Convert.ToInt32(Text) + j;
                    number2String nss = new number2String();
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawString(nss.num2str(a.ToString()), new Font(FontName, FontSize, Style), new SolidBrush(FontColor), new Rectangle(X, Y, Width, Height));
                }
                //else if (Reversed)
                //{
                //    DrawReverse(g);
                //}
                //else if (Mirror1)
                //{
                //    DrawMirror(g, j);
                //}
                //else if (Mirror2)
                //{
                //    DrawMirror2(g);
                //}
                else
                {
                    int a = Convert.ToInt32(Text) + j;
                    int total = ZeroNumber + Text.Length;
                    g.DrawString(string.Format("{0:D" + total + "}", Convert.ToInt32(a))
                       , new Font(FontName, FontSize, Style), new SolidBrush(FontColor),
                       X,Y);
                }
            }
            catch { }
        }
        public override void Draw(DrawArea drawArea, System.Drawing.Graphics g, float zoom)
        {
            try
            {
                int different = Convert.ToInt32(drawArea.ZoomFactor);
                StrAv = false;
                WhichObject = false;
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.FormatFlags = StringFormatFlags.FitBlackBox;
                base.Draw(drawArea, g,zoom);
                if (N2S)
                {
                    number2String nss = new number2String();

                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawString( nss.num2str(Text) , new Font(FontName, FontSize, Style), new SolidBrush(FontColor), new Rectangle(X, Y, Width, Height));
                }
                //else if (Reversed)
                //{
                //    DrawReverse(g);
                //}
                //else if (Mirror1)
                //{
                //    DrawMirror(g,0);
                //}
                //else if (Mirror2)
                //{
                //    DrawMirror2(g);
                //}
                else
                {
                    int total = ZeroNumber + Text.Length;
                    g.DrawString(string.Format("{0:D" + total + "}", Convert.ToInt32(Text))
                       , new Font(FontName, FontSize, Style), new SolidBrush(FontColor),
                       new Rectangle(X, Y, Width * different, Height * different));
                }
            }
            catch { }
        }
    }
}
