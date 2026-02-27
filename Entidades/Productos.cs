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

    public class ProductResponseDto
    {
        public int nIdePro { get; set; }
        public string cNomPro { get; set; }
        public string cDesPro { get; set; }
        public decimal nPrePro { get; set; }
        public int nStoPro { get; set; }
        public DateTime tFecPro { get; set; }
    }
}
