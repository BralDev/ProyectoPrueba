using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Esquemas
{
    public class ProductoCrearRQT
    {
        public string pcNomPro { get; set; }
        public string pcDesPro { get; set; }
        public decimal pnPrePro { get; set; }
        public int pnStoPro { get; set; }
    }

    public class ProductoCrearRPT 
    {
        public int pnIdePro { get; set; }
        public string pcNomPro { get; set; }
        public string pcDesPro { get; set; }
        public decimal pnPrePro { get; set; }
        public int pnStoPro { get; set; }
        public DateTime ptFecPro { get; set; }
    }

    public class ProductoActualizarRQT
    {
        public int pnIdePro { get; set; }
        public string pcNomPro { get; set; }
        public string pcDesPro { get; set; }
        public decimal pnPrePro { get; set; }
        public int pnStoPro { get; set; }
    }

    public class ProductoActualizarRPT
    {
        public int pnIdePro { get; set; }
        public string pcNomPro { get; set; }
        public string pcDesPro { get; set; }
        public decimal pnPrePro { get; set; }
        public int pnStoPro { get; set; }
        public DateTime ptFecPro { get; set; }
    }

    public class ProductoListCN
    {
        public int pnIdePro { get; set; }
        public string pcNomPro { get; set; }
        public string pcDesPro { get; set; }
        public decimal pnPrePro { get; set; }
        public int pnStoPro { get; set; }
        public DateTime ptFecPro { get; set; }
    }

    public class ProductosListRQT
    {
        public ProductoListCN[] paProductos { get; set; }
    }

    public class ProductosListRPT
    {
        public ProductoListCN[] paProductos { get; set; }
    }
    
}
