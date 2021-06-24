using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WFALogisticasInversas.Modelo;
using WFALogisticasInversas.ViewModel;

namespace WFALogisticasInversas.Controlador
{
    public class DetCajasSkuController
    {
        DB_A3F19C_producccionEntities db = new DB_A3F19C_producccionEntities();

        public bool Crear(List<DatosViewModel> listaItems)
        {
            try
            {
                List<li_detcajasskus> listaTemp = new List<li_detcajasskus>();
                foreach (var item in listaItems)
                {
                    li_detcajasskus detalle = new li_detcajasskus();

                    detalle.CajasLI_Id = db.li_cajas.Where(x => x.Folio.Equals(item.codigocaja)).FirstOrDefault().id;
                    detalle.skus_Id = db.skus.Where(x => x.codigobarras.Equals(item.sku)).FirstOrDefault().id;
                    detalle.Cantidad = item.cantidad;

                    listaTemp.Add(detalle);
                }

                db.li_detcajasskus.AddRange(listaTemp);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task AgregarAsincronicamente(DatosViewModel detalle)
        {
            try
            {
                DB_A3F19C_producccionEntities db1 = new DB_A3F19C_producccionEntities();

                int idcaja = await db1.li_cajas.Where(x => x.Folio.Equals(detalle.codigocaja)).Select(x => x.id).FirstOrDefaultAsync();
                int idsku = await db1.skus.Where(x => x.codigobarras.Equals(detalle.sku)).Select(x => x.id).FirstOrDefaultAsync();
                
                await Task.Run(() =>
                {
                    li_detcajasskus detalleTemp = new li_detcajasskus();

                    detalleTemp.CajasLI_Id = idcaja;
                    detalleTemp.skus_Id = idsku;
                    detalleTemp.Cantidad = detalle.cantidad;

                    db1.li_detcajasskus.Add(detalleTemp);

                    db1.SaveChangesAsync();
                });
            }
            catch (Exception _ex)
            {
                await EnviarCorreoError(_ex.Message.ToString());
            }            
        }       

        public async Task EnviarCorreoError(string error) 
        {
            try
            {
                await Task.Run(()=> {

                    var fromAddress = new MailAddress("rhernandez@opengatelogistics.com", "Administrador OG");
                    var toAddress = new MailAddress("rhernandez@opengatelogistics.com", "Ruben Hernandez");
                    const string fromPassword = "L3Qq$J]r8";
                    const string subject = "Error Sistema LI";
                    string body = "Error localizado" + error;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.office365.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.SendMailAsync(message);
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
                      
        public List<DatosViewModel> BucarDatosCaja(string foliocaja)
        {
            try
            {
                var detallecaja = db.li_detcajasskus.Where(x => x.li_cajas.Folio.Equals(foliocaja)).ToList();

                List<DatosViewModel> listaTemp = new List<DatosViewModel>();

                int folio = 1;
                foreach (var item in detallecaja)
                {
                    DatosViewModel datos = new DatosViewModel();
                    datos.folio = folio;
                    datos.cantidad = item.Cantidad;
                    datos.sku = item.skus.codigobarras;
                    datos.codigocaja = item.li_cajas.Folio;
                    datos.descripcion = item.skus.Descripcion;

                    listaTemp.Add(datos);

                    folio++;
                }

                return listaTemp;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool EditarDatosCajas(List<DatosViewModel> listaItems) 
        {
            try
            {
                foreach (var item in listaItems)
                {
                    int idsku = db.skus.Where(x => x.codigobarras.Equals(item.sku)).FirstOrDefault().id;
                    int idcaja = db.li_cajas.Where(x => x.Folio.Equals(item.codigocaja)).FirstOrDefault().id;
                    var detcajassku = db.li_detcajasskus.Where(x => x.skus_Id.Equals(idsku) && x.CajasLI_Id.Equals(idcaja)).FirstOrDefault();

                    if (detcajassku != null)
                    {
                        detcajassku.Cantidad = item.cantidad;                        
                    }
                    else
                    {
                        li_detcajasskus detcajasskutemp = new li_detcajasskus();
                        detcajasskutemp.skus_Id = db.skus.Where(x => x.codigobarras.Equals(item.sku)).FirstOrDefault().id;
                        detcajasskutemp.CajasLI_Id = db.li_cajas.Where(x => x.Folio.Equals(item.codigocaja)).FirstOrDefault().id;
                        detcajasskutemp.Cantidad = item.cantidad;

                        db.li_detcajasskus.Add(detcajasskutemp);
                    }
                }

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }
    }
}
