using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LidomaCard
{
    [Serializable]
    public abstract class drawBase : INotifyPropertyChanged,ICloneable
    {
       
        string text;
        bool n2s = false;
        string fontName;
        float fontSize;
        Color fontColor;
        int zeroNumber;
        private int width;
        private int height;
        private int x, y;
        private bool select;
        protected int rotate;
        PointF rotatePoint;
        bool transparent = false;
        bool boldFont = false;
        FontStyle style;
       
        int freeze, freezeLabelNumber;
        string freezeText;
        string barcodeText;
        Color backBar, forBar;
        bool showBarText;
        bool whichObject;
        string barcodeType;
        string logoImage;
        bool colorState;
        bool strAvi;
        bool fontItalic;
        int alignment;
        bool doExport;
        bool reversed;
        bool mirror1, mirror2;
        string barcodeFontName;
        int barcodeFontSize;

        public int BarcodeFontSize
        {
            get { return barcodeFontSize; }
            set
            {
                barcodeFontSize = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("BarcodeFontSize"));
            }
        }

        public string BarcodeFontName
        {
            get { return barcodeFontName; }
            set
            {
                barcodeFontName = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("BarcodeFontName"));
            }
        }

        public bool Mirror2
        {
            get { return mirror2; }
            set
            {
                mirror2 = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Mirror2"));
            }
        }

        public bool Mirror1
        {
            get { return mirror1; }
            set
            {
                mirror1 = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Mirror1"));
            }
        }

        public bool Reversed
        {
            get { return reversed; }
            set
            {
                reversed = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Reversed"));
            }
        }

        public bool DoExport
        {
            get { return doExport; }
            set
            {
                doExport = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("DoExport"));
            }
        }

        public int ObjectAlignment
        {
            get { return alignment; }
            set
            {
                alignment = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("ObjectAlignment"));
            }
        }

        public bool FontItalic
        {
            get { return fontItalic; }
            set
            {
                fontItalic = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("FontItalic"));
            }
        }

        public bool StrAv
        {
            get { return strAvi; }
            set
            {
                strAvi = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("StrAv"));
            }
        }

        internal bool ColorState
        {
            get { return colorState; }
            set
            {
                colorState = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("ColorState"));
            }
        }

        public string LogoImage
        {
            get { return logoImage; }
            set
            {
                logoImage = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("LogoImage"));
            }
        }

        public string BarCodeType
        {
            get { return barcodeType; }
            set
            {
                barcodeType = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("BarCodeType"));
            }
        }

        public string BarcodeText
        {
            get { return barcodeText; }
            set
            {
                barcodeText = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("BarcodeText"));
            }
        }

        public Color BackBar
        {
            get { return backBar; }
            set
            {
                backBar = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("BackBar"));
            }
        }

        public Color ForBar
        {
            get { return forBar; }
            set
            {
                forBar = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("ForBar"));
            }
        }

        public bool ShowBarcodeText
        {
            get { return showBarText; }
            set
            {
                showBarText = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("ShowBarcodeText"));
            }
        }

        public bool WhichObject
        {
            get { return whichObject; }
            set
            {
                whichObject = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("WhichObject"));
            }
        }


        public FontStyle Style
        {
            get
            {
                return style;
            }
            set
            {
                style = value;
            }
        }
        public virtual void print(DrawArea drawArea,Graphics g, int j,bool border)
        {
        }
        public virtual void onKeyPress(DrawArea drawArea,KeyPressEventArgs e)
        {

        }
        public virtual void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {

        }
        public virtual void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {

        }
        public virtual void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {

        }
        public virtual void OnKeyDown(DrawArea drawArea, KeyEventArgs e)
        {

        }
        public virtual void Draw(DrawArea drawArea, System.Drawing.Graphics g, float zoom)
        {

        }
      


        public virtual int HitTest(Point point)
        {
            return 1;
        }
        public virtual string name()
        {
            return "lodoma";
        }
        public object Clone()
        {
            return this.MemberwiseClone();

        }
        #region aline
        public void CenterScreenObject(DrawArea area)
        {
            X = area.Width / 2 - Width / 2;
        }

        public void RightScreenObject(DrawArea area)
        {
            X = area.Width - 30 - Width;
        }

        public void LeftScreenObject(DrawArea area)
        {
            X = 30;
        }

        #endregion

        #region propertis

        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;

            }
        }

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;

            }
        }
        public bool Transparent
        {
            get
            {
                return transparent;
            }
            set
            {
                transparent = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Transparent"));
            }
        }

        public bool BoldFont
        {
            get { return boldFont; }
            set
            {
                boldFont = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("BoldFont"));
            }
        }

        public int Freeze
        {
            get { return freeze; }
            set
            {
                freeze = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Freeze"));
            }
        }

        public int FreezeLabelNumber
        {
            get { return freezeLabelNumber; }
            set
            {
                freezeLabelNumber = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("FreezeLabelNumber"));
            }
        }

       

        public int Rotate
        {
            get
            {
                return rotate;
            }
            set
            {

                rotate = value;
                if (rotate >= 360)
                    rotate = rotate - 360;
                InvokePropertyChanged(new PropertyChangedEventArgs("Rotate"));
            }
        }

        public PointF RotatePoint
        {
            get
            {
                return rotatePoint;
            }
            set
            {
                rotatePoint = value;
            }
        }
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("X"));
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Y"));
            }

        }
        public bool Select
        {
            get
            {
                return select;
            }
            set
            {
                select = value;

            }
        }

        public string FontName
        {
            get
            {
                return fontName;
            }
            set
            {
                fontName = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("FontName"));
            }
        }

        public Color FontColor
        {
            get
            {
                return fontColor;
            }
            set
            {
                fontColor = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("FontColor"));
            }
        }

        public float FontSize
        {
            get
            {
                return fontSize;
            }
            set
            {
                fontSize = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("FontSize"));
            }
        }

        public string FreezeText
        {
            get { return freezeText; }
            set
            {
                freezeText = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("FreezeText"));
            }
        }

        public int ZeroNumber
        {
            get
            {
                return zeroNumber;
            }
            set
            {
                zeroNumber = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("ZeroNumber"));
            }
        }

        public virtual string Text
        {
            get
            {

                return text;
            }
            set
            {
                text = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Text"));
            }
        }

        public bool N2S
        {
            get
            {
                return n2s;
            }
            set
            {
                n2s = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("N2S"));
            }
        }
        #endregion

        #region interface function

        [field: NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            try
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
            catch
            {
                try
                {
                    PropertyChangedEventHandler handle = PropertyChanged;
                    handle(this, e);
                }
                catch
                {
                    return;
                }
            }
        }

        #endregion
    }
}
