using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFALogisticasInversas.Interfaces
{
    public interface ICajas
    {
        string Folio(string foliotarima);
        
        bool Crear(string foliotarima, string foliocaja);        

        bool Buscar(string foliocaja);

        bool Editar();
    }
}
