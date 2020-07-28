using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace LidomaCard
{
    [Serializable]
    public class rect : drawBase
    {
        bool cheked;
        Point oldPoint;
        bool move;
        int nodeSize = 7;
        corner sizeableCor = corner.non;
        bool meClick;

        public rect()
        {
            Width = 100;
            Height = 100;
            X = 0;
            Y = 0;
            oldPoint = new Point(0, 0);
            move = false;
            meClick = false;
            cheked = false;
            rotate = 0;
        }
        private enum corner
        {
            upLeft,
            upRight,
            upMidell,
            downLeft,
            downRight,
            downMidell,
            midellRight,
            midellLeft,
            non
        }
        public override void print(DrawArea drawArea, Graphics g, int j,bool border)
        {
            try
            {
                int zoom = Convert.ToInt32(drawArea.ZoomFactor);
                Matrix m = new Matrix();
                RotatePoint = new PointF(X + Width / 2, Y + Height / 2);

                m.RotateAt(rotate, RotatePoint);
                g.Transform = m;
                #region transparent
                if(border)
                {
                    if (Transparent)
                    {

                        g.DrawRectangle(Pens.Black, X, Y, zoom * Width, zoom * Height);

                    }
                    else
                    {

                        g.FillRectangle(Brushes.White, X, Y, Width, Height);
                        g.DrawRectangle(Pens.Black, X, Y, Width, Height);

                    }
                }
              
                #endregion

               
            }
            catch { }
        }
        public override void Draw(DrawArea drawArea, Graphics g, float zoom)
        {
            try
            {
               // int zoom = Convert.ToInt32(drawArea.ZoomFactor);
                Matrix m = new Matrix();
                RotatePoint = new PointF(X + Width / 2, Y + Height / 2);
                
                m.RotateAt(rotate, RotatePoint);
                g.Transform =  m;
                if (Select)
                {
                    g.DrawRectangle(Pens.Red, X, Y, zoom * Width, zoom * Height);
                    foreach (corner c in Enum.GetValues(typeof(corner)))
                    {
                        g.DrawRectangle(Pens.Red, GetCorRect(c));
                       
                    }
                    g.DrawEllipse(Pens.Blue, RotatePoint.X, RotatePoint.Y, 5, 5);
                }

                #region transparent
                if (Transparent)
                {
                    if (Select)
                    {

                        g.DrawRectangle(Pens.Red, X, Y, zoom * Width, zoom * Height);
                        //foreach (PosSizableRect pos in Enum.GetValues(typeof(PosSizableRect)))
                        //{
                        //    g.DrawRectangle(new Pen(Color.Red), GetRect(pos));
                        //}                       

                    }
                    else if (!Select)
                    {

                        g.DrawRectangle(Pens.Black, X, Y, zoom * Width, zoom * Height);
                    }
                }
                else
                {
                    if (Select)
                    {
                        g.FillRectangle(Brushes.White, X, Y, Width, Height);
                        g.DrawRectangle(Pens.Red, X, Y, Width, Height);
                        foreach (corner pos in Enum.GetValues(typeof(corner)))
                        {
                            g.DrawRectangle(new Pen(Color.Red), GetCorRect(pos));
                        }

                    }
                    else
                    {
                        g.FillRectangle(Brushes.White, X, Y, Width, Height);
                        g.DrawRectangle(Pens.Black, X, Y, Width, Height);
                    }
                }
                #endregion

                if (cheked)
                {
                    Pen pen = new Pen(Color.Blue);
                    pen.DashStyle = DashStyle.DashDot;
                    g.DrawLine(pen, X, Y, X, 0);
                    g.DrawLine(pen, X, Y, X, drawArea.Height);
                    g.DrawLine(pen, X, Y, drawArea.Width, Y);
                    g.DrawLine(pen, X, Y, 0, Y);

                }
            }
            catch { }
        }
        public void MoveRect(int dx, int dy)
        {
            try
            {
                X += dx;
                Y += dy;
            }
            catch { }
        }
        public override int HitTest(Point point)
        {
            try
            {
                Rectangle r = new Rectangle(X, Y, Width, Height);
                if (r.Contains(point))
                {
                    return 0;
                }
                foreach (corner c in Enum.GetValues(typeof(corner)))
                {
                    if (GetCorRect(c).Contains(point))
                    {
                        return -1;
                    }
                }
                return 1;
            }
            catch { return 2; }
        }
        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            try
            {
                    meClick = true;
                    Point point = new Point(e.X, e.Y);
                    sizeableCor = corner.non;
                    sizeableCor = GetSizableCor(point);
                    //if (HitTest(point) == 0 || HitTest(point) == -1)
                    //{
                        move = true;
                      //  cheked = true;
                        Select = true;
                    //}
                    oldPoint = point;
                    drawArea.Refresh();
               
               
            }
            catch { }
        }
        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            try
            {
                move = false;
                meClick = false;
                cheked = false;
                drawArea.Refresh();
            }
            catch { }
        }
        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            try
            {
                chengCurser(drawArea, new Point(e.X, e.Y));
                if (meClick == false)
                {
                    return;
                }
                int bacWidth = Width;
                int bacHeight = Height;
                int bacX = X;
                int bacY = Y;
                switch (sizeableCor)
                {
                    case corner.upLeft:
                        X += e.X - oldPoint.X;
                        Y += e.Y - oldPoint.Y;
                        Width -= e.X - oldPoint.X;
                        Height -= e.Y - oldPoint.Y;
                        break;
                    case corner.upRight:
                        Y += e.Y - oldPoint.Y;
                        Width += e.X - oldPoint.X;
                        Height -= e.Y - oldPoint.Y;
                        break;
                    case corner.upMidell:
                        Y += e.Y - oldPoint.Y;
                        Height -= e.Y - oldPoint.Y;
                        break;
                    case corner.downLeft:
                        X += e.X - oldPoint.X;
                        Width -= e.X - oldPoint.X;
                        Height += e.Y - oldPoint.Y;
                        break;
                    case corner.downRight:
                        Width += e.X - oldPoint.X;
                        Height += e.Y - oldPoint.Y;
                        break;
                    case corner.downMidell:
                        Height += e.Y - oldPoint.Y;
                        break;
                    case corner.midellRight:
                        Width += e.X - oldPoint.X;
                        break;
                    case corner.midellLeft:
                        X += e.X - oldPoint.X;
                        Width -= e.X - oldPoint.X;
                        break;
                    default:
                        if (move)
                        {
                            int dx = e.X - oldPoint.X;
                            int dy = e.Y - oldPoint.Y;
                            MoveRect(dx, dy);
                        }
                        break;
                }


                if (Width < 5 || Height < 5)
                {
                    Width = bacWidth;
                    Height = bacHeight;
                    X = bacX;
                    Y = bacY;
                }
                oldPoint.X = e.X;
                oldPoint.Y = e.Y;
                drawArea.Refresh();
            }
            catch { }
        }
        private corner GetSizableCor(Point p)
        {
            try
            {
                foreach (corner c in Enum.GetValues(typeof(corner)))
                {
                    if (GetCorRect(c).Contains(p))
                    {
                        return c;
                    }
                }
                return corner.non;
            }
            catch { return corner.non; }
        }
        public Rectangle createRectangle(int x, int y)
        {
            return new Rectangle(x - nodeSize / 2, y - nodeSize / 2, nodeSize, nodeSize);
        }
        private Rectangle GetCorRect(corner c)
        {
            switch (c)
            {
                case corner.upLeft:
                    return createRectangle(X, Y);

                case corner.upRight:
                    return createRectangle(X + Width, Y);

                case corner.upMidell:
                    return createRectangle(X + Width / 2, Y);

                case corner.downLeft:
                    return createRectangle(X, Y + Height);

                case corner.downRight:
                    return createRectangle(X + Width, Y + Height);

                case corner.downMidell:
                    return createRectangle(X + Width / 2, Y + Height);

                case corner.midellRight:
                    return createRectangle(X + Width, Y + Height / 2);

                case corner.midellLeft:
                    return createRectangle(X, Y + Height / 2);

                default:
                    return new Rectangle();

            }
        }
        private Cursor GetCurser(corner c)
        {
            switch (c)
            {
                case corner.upLeft:
                    return Cursors.SizeNWSE;
                case corner.upRight:
                    return Cursors.SizeNESW;
                case corner.upMidell:
                    return Cursors.SizeNS;
                case corner.downLeft:
                    return Cursors.SizeNESW;
                case corner.downRight:
                    return Cursors.SizeNWSE;
                case corner.downMidell:
                    return Cursors.SizeNS;
                case corner.midellRight:
                    return Cursors.SizeWE;
                case corner.midellLeft:
                    return Cursors.SizeWE;
                case corner.non:
                    return Cursors.Default;
                default:
                    return Cursors.Default;
            }
        }
        private void chengCurser(DrawArea drawArea, Point p)
        {
            drawArea.Cursor = GetCurser(GetSizableCor(p));
        }
        public override void OnKeyDown(DrawArea drawArea, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Back:
                        Text = Text.Remove(Text.Length - 1);
                        break;
                    case Keys.Down:
                        this.Y += 1;
                        break;
                    case Keys.Up:
                        this.Y -= 1;
                        break;
                    case Keys.Right:
                        this.X += 1;
                        break;
                    case Keys.Left:
                        this.X -= 1;
                        break;
                    case Keys.Enter:
                        Text += "/n";
                        break;


                }
            }
            catch
            {

            }
              }
        public Point BackTrackMouse(Point p)
        {
            // Backtrack the mouse...
            Point[] pts = new Point[] { p };
            Matrix mx = new Matrix();
            //mx.Translate(-ClientSize.Width / 2f, -ClientSize.Height / 2f, MatrixOrder.Append);
            mx.Rotate(rotate, MatrixOrder.Append);
            //mx.Translate(ClientSize.Width / 2f + _panX, ClientSize.Height / 2f + _panY, MatrixOrder.Append);
            //mx.Scale(_zoom, _zoom, MatrixOrder.Append);
          //  mx.Invert();
            mx.TransformPoints(pts);
            return pts[0];
        }
    }
}
