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

        public ProductoCrearRPT mxCrearProducto(ProductoCrearRQT requestProducto)
        {
            ProductoCrearRPT respuesta;
            int idProducto;
            try
            {                
                ProductoCD entiProducto = new ProductoCD
                {
                    cNomPro = requestProducto.pcNomPro,
                    cDesPro = requestProducto.pcDesPro,
                    nPrePro = requestProducto.pnPrePro,
                    nStoPro = requestProducto.pnStoPro,
                    tFecPro = DateTime.Now
                };

                idProducto = this.loProductosCD.mxCrearProducto(entiProducto);
                
                if (idProducto <= 0)
                {
                    this._logger.LogWarning(Constantes._M_NO_REGISTRO, requestProducto.pcNomPro);
                }                

                respuesta = new ProductoCrearRPT
                {
                    pnIdePro = idProducto,
                    pcNomPro = entiProducto.cNomPro,
                    pcDesPro = entiProducto.cDesPro,
                    pnPrePro = entiProducto.nPrePro,
                    pnStoPro = entiProducto.nStoPro,
                    ptFecPro = entiProducto.tFecPro
                };
            }
            catch (Exception ex)
            {                
                _logger.LogError(ex, $"Error crítico al intentar crear el producto: {requestProducto.pcNomPro}");
    
                throw new Exception("Ocurrió un problema interno al procesar el producto. Por favor, intente más tarde.", ex);
            }
            return respuesta;
        }

        public int mxEliminarProducto(int id)
        {
            this.confirmacion = this.loProductosCD.mxEliminarProducto(id);
            if (this.confirmacion <= 0)
            {
                _logger.LogWarning(Constantes._M_ERROR_ELIMINAR, id);
            }
            return this.confirmacion;
        }

        public ProductosListRPT mxObtenerProductos()
        {
            ProductosListRPT loRespuesta = new ProductosListRPT();
            ProductoListCN loProducto;
            List<ProductoListCN> laLstProductos = new List<ProductoListCN>();
            try
            {
                List<ProductoCD> productos = this.loProductosCD.mxObtenerProductos();

                if (productos == null || productos.Count == 0)
                {
                    loRespuesta.paProductos = new ProductoListCN[0];
                    return loRespuesta;
                }

                foreach (var product in productos) 
                {
                    loProducto = new ProductoListCN();
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
                throw new Exception("Error al obtener los productos desde la base de datos.", ex);
            }

            return loRespuesta;
        }
            
        public ProductoActualizarRPT mxActualizarProducto(ProductoActualizarRQT requestProducto)
        {
            ProductoActualizarRPT respuesta;
            int confirmacion;
            try
            {
                ProductoCD entiProducto = new ProductoCD
                {
                    nIdePro = requestProducto.pnIdePro,
                    cNomPro = requestProducto.pcNomPro,
                    cDesPro = requestProducto.pcDesPro,
                    nPrePro = requestProducto.pnPrePro,
                    nStoPro = requestProducto.pnStoPro                    
                };

                confirmacion = this.loProductosCD.mxActualizarProducto(entiProducto);

                if (confirmacion <= 0)
                {
                    this._logger.LogWarning(Constantes._M_NO_REGISTRO, requestProducto.pcNomPro);
                }

                respuesta = new ProductoActualizarRPT
                {
                    pnIdePro = entiProducto.nIdePro,
                    pcNomPro = entiProducto.cNomPro,
                    pcDesPro = entiProducto.cDesPro,
                    pnPrePro = entiProducto.nPrePro,
                    pnStoPro = entiProducto.nStoPro,
                    ptFecPro = entiProducto.tFecPro
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error crítico al intentar crear el producto: {requestProducto.pcNomPro}");

                throw new Exception("Ocurrió un problema interno al procesar el producto. Por favor, intente más tarde.", ex);
            }
            return respuesta;
        }
    }
