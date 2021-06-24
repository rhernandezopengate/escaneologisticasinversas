using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFALogisticasInversas.Interfaces;
using WFALogisticasInversas.Modelo;

namespace WFALogisticasInversas.Controlador
{
    public class SkusController : ISKU
    {
		DB_A3F19C_producccionEntities db = new DB_A3F19C_producccionEntities();

        public bool SkuInventariosValido(string sku)
        {
			try
			{
				var skusinventarios = db.skusinventarios.Where(x => x.skus.codigobarras.Equals(sku)).FirstOrDefault();

				if (skusinventarios != null)
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

		public bool SkuBenavidesValido(string sku)
		{
			try
			{
				var codigo = sku.Trim().ToUpper();
				var skusbenavides = db.skusbenavides.Where(x => x.codigobarras.Equals(sku)).FirstOrDefault();

				if (skusbenavides != null)
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

		public string SkuDesdeBenavides(string sku) 
		{
			try
			{
				var skusbenavides = db.skusbenavides.Where(x => x.codigobarras.Equals(sku)).FirstOrDefault();
				var valorsku = db.skus.Where(x => x.id.Equals(skusbenavides.skus_Id)).FirstOrDefault();
				return valorsku.codigobarras;
			}
			catch (Exception)
			{
				return "";
			}
		}

		public bool cantidadmanual(string sku)
		{
			try
			{
				var skusinventarios = db.skusinventarios.Where(x => x.skus.codigobarras.Equals(sku)).FirstOrDefault();

				if (skusinventarios.qtymanual == true)
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

		public async Task<string> NombreSku(string sku) 
		{
			try
			{
				DB_A3F19C_producccionEntities db1 = new DB_A3F19C_producccionEntities();
				string nombre = await db1.skus.Where(x => x.codigobarras == sku).Select(x => x.Descripcion).FirstOrDefaultAsync();
				return nombre;
			}
			catch (Exception)
			{
				return "";
			}
		}
	}
}
