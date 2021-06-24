using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFALogisticasInversas.ViewModel
{
    public class DatosViewModel
    {
        public int folio { get; set; }
        
        public string sku { get; set; }
        
        public string descripcion { get; set; }

        public int cantidad { get; set; }

        public string codigocaja { get; set; }
    }
}
