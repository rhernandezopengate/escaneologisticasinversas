using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFALogisticasInversas.Controlador;
using WFALogisticasInversas.ViewModel;

namespace WFALogisticasInversas.Formularios
{
    public partial class frmScan : Form
    {
        DetCajasSkuController ctrlDetalle = new DetCajasSkuController();
        LogisticaController ctrlLogistica = new LogisticaController();
        TarimasController ctrlTarima = new TarimasController();
        CajasController ctrlCaja = new CajasController();
        SkusController ctrlSKU = new SkusController();        
        List<DatosViewModel> listadatos;

        public frmScan()
        {
            InitializeComponent();
        }

        private void frmScan_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSetOrigen.li_origen' Puede moverla o quitarla según sea necesario.
            this.li_origenTableAdapter.Fill(this.dataSetOrigen.li_origen);
            dgvDatos.AutoGenerateColumns = false;
        }

        private void btnAgregarLogistica_Click(object sender, EventArgs e)
        {
            string folio = ctrlLogistica.Folio(ddlOrigen.Text);

            CrearLogistica(folio);

            listadatos = new List<DatosViewModel>();
            txtScanSKU.Enabled = true;
            dgvDatos.DataSource = listadatos;
            this.txtScanSKU.Focus();
        }

        public void CrearLogistica(string folio) 
        {
            if (ctrlLogistica.Crear(folio, ddlOrigen.Text))
            {
                lblFolioLogisticaUsar.Text = folio;
                CrearTarima(folio);

                MessageBox.Show("SE HA CREADO LA LOGISTICA CORRECTAMENTE", "CREAR LOGISTICA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Error("HA OCURRIDO UN ERROR AL AGREGAR LA LOGISTICA", "AGREGANDO LOGISTICA...");
            }
        }

        public void CrearTarima(string foliologistica) 
        {
            //Folio Tarima
            string foliotarima = ctrlTarima.Folio(foliologistica);

            //Alta Tarima
            if (ctrlTarima.Crear(foliologistica, foliotarima))
            {
                lblFolioTarimaUsar.Text = foliotarima;
                CrearCaja(foliotarima);
                ImprimirTarima();
            }
            else
            {
                Error("HA OCURRIDO UN ERROR AL AGREGAR LA TARIMA", "AGREGANDO TARIMA...");
                lblFolioTarimaUsar.Text = "Error.";
            }
        }

        public void CrearCaja(string foliotarima) 
        {
            string foliocaja = ctrlCaja.Folio(foliotarima);

            if (ctrlCaja.Crear(foliotarima, foliocaja))
            {
                lblFolioCajaUsar.Text = foliocaja;
                ImprimirCaja();
            }
            else
            {
                lblFolioCajaUsar.Text = "Error.";
                Error("HA OCURRIDO UN ERROR AL AGREGAR LA CAJA", "AGREGANDO CAJA...");
            }            
        }

        public async Task AgregarElementos(string sku) 
        {
            DatosViewModel datos = new DatosViewModel();

            string skuvalido = "";
            int cantidad = 0;
            bool skuisvalid = false;

            if (sku.Length.Equals(15))
            {
                sku = sku.Substring(0, 6);
            }
            
            if (ctrlSKU.SkuInventariosValido(sku))
            {
                skuvalido = sku.Trim().ToUpper();
                if (ctrlSKU.cantidadmanual(skuvalido))
                {
                    cantidad = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("TECLEA LA CANTIDAD DE ESTE SKU", "CANTIDAD MANUAL"));
                }
                else
                {
                    cantidad = 1;
                }

                skuisvalid = true;
            }
            else if (ctrlSKU.SkuBenavidesValido(sku))
            {
                skuvalido = ctrlSKU.SkuDesdeBenavides(sku).Trim().ToUpper();

                if (ctrlSKU.cantidadmanual(skuvalido))
                {
                    cantidad = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("TECLEA LA CANTIDAD DE ESTE SKU", "CANTIDAD MANUAL"));
                }
                else
                {
                    cantidad = 1;
                }
                skuisvalid = true;
            }
            else
            {
                Error("ESTE SKU NO EXISTE", "ESCANEANDO SKU...");
            }


