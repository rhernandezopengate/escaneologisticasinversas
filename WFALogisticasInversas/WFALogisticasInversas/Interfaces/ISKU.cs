using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFALogisticasInversas.Interfaces
{
    public interface ISKU
    {
        bool SkuInventariosValido(string sku);

        bool SkuBenavidesValido(string sku);
    }
}
