using System;

namespace EsquemaAPI.Esquemas
{
    public class ProductoCrearRQT
    {
        public string pcNomPro { get; set; }
        public string pcDesPro { get; set; }
        public decimal pnPrePro { get; set; }
        public int pnStoPro { get; set; }
        public int pnIdeSed { get; set; }
    }

    public class ProductoCrearRPT : Status
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

    public class ProductoActualizarRPT : Status
    {
        public int pnIdePro { get; set; }
        public string pcNomPro { get; set; }
        public string pcDesPro { get; set; }
        public decimal pnPrePro { get; set; }
        public int pnStoPro { get; set; }
        public int pnIdeSed { get; set; }
        public DateTime ptFecPro { get; set; }
    }

    public class Status
    {
        public int pnCodigo { get; set; }
        public string pcMensaje { get; set; }
    }

    public class ProductoListaCN
    {
        public int pnIdePro { get; set; }
        public string pcNomPro { get; set; }
        public string pcDesPro { get; set; }
        public decimal pnPrePro { get; set; }
        public int pnStoPro { get; set; }
        public int pnIdeSed { get; set; }
        public DateTime ptFecPro { get; set; }
    }

    public class ProductosListRQT
    {
        public ProductoListaCN[] paProductos { get; set; }
    }

    public class ProductosListRPT : Status
    {
        public ProductoListaCN[] paProductos { get; set; }
    }

    public class ProductoEliminarRQT
    {
        public int pnIdePro { get; set; }
    }

    public class ProductoEliminarRPT : Status
    {
        public int pnIdePro { get; set; }
    }

    public class ProductoTrasladarRQT
    {
        public int pnIdeProOrigen { get; set; }
        public int pnCanTraslado { get; set; }
        public int pnIdeSedDestino { get; set; }
    }

    public class ProductoTrasladarRPT : Status
    {
        public int pnIdeProOrigen { get; set; }
        public int pnCanTraslado { get; set; }
        public int pnIdeSedDestino { get; set; }
    }
}