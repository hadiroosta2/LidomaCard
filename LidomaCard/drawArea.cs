using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing.Drawing2D;

namespace LidomaCard
{
    public partial class DrawArea : UserControl
    {
        drawBase lableCopy = null;
        graphicList graphicList;
        drawBase activeObject;
        Image img;
        ContextMenuStrip cm;
        frmMain0 owener;
        Image backImage;
        //int imageWidth, imageHeight;
        public bool hasChenge ;
        float zoom = 1;
        Rectangle r;
        public DrawArea()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.DoubleBuffered = true;
            hasChenge = false;
            
            
        }

        public void Initialize(frmMain0 owener)
        {
            try
            {
               
                SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
                this.owener = owener;

                graphicList = owener.UserSetting.GList;
                //Doc_Manager.drawAreaIsActive = true;
                activeObject = null;
                owener.UserSetting.showGrid = false;
                owener.UserSetting.arondLine = true;
            }
            catch { }
        }

        public float ZoomFactor
        {
            get { return zoom; }
            set
            {
                zoom = value;
            }
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Down || keyData == Keys.Up || keyData == Keys.Right || keyData == Keys.Left || keyData == Keys.F1)
            {
                return true;
            }
            else
            {
                return base.IsInputKey(keyData);
            }
        }

        public void ChengeSize(string size,userSetting us)
        {
            switch (size)
            {
                case "A4":
                    if (us.orintation)
                    {
                        this.Height = 1122;
                        this.Width = 793;
                    }
                    else
                    {
                        this.Height = 793;
                        this.Width = 1122;
                    }

                    break;
                case "A5":
                    if (us.orintation)
                    {
                        this.Height = 793;
                        this.Width = 529;
                    }
                    else
                    {
                        this.Height = 529;
                        this.Width = 793;
                    }
                    break;
                case "A3":
                    if (us.orintation)
                    {
                        this.Height = 1587;
                        this.Width = 1096;
                    }
                    else
                    {
                        this.Height = 1096;
                        this.Width = 1587;
                    }
                    break;
                case "B4":
                    if (us.orintation)
                    {
                        this.Height = 1360;
                        this.Width = 944;
                    }
                    else
                    {
                        this.Height = 944;
                        this.Width = 1360;
                    }
                    break;
                case "B5":
                    if (us.orintation)
                    {
                        this.Height = 944;
                        this.Width = 680;
                    }
                    else
                    {
                        this.Height = 680;
                        this.Width = 944;
                    }
                    break;
                default:
                    if (us.orintation)
                    {
                        this.Height = 1122;
                        this.Width = 793;
                    }
                    else
                    {
                        this.Height = 793;
                        this.Width = 1122;
                    }
                    break;
            }
            Refresh();
        }

        public void ChengeOrientation(userSetting us)
        {

            int temp = this.Height;
            this.Height = this.Width;
            this.Width = temp;

            us.orintation = !us.orintation;
            Refresh();
        }

        private void OnContexMenu(MouseEventArgs e)
        {
            try
            {
                Point p = new Point(e.X, e.Y);
                int n = graphicList.Count;
                drawBase o = null;
                for (int i = 0; i < n; i++)
                {
                    if (graphicList[i].HitTest(p) == 0)
                    {
                        o = graphicList[i];
                        break;
                    }
                }
                if (o != null)
                {
                    if (!o.Select)
                        graphicList.UnSelectAll();
                    o.Select = true;
                }
                else
                {
                    graphicList.UnSelectAll();
                }
                // Refresh();
                cm = new System.Windows.Forms.ContextMenuStrip();
                int mItems = owener.ContextParent.DropDownItems.Count;
                for (int i = mItems - 1; i >= 0; i--)
                {
                    cm.Items.Insert(0, owener.ContextParent.DropDownItems[i]);
                }

                cm.Show(this, p);
                cm.Closed += delegate(object sender, ToolStripDropDownClosedEventArgs args)
                {
                    if (cm != null)      // precaution
                    {
                        mItems = cm.Items.Count;

                        for (int k = mItems - 1; k >= 0; k--)
                        {
                            owener.ContextParent.DropDownItems.Insert(0, cm.Items[k]);
                        }
                    }
                };
            }
            catch { }
        }

        public void setBack(string ImagePath)
        {
            try
            {
                img = Image.FromFile(ImagePath);
                BackImage = new Bitmap(img, this.Width, this.Height);
                this.Invalidate();
               
            }
            catch { }
        }

        void DrawGrid(Graphics g)
        {
            try
            {
                for (float m = 25; m < this.Width; m += 25)
                {
                    g.DrawLine(Pens.LightGray, m, 0, m, this.Height);
                }
                for (float m = 25; m < this.Height; m += 25)
                {
                    g.DrawLine(Pens.LightGray, 0, m, this.Width, m);
                }
            }
            catch { }
        }

        #region propertis


        public drawBase ActiveObject
        {
            get
            {
                return activeObject;
            }
            set
            {
                activeObject = value;

            }
        }
        public drawBase LableCopy
        {
            get
            {
                return lableCopy;
            }
        }
        public Image Image
        {
            get
            {
                return img;
            }
            set
            {
                img = value;
            }
        }
        public Image BackImage
        {
            get
            {
                return backImage;
            }
            set
            {
                backImage = value;
            }
        }
        public graphicList GraphicList
        {
            get
            {
                return graphicList;
            }
            set
            {
                graphicList = value;
            }
        }

        #endregion

        private void DrawArea_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (img != null)
                {
                    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    e.Graphics.DrawImage(backImage, 0, 0, this.Width, this.Height);
                }
                else
                {
                    e.Graphics.Clear(this.BackColor);
                }

                if (owener.UserSetting.arondLine)
                {
                    r = this.ClientRectangle;
                    r.Inflate(-30, -30);
                    Pen p = new Pen(Color.Gray, 3);
                    p.DashStyle = DashStyle.DashDot;

                    e.Graphics.DrawRectangle(p, r);

                    //Doc_Manager.arondLine = false;
                }

                if (owener.UserSetting.showGrid)
                {
                    DrawGrid(e.Graphics);
                }
                graphicList.draw(this, e.Graphics,zoom);
            }
            catch { }
        }

        private void DrawArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (activeObject != null)
            {
                activeObject.onKeyPress(this, e);
                Refresh();
            }
        }

        private void DrawArea_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keyMode = Control.ModifierKeys;
            if ((keyMode == (Keys.Control)) && (e.KeyCode == Keys.A))
            {
                graphicList.sellectAll();
                Refresh();
            }

            if (e.KeyCode == Keys.Delete)
            {
                graphicList.DeletSelection();
                Refresh();
            }
            if ((keyMode == (Keys.Control)) && (e.KeyCode == Keys.C))
            {
                DoCopy();

            }
            if ((keyMode == (Keys.Control)) && (e.KeyCode == Keys.V))
            {
                DoPaste();
            }
            if (GraphicList.SelectionCount > 0)
            {
                for (int i = graphicList.Count - 1; i >= 0; --i)
                {
                    if (GraphicList[i].Select)
                        GraphicList[i].OnKeyDown(this, e);
                }
                Refresh();
            }
        }

        private void DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                Point p = new Point(e.X, e.Y);
                if (e.Button == MouseButtons.Left && (Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    GraphicList.addSelection(p);
                    Refresh();
                }
                else
                {
                    UpdateActiveObject(p);
                }

                if (graphicList.SelectionCount > 0 && e.Button == MouseButtons.Left)
                {

                    foreach (drawBase o in GraphicList.selection)
                    {
                        o.OnMouseDown(this, e);
                    }
                    Refresh();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    OnContexMenu(e);
                }
                
            }
            catch { }
        }

        private void DrawArea_MouseMove(object sender, MouseEventArgs e)
        {

            if (graphicList.SelectionCount > 0)
            {
                foreach (drawBase o in GraphicList.selection)
                {
                    o.OnMouseMove(this, e);
                    //hasChenge = true;
                }
            }
        }

        private void DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                foreach (drawBase o in GraphicList.selection)
                {
                    o.OnMouseUp(this, e);
                }
            }
            catch { }
        }

        public void print(Graphics g, int count, bool backPrint, bool border)
        {
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            if (backPrint)
            {


                g.DrawImage(img, 0, 0, this.Width, this.Height);
            }
            else
            {
                g.Clear(this.BackColor);
            }
            graphicList.print(this, g, count, border);
        }

        public void DoCopy()
        {
            lableCopy = (drawBase)activeObject.Clone();
        }

        public void DoPaste()
        {
            if (lableCopy != null)
            {
                this.graphicList.add(lableCopy);
                this.activeObject = this.graphicList[this.graphicList.Count - 1];
                this.graphicList[this.graphicList.Count - 1].X += 10;
                this.graphicList[this.graphicList.Count - 1].Y += 10;
                this.graphicList[this.graphicList.Count - 1].Select = true;
                lableCopy = null;
                lableCopy = (drawBase)this.activeObject.Clone();
                this.Refresh();
            }
        }

        public void UpdateActiveObject(Point p)
        {
            try
            {
                int i = graphicList.wichSelect(p);
                if (i != -1)
                {
                    activeObject = graphicList[i];
                }
                Refresh();
            }
            catch { }
        }

        public void ZoomIn()
        {
            zoom *= 0.1f;
            Refresh();
        }

        public void ZoomOut()
        {
            zoom /= 0.1f;
            Refresh();
        }


    }
}
