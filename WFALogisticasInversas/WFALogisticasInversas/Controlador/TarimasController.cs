using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFALogisticasInversas.Interfaces;
using WFALogisticasInversas.Modelo;

namespace WFALogisticasInversas.Controlador
{
    public class TarimasController : ITarimas
    {
        DB_A3F19C_producccionEntities db = new DB_A3F19C_producccionEntities();       

        public bool BuscarTarima(string foliotarima)
        {
            try
            {
                li_tarimas tarimas = db.li_tarimas.Where(x => x.Folio.Equals(foliotarima)).FirstOrDefault();

                if (tarimas != null)
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

        public bool Cerrar(string foliotarima)
        {
            try
            {
                li_tarimas tarima = db.li_tarimas.Where(x => x.Folio.Equals(foliotarima)).FirstOrDefault();

                tarima.statustarimas_Id = 2;

                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Crear(string foliologistica, string foliotarima)
        {
            try
            {
                var logistica = db.logisticainversa.Where(x => x.Folio.Equals(foliologistica)).FirstOrDefault();               

                li_tarimas tarimas = new li_tarimas();
                tarimas.Folio = foliotarima;
                tarimas.logisticainversa_Id = logistica.id;
                tarimas.FechaHoraCreacion = DateTime.Now;
                tarimas.statustarimas_Id = 1;

                db.li_tarimas.Add(tarimas);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string Folio(string foliologistica)
        {
            try
            {
                var logistica = db.logisticainversa.Where(x => x.Folio.Equals(foliologistica)).FirstOrDefault();
                var conteotarimaslogistica = db.li_tarimas.Where(x => x.logisticainversa_Id.Equals(logistica.id)).Count() + 1;

                return foliologistica + "-P" + conteotarimaslogistica;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message.ToString();
            }
        }
    }
}
