using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsquemaMAUI.Esquemas
{
    public class StatusBase
    {
        public int pnCodigo { get; set; }
        public string pcMensaje { get; set; }
    }
  
    public class ProductoListaModel
    {
        public int pnIdePro { get; set; }
        public string pcNomPro { get; set; }
        public string pcDesPro { get; set; }
        public decimal pnPrePro { get; set; }
        public int pnStoPro { get; set; }
        public int pnIdeSed { get; set; }
        public DateTime ptFecPro { get; set; }
    }

    public class ProductosListRPT : StatusBase
    {
        public ProductoListaModel[] paProductos { get; set; }
    }
    
    public class ProductoCrearRQT
    {
        public string pcNomPro { get; set; }
        public string pcDesPro { get; set; }
        public decimal pnPrePro { get; set; }
        public int pnStoPro { get; set; }
        public int pnIdeSed { get; set; }
    }

    public class ProductoCrearRPT : StatusBase
    {
        public int pnIdePro { get; set; }
        public string pcNomPro { get; set; }
        public string pcDesPro { get; set; }
        public decimal pnPrePro { get; set; }
        public int pnStoPro { get; set; }
        public int pnIdeSed { get; set; }
        public DateTime ptFecPro { get; set; }
    }
    
    public class ProductoActualizarRQT
    {
        public int pnIdePro { get; set; }
        public string pcNomPro { get; set; }
        public string pcDesPro { get; set; }
        public decimal pnPrePro { get; set; }
        public int pnStoPro { get; set; }
        public int pnIdeSed { get; set; }
    }

    public class ProductoActualizarRPT : StatusBase
    {
        public int pnIdePro { get; set; }
        public string pcNomPro { get; set; }
        public string pcDesPro { get; set; }
        public decimal pnPrePro { get; set; }
        public int pnStoPro { get; set; }
        public int pnIdeSed { get; set; }
        public DateTime ptFecPro { get; set; }
    }
    
    public class ProductoEliminarRQT
    {
        public int pnIdePro { get; set; }
    }

    public class ProductoEliminarRPT : StatusBase
    {
        public int pnIdePro { get; set; }
    }

    public class ProductoTrasladarRQT
    {
        public int pnIdeProOrigen { get; set; }
        public int pnCanTraslado { get; set; }
        public int pnIdeSedDestino { get; set; }
    }

    public class ProductoTrasladarRPT : StatusBase
    {
        public int pnIdeProOrigen { get; set; }
        public int pnCanTraslado { get; set; }
        public int pnIdeSedDestino { get; set; }
    }
}