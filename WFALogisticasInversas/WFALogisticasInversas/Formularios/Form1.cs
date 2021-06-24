using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFALogisticasInversas.Formularios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImprimirCaja();
        }

        public void ImprimirCaja()
        {
            try
            {
                PrintDocument pd = new PrintDocument();

                pd.PrintPage += new PrintPageEventHandler(ImprimirEtiquetaCaja);
                // Especifica que impresora se utilizara!!
                pd.PrinterSettings.PrinterName = "ZDesigner ZT410-203dpi ZPL";
                PageSettings pa = new PageSettings();
                pa.Margins = new Margins(0, 0, 0, 0);
                pd.DefaultPageSettings.Margins = pa.Margins;
                PaperSize ps = new PaperSize("Custom", 2500, 800);

                pd.DefaultPageSettings.PaperSize = ps;
                pd.DefaultPageSettings.Landscape = true;

                pd.Print();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error al imprimir: " + exp.Message);
            }
        }

        private void ImprimirEtiquetaCaja(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {

                Zen.Barcode.CodeQrBarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;

                var barcodeImage = barcode.Draw("A4-001-02", 100);

                Font font14 = new Font("Arial", 12);

                float leading = 60;

                float startX = 0;
                float startY = leading;
                float Offset = 0;

                float lineheight14 = font14.GetHeight() + leading;

                SizeF layoutSize = new SizeF(780 - Offset * 2, lineheight14);
                RectangleF layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

                Graphics g = e.Graphics;

                Brush brush = Brushes.Black;

                StringFormat formatLeft = new StringFormat(StringFormatFlags.NoClip);
                StringFormat formatCenter = new StringFormat(formatLeft);
                formatCenter.Alignment = StringAlignment.Center;

                g.DrawString("A4-001-02", font14, brush, layout, formatCenter);

                

                g.DrawImage(barcodeImage, 50, 100, 200, 200);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Printpage" + ex.Message);
            }
        }
    }
}