            if (skuisvalid)
            {
                datos.cantidad = cantidad;
                datos.sku = skuvalido;
                datos.folio = listadatos.Count() + 1;
                datos.codigocaja = this.lblFolioCajaUsar.Text;
                datos.descripcion = await ctrlSKU.NombreSku(skuvalido);

                await ctrlDetalle.AgregarAsincronicamente(datos);

                listadatos.Add(datos);              
            }        
                        
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = listadatos.OrderByDescending(x => x.folio).ToList();
            txtScanSKU.Focus();            
        }

        private void txtScanSKU_KeyPress(object sender, KeyPressEventArgs e)
        {
            string sku = this.txtScanSKU.Text;
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (sku.Equals(string.Empty))
                {
                    Error("NO SE PERMITEN VALORES VACIOS", "ESCANEANDO SKU...");
                    this.txtScanSKU.Text = "";
                }
                else
                {
                    txtScanSKU.Text = "";
                    AgregarElementos(sku);                    
                }

                e.Handled = true;
            }
        }
        
        private void btnTarima_Click(object sender, EventArgs e)
        {
            if (this.lblFolioTarimaUsar.Text.Equals("NO HAY MAS TARIMAS"))
            {
                Error("NO HAY UNA TARIMA SELECCIONADA", "CERRANDO TARIMA...");
            }
            else
            {
                string nueva = "";
                if (ctrlTarima.Cerrar(this.lblFolioTarimaUsar.Text))
                {
                    MessageBox.Show("SE HA CERRADO LA TARIMA CORRECTAMENTE", "CERRANDO TARIMA...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    nueva = Microsoft.VisualBasic.Interaction.InputBox("DESEA AGREGAR UNA NUEVA TARIMA \n (Y) -> SI \n (N)-> NO", "CERRANDO TARIMA...");

                    if (nueva.Trim().ToUpper().Equals("Y"))
                    {
                        CrearTarima(this.lblFolioLogisticaUsar.Text);
                        this.txtScanSKU.Focus();
                    }
                    else
                    {
                        this.lblFolioTarimaUsar.Text = "NO HAY MAS TARIMAS";
                    }
                }
                else
                {
                    Error("HA OCURRIDO UN ERROR AL GUARDAR LA TARIMA", "CERRANDO TARIMA...");
                }
            }           
        }

        public void Error(string mensaje,  string encabezado) 
        {
            string respuesta = "";

            do
            {
                SystemSounds.Asterisk.Play();
                respuesta = Microsoft.VisualBasic.Interaction.InputBox("ERROR: " + mensaje + "\n\n COLOQUE OK PARA CONTINUAR", encabezado);                
            } while (respuesta.Trim().ToUpper() != "OK");
        }

        private void btnCerrarLogistica_Click(object sender, EventArgs e)
        {
            if (this.lblFolioLogisticaUsar.Text.Equals("NO HAY LOGISTICA"))
            {
                Error("NO HAY UNA LOGISTICA SELECCIONADA", "CERRANDO LOGISTICA...");
            }
            else
            {
                if (ctrlLogistica.Cerrar(this.lblFolioLogisticaUsar.Text))
                {
                    MessageBox.Show("SE HA CERRADO EXITOSAMENTE LA LOGISTICA", "CERRANDO TARIMA...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.lblFolioLogisticaUsar.Text = "NO HAY LOGISTICA";
                    Limpiar();
                }
                else
                {
                    Error("HA OCURRIDO UN ERROR AL CERRAR LA LOGISTICA", "CERRANDO LOGISTICA...");
                }
            }
        } 

        private void btnContinuarCaja_Click(object sender, EventArgs e)
        {
            string busqueda = Microsoft.VisualBasic.Interaction.InputBox("ESCANEAR CODIGO DE CAJA QUE DESEA CONTINUAR", "BUSCANDO CAJA");
            string logistica = "";
            string tarima = "";

            if (ctrlCaja.Buscar(busqueda))
            {                
                if (busqueda.Contains("MODATELAS") || busqueda.ToUpper().Contains("BENAVIDES"))
                {
                    logistica = busqueda.Substring(0, 17);
                    
                    if (busqueda.Length >= 23) 
                    {
                        tarima = busqueda.Substring(0, 20);
                    }
                    else
                    {
                        tarima = busqueda.Substring(0, 19);
                    }
                }
                else
                {
                    logistica = busqueda.Substring(0, 13);

                    if (busqueda.Length >= 20)
                    {
                        tarima = busqueda.Substring(0, 17);
                    }
                    else
                    {
                        tarima = busqueda.Substring(0, 16);
                    }
                }
                
                if (ctrlLogistica.BusquedaStatus(logistica))
                {                    

                    int origen = ctrlLogistica.OrigenLogistica(logistica);

                    if (origen > 0)
                    {
                        this.lblFolioLogisticaUsar.Text = logistica.Trim().ToUpper();
                        this.lblFolioTarimaUsar.Text = tarima.Trim().ToUpper();
                        this.lblFolioCajaUsar.Text = busqueda.Trim().ToUpper();
                        ddlOrigen.SelectedValue = origen;
                        this.txtScanSKU.Enabled = true;
                        this.txtScanSKU.Focus();
                        this.lblOperacionActualUsar.Text = "EDITANDO";

                        listadatos = ctrlDetalle.BucarDatosCaja(busqueda);
                        dgvDatos.DataSource = null;
                        dgvDatos.DataSource = listadatos.OrderByDescending(x => x.folio).ToList();
                    }
                    else
                    {
                        Error("ORIGEN MAL CONSULTADO", "ERROR DE CONSULTA");
                    }
                }
                else
                {
                    Error("LA LOGISTICA QUE DESEA CONTINUAR ESTA CERRADA", "BUSCANDO LOGISTICA...");
                }                
            }
            else
            {
                Error("ESTA CAJA NO EXISTE", "BUSCANDO CAJA...");
            }
        }

        public void Limpiar() 
        {
            this.lblFolioLogisticaUsar.Text = "NO HAY LOGISTICA";
            this.lblFolioTarimaUsar.Text = "NO HAY MAS TARIMAS";
            this.lblFolioCajaUsar.Text = "NO HAY MAS CAJAS";
            dgvDatos.DataSource = null;
            listadatos = null;
            listadatos = new List<DatosViewModel>();
            this.txtScanSKU.Enabled = false;
            this.lblOperacionActualUsar.Text = "CREANDO";
            this.lblReImprimirUsar.Text = "Reimprimir";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();            
        }

        private void btnCajas_Click(object sender, EventArgs e)
        {
            if (this.lblFolioCajaUsar.Text.Equals("NO HAY MAS CAJAS"))
            {
                Error("NO HAY UNA CAJA SELECCIONADA", "CERRANDO CAJA...");
            }
            else
            {
                //if (this.lblOperacionActualUsar.Text.Equals("CREANDO"))
                //{

                //    if (ctrlDetalle.Crear(listadatos))
                //    {
                //        MessageBox.Show("SE HA CERRADO LA CAJA CORRECTAMENTE", "CERRANDO CAJA...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    else
                //    {
                //        Error("HA OCURRIDO UN ERROR AL AGREGAR LA CAJA", "CERRANDO CAJA...");
                //    }
                //}
                //else if (this.lblOperacionActualUsar.Text.Equals("EDITANDO"))
                //{
                //    if (ctrlDetalle.EditarDatosCajas(listadatos))
                //    {
                //        MessageBox.Show("SE HA CERRADO LA CAJA CORRECTAMENTE", "CERRANDO CAJA...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    else
                //    {
                //        Error("HA OCURRIDO UN ERROR AL EDITAR LA CAJA", "CERRANDO CAJA...");
                //    }
                //}                

                string nueva = Microsoft.VisualBasic.Interaction.InputBox("DESEA AGREGAR UNA NUEVA CAJA \n (Y) -> SI \n (N)-> NO", "CERRANDO CAJA...");

                if (nueva.Trim().ToUpper().Equals("Y"))
                {
                    CrearCaja(this.lblFolioTarimaUsar.Text);
                }
                else
                {
                    this.lblFolioCajaUsar.Text = "NO HAY MAS CAJAS";
                }

                dgvDatos.DataSource = null;
                listadatos = new List<DatosViewModel>();
                this.txtScanSKU.Focus();
            }
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

                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                var barcodeImage = barcode.Draw(this.lblFolioCajaUsar.Text, 100);

                Font font14 = new Font("Arial", 25);

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

                g.DrawString(this.lblFolioCajaUsar.Text + "\n", font14, brush, layout, formatCenter);

                g.DrawImage(barcodeImage, 130, 150, 500, 150);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Printpage" + ex.Message);
            }
        }

        public void ImprimirTarima()
        {
            try
            {
                PrintDocument pd = new PrintDocument();

                pd.PrintPage += new PrintPageEventHandler(ImprimirEtiquetaTarima);
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

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            string codigobuscar = Microsoft.VisualBasic.Interaction.InputBox("TECLEAR EL CODIGO QUE DESEA REIMPRIMIR", "REIMPRIMIENDO ETIQUETA...");

            string codigoformato = codigobuscar.Trim().ToUpper();
           
            if (ctrlCaja.Buscar(codigoformato))
            {
                lblReImprimirUsar.Text = codigoformato;
                ReImprimirEtiqueta();
            }
            else
            {
                if (ctrlTarima.BuscarTarima(codigoformato))
                {
                    lblReImprimirUsar.Text = codigoformato;
                    ReImprimirEtiqueta();
                }
                else
                {
                    Error("ESTA ETIQUETA NO EXISTE EN LA BASE DE DATOS", "REIMPRIMIENDO ETIQUETA");
                }
            }
        }

        private void ImprimirEtiquetaTarima(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {

                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                var barcodeImage = barcode.Draw(this.lblFolioTarimaUsar.Text, 100);

                Font font14 = new Font("Arial", 25);

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

                g.DrawString(this.lblFolioTarimaUsar.Text + "\n", font14, brush, layout, formatCenter);

                g.DrawImage(barcodeImage, 130, 150, 500, 150);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Printpage" + ex.Message);
            }
        }

        public void ReImprimirEtiqueta()
        {
            try
            {
                PrintDocument pd = new PrintDocument();

                pd.PrintPage += new PrintPageEventHandler(ReImprimirEtiqueta);
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

        private void ReImprimirEtiqueta(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {

                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                var barcodeImage = barcode.Draw(this.lblReImprimirUsar.Text, 100);

                Font font14 = new Font("Arial", 25);

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

                g.DrawString(this.lblReImprimirUsar.Text + "\n", font14, brush, layout, formatCenter);

                g.DrawImage(barcodeImage, 130, 150, 500, 150);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Printpage" + ex.Message);
            }
        }
    }
}
