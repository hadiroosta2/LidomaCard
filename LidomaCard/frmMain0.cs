using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.OleDb;
using System.IO;

namespace LidomaCard
{
    public partial class frmMain0 : Form
    {
        PrintDocument pd;
        DataTable dtExcel;
        public frmMain0()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmCardSetting fcs = new frmCardSetting();
            fcs.DAwidth = drawArea1.Width;
            fcs.DAheight = drawArea1.Height;
            fcs.ShowDialog();
            drawArea1.Width = fcs.DAwidth;
            drawArea1.Height = fcs.DAheight;
            drawArea1.Refresh();
            setControls();
        }
        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            //try
            //{
            //    Graphics g = e.Graphics;
            //    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //    g.SmoothingMode = SmoothingMode.AntiAlias;
            //    g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            //    g.InterpolationMode = InterpolationMode.High;
            //    if (pictureBox1.BackgroundImage != null)
            //    {
            //        g.DrawImage(pictureBox1.BackgroundImage, pictureBox1.Left, pictureBox1.Top, pictureBox1.Width, pictureBox1.Height);

            //    }

            //    if (pictureBox2.BackgroundImage != null)
            //    {
            //        g.DrawImage(pictureBox2.BackgroundImage, pictureBox2.Left, pictureBox2.Top, pictureBox2.Width, pictureBox2.Height);
            //    }

            //    if (pictureBox3.BackgroundImage != null)
            //    {
            //        g.DrawImage(pictureBox3.BackgroundImage, pictureBox3.Left, pictureBox3.Top, pictureBox3.Width, pictureBox3.Height);
            //    }

            //    if (pictureBox4.BackgroundImage != null)
            //    {
            //        g.DrawImage(pictureBox4.BackgroundImage, pictureBox4.Left, pictureBox4.Top, pictureBox4.Width, pictureBox4.Height);
            //    }

            //}
            //catch
            //{
            //    MessageBox.Show("Error 1387 ");
            //}

        }
        private void btnPrintSetting_Click(object sender, EventArgs e)
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
        private void button17_Click(object sender, EventArgs e)
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

        private void button16_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                drawArea1.bImage=Image.FromFile(open.FileName);
                drawArea1.Refresh();
            }
        }
        private void setControls()
        {
            drawArea1.Left = 20;
            drawArea1.Top = 20;
            hRuler.Top = 0;
            hRuler.Left = 20;
            hRuler.StartValue = 0;
            vRuler.Top = 20;
            vRuler.Left = 0;
            vRuler.StartValue = 0;
            hRuler.Width = this.Width;
            vRuler.Height = this.Height;
        }
        private void frmMain0_Load(object sender, EventArgs e)
        {

            setControls();
        }
    }
}