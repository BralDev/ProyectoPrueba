using Datos.Entidades;
using Datos.Repositorios;
using Microsoft.Extensions.Logging;
using Negocio.Esquemas;
using System;
using System.Collections.Generic;
using Transversal;

namespace Negocio.Gestores
{
    public class ProductoGestorCN
    {
        private readonly ProductoRepositorioCD loProRepoCD;
        private readonly ILogger<ProductoGestorCN> loLogger;        

        public ProductoGestorCN()
        {
            this.loProRepoCD = new ProductoRepositorioCD();
            this.loLogger = new LoggerFactory().CreateLogger<ProductoGestorCN>();
        }

        public ProductoCrearRPT mxCrearProducto(ProductoCrearRQT toProCreRQT)
        {
            ProductoCrearRPT loProCreRPT = null;
            int lnIdPro = 0;
            try
            {
                ProductoCD loProCD = new ProductoCD
                {
                    cNomPro = toProCreRQT.pcNomPro,
                    cDesPro = toProCreRQT.pcDesPro,
                    nPrePro = toProCreRQT.pnPrePro,
                    nStoPro = toProCreRQT.pnStoPro,
                    tFecPro = DateTime.Now
                };

                lnIdPro = this.loProRepoCD.mxCrearProducto(loProCD);

                if (lnIdPro <= 0)
                {
                    this.loLogger.LogWarning(Constantes._M_NO_REGISTRO, toProCreRQT.pcNomPro);
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

        public int mxEliminarProducto(int tnIdePro)
        {
            int lnConfirmacion = 0;

            lnConfirmacion = this.loProRepoCD.mxEliminarProducto(tnIdePro);
            if (lnConfirmacion <= 0)
            {
                loLogger.LogWarning(Constantes._M_ERROR_ELIMINAR, tnIdePro);
            }
            return lnConfirmacion;
        }

        public ProductosListRPT mxObtenerProductos()
        {
            ProductosListRPT loProLstRPT = new ProductosListRPT();
            ProductoListaCN loProLstCN = null;
            List<ProductoListaCN> laLstProductos = new List<ProductoListaCN>();
            try
            {
                List<ProductoCD> loListProductos = this.loProRepoCD.mxObtenerProductos();

                if (loListProductos == null || loListProductos.Count == 0)
                {
                    loProLstRPT.paProductos = new ProductoListaCN[0];
                    return loProLstRPT;
                }

                foreach (ProductoCD loProCD in loListProductos)
                {
                    loProLstCN = new ProductoListaCN();
                    loProLstCN.pnIdePro = loProCD.nIdePro;
                    loProLstCN.pcNomPro = loProCD.cNomPro;
                    loProLstCN.pcDesPro = loProCD.cDesPro;
                    loProLstCN.pnPrePro = loProCD.nPrePro;
                    loProLstCN.pnStoPro = loProCD.nStoPro;
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
            ProductoActualizarRPT loProActRPT = null;
            DateTime loConfirmacion = DateTime.Now;
            try
            {
                ProductoCD loProCD = new ProductoCD
                {
                    nIdePro = toProActRQT.pnIdePro,
                    cNomPro = toProActRQT.pcNomPro,
                    cDesPro = toProActRQT.pcDesPro,
                    nPrePro = toProActRQT.pnPrePro,
                    nStoPro = toProActRQT.pnStoPro
                };

                loConfirmacion = this.loProRepoCD.mxActualizarProducto(loProCD);

                if (loConfirmacion == null)
                {
                    this.loLogger.LogWarning(Constantes._M_NO_REGISTRO, toProActRQT.pcNomPro);
                }

                loProActRPT = new ProductoActualizarRPT
                {
                    pnIdePro = toProActRQT.pnIdePro,
                    pcNomPro = toProActRQT.pcNomPro,
                    pcDesPro = toProActRQT.pcDesPro,
                    pnPrePro = toProActRQT.pnPrePro,
                    pnStoPro = toProActRQT.pnStoPro,
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