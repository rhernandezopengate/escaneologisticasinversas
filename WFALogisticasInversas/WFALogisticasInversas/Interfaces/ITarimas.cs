using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFALogisticasInversas.Interfaces
{
    public interface ITarimas
    {
        string Folio(string foliologistica);

        bool Crear(string foliologistica, string foliotarima);

        bool BuscarTarima(string foliotarima);

        bool Cerrar(string foliotarima);
    }
}
