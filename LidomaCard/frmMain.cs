using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace LidomaCard
{
    public partial class frmMain : Form
    {
        PictureBox active = null;
        bool key = false;
        int index;
        PrintDocument pd;
        DataTable dtExcel;
        List<string> imageFiles;
        graphicList gl;
        public frmMain()
        {
            InitializeComponent();
            gl = new graphicList();
            
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                key = true;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            active = (PictureBox)sender;
            if (key)
            {
                active.BackgroundImage = null;
                key = false;
            }
            numericUpDown1.Value = Convert.ToInt32(active.Width );
            numericUpDown2.Value = Convert.ToInt32(active.Height );
            numericUpDown3.Value = Convert.ToInt32(active.Left );
            numericUpDown4.Value = Convert.ToInt32(active.Top );
            this.Refresh();
            
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                active.BackgroundImage = Image.FromFile(open.FileName);
            }
        }   

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (active != null)
            {
                Graphics g = this.CreateGraphics();
              //  g.PageUnit = GraphicsUnit.Millimeter;
                g.DrawRectangle(new Pen(new SolidBrush(Color.Red), 4), new Rectangle(active.Location.X, active.Location.Y, active.Size.Width, active.Size.Height));
               
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Properties.Settings.Default.Save();
            //pd = new PrintDocument();
            //pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            //PrintDialog print = new PrintDialog();
            //print.UseEXDialog = true;
            //if (print.ShowDialog() == DialogResult.OK)
            //{
            //    pd.PrinterSettings = print.PrinterSettings;
                pd.Print();
            //}
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.InterpolationMode = InterpolationMode.High;
                if (pictureBox1.BackgroundImage != null)
                {
                    g.DrawImage(pictureBox1.BackgroundImage, pictureBox1.Left, pictureBox1.Top, pictureBox1.Width, pictureBox1.Height);
                    
                }

                if (pictureBox2.BackgroundImage != null)
                {
                    g.DrawImage(pictureBox2.BackgroundImage, pictureBox2.Left, pictureBox2.Top, pictureBox2.Width, pictureBox2.Height);
                }

                if (pictureBox3.BackgroundImage != null)
                {
                    g.DrawImage(pictureBox3.BackgroundImage, pictureBox3.Left, pictureBox3.Top, pictureBox3.Width, pictureBox3.Height);
                }

                if (pictureBox4.BackgroundImage != null)
                {
                    g.DrawImage(pictureBox4.BackgroundImage, pictureBox4.Left, pictureBox4.Top, pictureBox4.Width, pictureBox4.Height);
                }
                 
            }
            catch
            {
                MessageBox.Show("Error 1387 ");
            }
            
        }

        private void —«Â„ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCardSetting help = new frmCardSetting();
            help.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            index = 0;
            label8.Text = index.ToString();
           imageFiles = new List<string>();
           active = pictureBox1;
           pictureBox1.Left = Properties.Settings.Default.p1x;
           pictureBox1.Top = Properties.Settings.Default.p1y;
           pictureBox1.Width = Properties.Settings.Default.p1w;
           pictureBox1.Height = Properties.Settings.Default.p1h;
            //----------
           pictureBox2.Left = Properties.Settings.Default.p2x;
           pictureBox2.Top = Properties.Settings.Default.p2y;
           pictureBox2.Width = Properties.Settings.Default.p2w;
           pictureBox2.Height = Properties.Settings.Default.p2h;
          // ----------
           pictureBox3.Left = Properties.Settings.Default.p3x;
           pictureBox3.Top = Properties.Settings.Default.p3y;
           pictureBox3.Width = Properties.Settings.Default.p3w;
           pictureBox3.Height = Properties.Settings.Default.p3h;
           // ----------
           pictureBox4.Left = Properties.Settings.Default.p4x;
           pictureBox4.Top = Properties.Settings.Default.p4y;
           pictureBox4.Width = Properties.Settings.Default.p4w;
           pictureBox4.Height = Properties.Settings.Default.p4h;


           numericUpDown1.Value = Convert.ToInt32(active.Width);
           numericUpDown2.Value = Convert.ToInt32(active.Height);
           numericUpDown3.Value = Convert.ToInt32(active.Left );
           numericUpDown4.Value = Convert.ToInt32(active.Top );

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
             Properties.Settings.Default.p1x= pictureBox1.Left ;
             Properties.Settings.Default.p1y=pictureBox1.Top ;
             Properties.Settings.Default.p1w= pictureBox1.Width ;
             Properties.Settings.Default.p1h=pictureBox1.Height ;
            //----------
            Properties.Settings.Default.p2x= pictureBox2.Left ;
             Properties.Settings.Default.p2y=pictureBox2.Top ;
             Properties.Settings.Default.p2w=pictureBox2.Width ;
             Properties.Settings.Default.p2h=pictureBox2.Height ;
            // ----------
             Properties.Settings.Default.p3x=pictureBox3.Left ;
             Properties.Settings.Default.p3y=pictureBox3.Top ;
            Properties.Settings.Default.p3w=pictureBox3.Width ;
             Properties.Settings.Default.p3h=pictureBox3.Height ;
            // ----------
            Properties.Settings.Default.p4x=pictureBox4.Left ;
             Properties.Settings.Default.p4y=pictureBox4.Top ;
             Properties.Settings.Default.p4w=pictureBox4.Width ;
             Properties.Settings.Default.p4h=pictureBox4.Height ;

            Properties.Settings.Default.Save();
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            active.Width =Convert.ToInt32(numericUpDown1.Value) ;
            this.Refresh();
        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {
            active.Height = Convert.ToInt32(numericUpDown2.Value);
            this.Refresh();
        }

        private void numericUpDown3_ValueChanged_1(object sender, EventArgs e)
        {
            active.Left = Convert.ToInt32(numericUpDown3.Value);
            this.Refresh();
        }

        private void numericUpDown4_ValueChanged_1(object sender, EventArgs e)
        {
            active.Top = Convert.ToInt32(numericUpDown4.Value) ;
            this.Refresh();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete)
            {
                active.BackgroundImage = null;
                this.Refresh();
            }
            if (keyData == (Keys.Control | Keys.V))
            {
                active.BackgroundImage = Clipboard.GetImage();
            }
            if (keyData == (Keys.Control | Keys.C))
            {
                if(active.BackgroundImage!=null)
                Clipboard.SetImage(active.BackgroundImage);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
               string[] files = Directory.GetFiles(fd.SelectedPath, "*", SearchOption.TopDirectoryOnly);
                foreach (string filename in files)
                {
                    if (Regex.IsMatch(filename, @".jpg|.png|.gif$"))
                        imageFiles.Add(filename);
                }
                setImage();
                label8.Text = ((index / 4) + 1).ToString();
                label10.Text = imageFiles.Count.ToString();
            }
        }

        private void setImage()
        {
            pictureBox1.BackgroundImage = null;
            pictureBox2.BackgroundImage = null;
            pictureBox3.BackgroundImage = null;
            pictureBox4.BackgroundImage = null;
            if (imageFiles.Count > index)
                pictureBox1.BackgroundImage = Image.FromFile(imageFiles[index]);
            if (imageFiles.Count > index + 1)
                pictureBox2.BackgroundImage = Image.FromFile(imageFiles[index + 1]);
            if (imageFiles.Count > index + 2)
                pictureBox3.BackgroundImage = Image.FromFile(imageFiles[index + 2]);
            if (imageFiles.Count > index + 3)
                pictureBox4.BackgroundImage = Image.FromFile(imageFiles[index + 3]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (index+4 < imageFiles.Count)
            {
                index += 4;
                setImage();
                label8.Text = ((index / 4) + 1).ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (index - 4 >= 0)
            {
                index -= 4;
                setImage();
                label8.Text = ((index / 4) + 1).ToString();
            }
           
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Left=14;
            pictureBox1.Top = 34;
            pictureBox1.Width = 382;
            pictureBox1.Height = 242;
            pictureBox2.Left = 418;
            pictureBox2.Top = 34;
            pictureBox2.Width = 382;
            pictureBox2.Height = 242;
            pictureBox3.Left = 14;
            pictureBox3.Top = 283;
            pictureBox3.Width = 382;
            pictureBox3.Height = 242;
            pictureBox4.Left = 418;
            pictureBox4.Top = 283;
            pictureBox4.Width = 382;
            pictureBox4.Height = 242;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap m = new Bitmap(2480,3508);
                m.SetResolution(300, 300);
                Graphics g = Graphics.FromImage(m);
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.InterpolationMode = InterpolationMode.High;
                if (pictureBox1.BackgroundImage != null)
                {
                    g.DrawImage(pictureBox1.BackgroundImage, pictureBox1.Left, pictureBox1.Top, pictureBox1.Width, pictureBox1.Height);

                }

                if (pictureBox2.BackgroundImage != null)
                {
                    g.DrawImage(pictureBox2.BackgroundImage, pictureBox2.Left, pictureBox2.Top, pictureBox2.Width, pictureBox2.Height);
                }

                if (pictureBox3.BackgroundImage != null)
                {
                    g.DrawImage(pictureBox3.BackgroundImage, pictureBox3.Left, pictureBox3.Top, pictureBox3.Width, pictureBox3.Height);
                }

                if (pictureBox4.BackgroundImage != null)
                {
                    g.DrawImage(pictureBox4.BackgroundImage, pictureBox4.Left, pictureBox4.Top, pictureBox4.Width, pictureBox4.Height);
                }
                Clipboard.SetImage(m);

            }
            catch
            {
                MessageBox.Show("Error 1387 ");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            PrintDialog print = new PrintDialog();
            print.UseEXDialog = true;
            if (print.ShowDialog() == DialogResult.OK)
            {
                pd.PrinterSettings = print.PrinterSettings;
               
            }
        }

        public DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)//compare the extension of the file
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';";//for below excel 2007
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";//for above excel 2007
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con);//here we read data from sheet1
                    oleAdpt.Fill(dtexcel);//fill excel data into dataTable
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            return dtexcel;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog();//open dialog to choose file
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)//if there is a file choosen by the user
            {
                filePath = file.FileName;//get the path of the file
                fileExt = Path.GetExtension(filePath);//get the file extension
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {

                        dtExcel = ReadExcel(filePath, fileExt);//read excel file
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);//custom messageBox to show error
                }
            }
            frmExcelTable frmExcel = new frmExcelTable(dtExcel);
            frmExcel.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textLable tl = new textLable();
            tl.text = "persia";
            gl.add(tl);
            Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            gl.draw(g);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            gl.remove();
            Refresh();
        }
        
    }
}