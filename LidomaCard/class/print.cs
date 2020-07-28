using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace LidomaCard
{
    public class print
    {
        int j = 0;
        int goods;
        bool back = false;
        bool lableBorder = false;
        DrawArea area;
        PrintDocument pd = new PrintDocument();
        PrintDialog pdd = new PrintDialog();
        PrintPreviewDialog pp=new PrintPreviewDialog();
        public void printDoc(DrawArea DA, int count, bool backprint,bool border)
        {
            area = DA;
            goods = count;
            back = backprint;
            lableBorder = border;
            if (pdd.ShowDialog() == DialogResult.OK)
            {
                pd.PrinterSettings = pdd.PrinterSettings;
                pd.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("CUSTOM", DA.Width, DA.Height);
                pd.PrintPage += new PrintPageEventHandler(PD_PRINT);

                pd.Print();
                
            }
        }
        public void printPreview(DrawArea DA, int count, bool backprint,bool border)
        {
            area = DA;
            goods = count;
            back = backprint;
            lableBorder = border;
            pd.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", DA.Width, DA.Height);
            pd.PrintPage += new PrintPageEventHandler(PD_PRINT);
            pp.Document = pd;
            ((Form)pp).WindowState = FormWindowState.Maximized;
            pp.ShowDialog();
         }
        private void PD_PRINT(Object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            
            if (j < goods)
            {
                area.print(g, j, back,lableBorder);
                j++;
                if (j < goods)
                {
                    e.HasMorePages = true;

                }
                else
                {
                    e.HasMorePages = false;

                }
            }
        }
    }

}
