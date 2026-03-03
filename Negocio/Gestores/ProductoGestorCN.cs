using Datos.Entidades;
using Datos.Repositorios;
using Microsoft.Extensions.Logging;
using Esquema.Esquemas;
using System;
using System.Collections.Generic;
using Transversal;

namespace Negocio.Gestores
{
    public class ProductoGestorCN
    {                        
        public ProductoCrearRPT mxCrearProducto(ProductoCrearRQT toProCreRQT)
        {
            ProductoRepositorioCD loProRepoCD = new ProductoRepositorioCD();
            ILogger<ProductoGestorCN> loLogger = new LoggerFactory().CreateLogger<ProductoGestorCN>();
            
            ProductoCrearRPT loProCreRPT = null;            
            ProductoEntidadCD loPro
            try
            {
                ProductoEntidadCD loProCD = new ProductoEntidadCD
                {
                    cNomPro = toProCreRQT.pcNomPro,
                    cDesPro = toProCreRQT.pcDesPro,
                    nPrePro = toProCreRQT.pnPrePro,
                    nStoPro = toProCreRQT.pnStoPro,
                    nIdeSed = toProCreRQT.pnIdeSed,
                    tFecPro = DateTime.Now
                };

                lnIdPro = loProRepoCD.mxCrearProducto(loProCD);

                if (lnIdPro <= 0)
                {
                    loLogger.LogWarning(Constantes._M_NO_REGISTRO, toProCreRQT.pcNomPro);
                }
                else
                {
                    loProCreRPT = new ProductoCrearRPT
                    {
                        pnIdePro = lnIdPro,
                        pcNomPro = toProCreRQT.pcNomPro,
                        pcDesPro = toProCreRQT.pcDesPro,
                        pnPrePro = toProCreRQT.pnPrePro,
                        pnStoPro = toProCreRQT.pnStoPro,
                        pnIdeSed = toProCreRQT.pnIdeSed,
                        ptFecPro = loProCD.tFecPro
                    };
                }
            }
            catch (Exception ex)
            {
                loLogger.LogError(ex, $"Error crítico al intentar crear el producto: {toProCreRQT.pcNomPro}");

                throw new Exception("Ocurrió un problema interno al procesar el producto. Por favor, intente más tarde.", ex);
            }
            return loProCreRPT;
        }

        public ProductoEliminarRPT mxEliminarProducto(ProductoEliminarRQT toProEliRQT)
        {
            ProductoRepositorioCD loProRepoCD = new ProductoRepositorioCD();
            ILogger<ProductoGestorCN> loLogger = new LoggerFactory().CreateLogger<ProductoGestorCN>();
            ProductoEliminarRPT loProEliRPT = new ProductoEliminarRPT();

            int lnConfirmacion = 0;

            lnConfirmacion = loProRepoCD.mxEliminarProducto(toProEliRQT.pnIdePro);
            if (lnConfirmacion <= 0)
            {
                loLogger.LogWarning(Constantes._M_ERROR_ELIMINAR, toProEliRQT.pnIdePro);
            }

            loProEliRPT.pnIdePro = toProEliRQT.pnIdePro;
            return loProEliRPT;
        }

        public ProductosListRPT mxObtenerProductos()
        {
            ProductoRepositorioCD loProRepoCD = new ProductoRepositorioCD();            
            ProductosListRPT loProLstRPT = new ProductosListRPT();
            ProductoListaCN loProLstCN = null;
            List<ProductoListaCN> laLstProductos = new List<ProductoListaCN>();
            try
            {
                List<ProductoEntidadCD> loListProductos = loProRepoCD.mxObtenerProductos();

                if (loListProductos == null || loListProductos.Count == 0)
                {
                    loProLstRPT.paProductos = new ProductoListaCN[0];
                    return loProLstRPT;
                }

                foreach (ProductoEntidadCD loProCD in loListProductos)
                {
                    loProLstCN = new ProductoListaCN();
                    loProLstCN.pnIdePro = loProCD.nIdePro;
                    loProLstCN.pcNomPro = loProCD.cNomPro;
                    loProLstCN.pcDesPro = loProCD.cDesPro;
                    loProLstCN.pnPrePro = loProCD.nPrePro;
                    loProLstCN.pnStoPro = loProCD.nStoPro;
                    loProLstCN.pnIdeSed = loProCD.nIdeSed;
                    loProLstCN.ptFecPro = loProCD.tFecPro;

                    laLstProductos.Add(loProLstCN);
                }
                loProLstRPT.paProductos = laLstProductos.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los productos desde la base de datos.", ex);
            }

            return loProLstRPT;
        }

        public ProductoActualizarRPT mxActualizarProducto(ProductoActualizarRQT toProActRQT)
        {
            ProductoRepositorioCD loProRepoCD = new ProductoRepositorioCD();
            ILogger<ProductoGestorCN> loLogger = new LoggerFactory().CreateLogger<ProductoGestorCN>();
            ProductoActualizarRPT loProActRPT = null;

            DateTime loConfirmacion = DateTime.Now;
            try
            {
                ProductoEntidadCD loProCD = new ProductoEntidadCD
                {
                    nIdePro = toProActRQT.pnIdePro,
                    cNomPro = toProActRQT.pcNomPro,
                    cDesPro = toProActRQT.pcDesPro,
                    nPrePro = toProActRQT.pnPrePro,
                    nStoPro = toProActRQT.pnStoPro,
                    nIdeSed = toProActRQT.pnIdeSed,
                };

                loConfirmacion = loProRepoCD.mxActualizarProducto(loProCD);

                if (loConfirmacion == null)
                {
                    loProActRPT.Code = "500";
                    loProActRPT.Message = Constantes._M_ERROR_BASE_DATOS;
                    return loProActRPT;
                }

                loProActRPT = new ProductoActualizarRPT
                {
                    pnIdePro = toProActRQT.pnIdePro,
                    pcNomPro = toProActRQT.pcNomPro,
                    pcDesPro = toProActRQT.pcDesPro,
                    pnPrePro = toProActRQT.pnPrePro,
                    pnStoPro = toProActRQT.pnStoPro,
                    pnIdeSed = toProActRQT.pnIdeSed,
                    ptFecPro = loConfirmacion
                };
            }
            catch (Exception ex)
            {
                loLogger.LogError(ex, $"Error crítico al intentar crear el producto: {toProActRQT.pcNomPro}");

                throw new Exception("Ocurrió un problema interno al procesar el producto. Por favor, intente más tarde.", ex);
            }
            return loProActRPT;
        }
    }
}