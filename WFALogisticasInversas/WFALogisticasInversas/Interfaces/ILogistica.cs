using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFALogisticasInversas.Interfaces
{
    public interface ILogistica
    {
        string Folio(string origen); 

        bool Crear(string folio, string origen);

        bool BusquedaStatus(string folio);
    }
}
