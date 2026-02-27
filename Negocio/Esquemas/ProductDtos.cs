using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Esquemas
{
    public class ProductCreateDto
    {
        public string cNomPro { get; set; }
        public string cDesPro { get; set; }
        public decimal nPrePro { get; set; }
        public int nStoPro { get; set; }
    }

    public class ProductUpdateDto
    {
        public int nIdePro { get; set; }
        public string cNomPro { get; set; }
        public string cDesPro { get; set; }
        public decimal nPrePro { get; set; }
        public int nStoPro { get; set; }
    }

    public class ProductosRQT
    {
        public ProductoCN[] paProductos { get; set; }
    }

    public class ProductosRPT
    {
        public ProductoCN[] paProductos { get; set; }
    }

    public class ProductoCN
    {
        public int pnIdePro { get; set; }
        public string pcNomPro { get; set; }
        public string pcDesPro { get; set; }
        public decimal pnPrePro { get; set; }
        public int pnStoPro { get; set; }
        public DateTime ptFecPro { get; set; }
    }
}
