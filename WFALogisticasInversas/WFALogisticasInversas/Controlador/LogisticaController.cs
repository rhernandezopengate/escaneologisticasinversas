using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFALogisticasInversas.Interfaces;
using WFALogisticasInversas.Modelo;

namespace WFALogisticasInversas.Controlador
{
    public class LogisticaController : ILogistica
    {
        DB_A3F19C_producccionEntities db = new DB_A3F19C_producccionEntities();

        public string Folio(string origen) 
        {
            try
            {
                var conteo = db.logisticainversa.Count();
                string nomenclatura = "OGLI-" + (conteo + 1) + "-" + origen;

                return nomenclatura;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public bool BusquedaStatus(string folio)
        {
            try
            {
                logisticainversa logistica = db.logisticainversa.Where(x => x.Folio.Equals(folio)).FirstOrDefault();
                
                if (logistica.statuslogisticasinversas_Id == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Crear(string folio, string origen)
        {
            try
            {
                logisticainversa logisticainversa = new logisticainversa();
                logisticainversa.FechaAlta = DateTime.Now;
                logisticainversa.statuslogisticasinversas_Id = 1;
                logisticainversa.Folio = folio;
                logisticainversa.origenlogistica_id = db.li_origen.Where(x => x.descripcion.Equals(origen)).FirstOrDefault().id;

                db.logisticainversa.Add(logisticainversa);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Cerrar(string foliologistica) 
        {
            try
            {
                logisticainversa logisticainversa = db.logisticainversa.Where(x => x.Folio.Equals(foliologistica)).FirstOrDefault();
                logisticainversa.statuslogisticasinversas_Id = 2;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int OrigenLogistica(string folio)
        {
            try
            {
                logisticainversa logistica = db.logisticainversa.Where(x => x.Folio.Equals(folio)).FirstOrDefault();

                return logistica.origenlogistica_id;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
