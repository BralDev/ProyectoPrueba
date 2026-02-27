using Datos.Entidades;
using Datos.Repositorios;
using Microsoft.Extensions.Logging;
using Negocio.Esquemas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Transversal;

namespace Negocio.Gestores
{
    public class GestorProducto
    {
        private readonly ProductoRepositorio loProductosCD;
        private readonly ILogger<GestorProducto> _logger;
        private int confirmacion;

        public GestorProducto()
        {
            this.loProductosCD = new ProductoRepositorio();
            this._logger = new LoggerFactory().CreateLogger<GestorProducto>();
        }

        public int mxCrearProducto(ProductCreateDto dtoProducto)
        {
            try
            {
                ProductoCD entiProducto = new ProductoCD
                {
                    cNomPro = dtoProducto.cNomPro,
                    cDesPro = dtoProducto.cDesPro,
                    nPrePro = dtoProducto.nPrePro,
                    nStoPro = dtoProducto.nStoPro
                };

                this.confirmacion = this.loProductosCD.createProducto(entiProducto);
                
                if (this.confirmacion <= 0)
                {
                    this._logger.LogWarning(Constantes._M_NO_REGISTRO, dtoProducto.cNomPro);
                }

                return this.confirmacion;
            }
            catch (Exception ex)
            {                
                _logger.LogError(ex, $"Error crítico al intentar crear el producto: {dtoProducto.cNomPro}");

                // 2. Propagas el error hacia la capa Web. 
                // Puedes usar 'throw;' para mantener el error original, o envolverlo en una excepción propia.
                throw new Exception("Ocurrió un problema interno al procesar el producto. Por favor, intente más tarde.", ex);
            }
        }

        public int mxEliminarProducto(int id)
        {
            this.confirmacion = this.loProductosCD.deleteProducto(id);
            if (this.confirmacion <= 0)
            {
                _logger.LogWarning(Constantes._M_ERROR_ELIMINAR, id);
            }
            return this.confirmacion;
        }

        public ProductosRPT mxObtenerProductos()
        {            
            ProductosRPT loRespuesta = new ProductosRPT();
            Producto loProducto;
            List<Producto> laLstProductos = new List<Producto>();
            try
            {
                List<ProductoCD> productos = this.loProductosCD.listProducto();

                if (productos.Count == 0)
                {                    
                    return loRespuesta;
                }

                foreach (var product in productos) 
                {
                    loProducto = new Producto();
                    loProducto.pnIdePro = product.nIdePro;
                    loProducto.pcNomPro = product.cNomPro;
                    loProducto.pcDesPro = product.cDesPro;
                    loProducto.pnPrePro = product.nPrePro;
                    loProducto.pnStoPro = product.nStoPro;
                    loProducto.ptFecPro = product.tFecPro;
                    laLstProductos.Add( loProducto );
                }
                loRespuesta.paProductos = laLstProductos.ToArray();
            }
            catch (Exception ex)
            {
                
            }

            return loRespuesta;
        }

        public int mxActualizarProducto(ProductUpdateDto dtoProducto)
        {
            ProductoCD entiProducto = new ProductoCD
            {
                nIdePro = dtoProducto.nIdePro,
                cNomPro = dtoProducto.cNomPro,
                cDesPro = dtoProducto.cDesPro,
                nPrePro = dtoProducto.nPrePro,
                nStoPro = dtoProducto.nStoPro
            };

            this.confirmacion = this.loProductosCD.updateProducto(entiProducto);
            if (this.confirmacion <= 0)
            {
                _logger.LogWarning(Constantes._M_ERROR_ACTUALIZAR, dtoProducto.cNomPro);
            }
            return this.confirmacion;
        }
    }
}
