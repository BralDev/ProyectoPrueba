using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Esquemas
{
    public class ProductoCrearRQT
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio.", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre debe tener entre 1 y 100 caracteres.")]
        public string pcNomPro { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string pcDesPro { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio.", AllowEmptyStrings = false)]
        [Range(0.01, 99999.99, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal pnPrePro { get; set; }

        [Required(ErrorMessage = "El número de stock del producto es obligatorio.", AllowEmptyStrings = false)]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
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
        [Range(1, int.MaxValue, ErrorMessage = "El ID del producto es inválido. Debe ser mayor a 0.")]
        public int pnIdePro { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre debe tener entre 1 y 100 caracteres.")]
        public string pcNomPro { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string pcDesPro { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio.", AllowEmptyStrings = false)]
        [Range(0.01, 99999.99, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal pnPrePro { get; set; }

        [Required(ErrorMessage = "El número de stock del producto es obligatorio.", AllowEmptyStrings = false)]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
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
