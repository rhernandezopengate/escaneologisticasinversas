using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFALogisticasInversas.Interfaces;
using WFALogisticasInversas.Modelo;
using WFALogisticasInversas.ViewModel;

namespace WFALogisticasInversas.Controlador
{
    public class CajasController : ICajas
    {
        DB_A3F19C_producccionEntities db = new DB_A3F19C_producccionEntities();
        public bool Buscar(string foliocaja)
        {
            try
            {
                li_cajas caja = db.li_cajas.Where(x => x.Folio.Equals(foliocaja)).FirstOrDefault();

                if (caja != null)
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

        public bool Crear(string foliotarima, string foliocaja)
        {
            try
            {
                var tarima = db.li_tarimas.Where(x => x.Folio.Equals(foliotarima)).FirstOrDefault().id;
                li_cajas cajas = new li_cajas();
                cajas.Folio = foliocaja;
                cajas.tarimas_Id = tarima;

                db.li_cajas.Add(cajas);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Editar()
        {
            throw new NotImplementedException();
        }

        public string Folio(string foliotarima)
        {
            try
            {
                var tarima = db.li_tarimas.Where(x => x.Folio.Equals(foliotarima)).FirstOrDefault().id;
                var conteocajas = db.li_cajas.Where(x => x.tarimas_Id.Equals(tarima)).Count();
                
                return foliotarima + "-C" + (conteocajas + 1);
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message.ToString();
            }
        }

        
    }
}
