using Datos.Entidades;
using Datos.Repositorios;
using Esquema.Esquemas;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Transversal;

namespace Negocio.Gestores
{
    public class ProductoGestorCN
    {                        
        public ProductoCrearRPT mxCrearProducto(ProductoCrearRQT toProCreRQT)
        {
            ProductoRepositorioCD loProRepoCD = new ProductoRepositorioCD();
            SedeRepositorioCD loSedeRepoCD = new SedeRepositorioCD();
            ILogger<ProductoGestorCN> loLogger = new LoggerFactory().CreateLogger<ProductoGestorCN>();
            
            ProductoCrearRPT loProCreRPT = new ProductoCrearRPT();
            ProductoEntidadCD loProEntRQT = new ProductoEntidadCD();
            ProductoEntidadCD loProEntRPT = new ProductoEntidadCD();

            SedeEntidadCD loSedeEntRQT = new SedeEntidadCD();
            SedeEntidadCD loSedeEntRPT = new SedeEntidadCD();

            try
            {     
                loSedeEntRPT = loSedeRepoCD.mxObtenerSede(toProCreRQT.pnIdeSed);
                if (loSedeEntRPT == null)
                {
                    loProCreRPT.Code = "404";
                    loProCreRPT.Message = $"La sede con ID {toProCreRQT.pnIdeSed} no existe.";
                    return loProCreRPT;
                }

                loProEntRQT.cNomPro = toProCreRQT.pcNomPro;
                loProEntRQT.cDesPro = toProCreRQT.pcDesPro;
                loProEntRQT.nPrePro = toProCreRQT.pnPrePro;
                loProEntRQT.nStoPro = toProCreRQT.pnStoPro;
                loProEntRQT.nIdeSed = toProCreRQT.pnIdeSed;
                loProEntRQT.tFecPro = DateTime.Now;

                loProEntRPT = loProRepoCD.mxCrearProducto(loProEntRQT);

                if (loProEntRPT == null)
                {                    
                    loProCreRPT.Code = "500";
                    loProCreRPT.Message = "No se pudo crear el producto.";
                }
                else
                {
                    loProCreRPT.pnIdePro = loProEntRPT.nIdePro;
                    loProCreRPT.pcNomPro = loProEntRPT.cNomPro;
                    loProCreRPT.pcDesPro = loProEntRPT.cDesPro;
                    loProCreRPT.pnPrePro = loProEntRPT.nPrePro;
                    loProCreRPT.pnStoPro = loProEntRPT.nStoPro;
                    loProCreRPT.pnIdeSed = loProEntRPT.nIdeSed;
                    loProCreRPT.ptFecPro = loProEntRPT.tFecPro;
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
            ProductoEliminarRPT loProEliRPT = new ProductoEliminarRPT();
            ProductoEntidadCD loProEntCD = new ProductoEntidadCD();
            int lnConfirmacion = new int();

            loProEntCD = loProRepoCD.mxObtenerProducto(toProEliRQT.pnIdePro);
            if (loProEntCD == null)
            {
                loProEliRPT.Code = "404";
                loProEliRPT.Message = $"El producto con ID {toProEliRQT.pnIdePro} no existe.";                
                return loProEliRPT;
            }

            lnConfirmacion = loProRepoCD.mxEliminarProducto(toProEliRQT.pnIdePro);
            if (lnConfirmacion <= 0)
            {
                loProEliRPT.Code = "500";
                loProEliRPT.Message = $"No se pudo eliminar el producto con ID {toProEliRQT.pnIdePro}.";                
                return loProEliRPT;
            }                

            loProEliRPT.pnIdePro = loProEntCD.nIdePro;
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

                if (loListProductos.Count == 0)
                {
                    loProLstRPT.Code = "204";
                    loProLstRPT.Message = "La lista de productos se encuentra vacia.";                    
                    return loProLstRPT;
                }

                foreach (ProductoEntidadCD loProEntCD in loListProductos)
                {
                    loProLstCN = new ProductoListaCN();
                    loProLstCN.pnIdePro = loProEntCD.nIdePro;
                    loProLstCN.pcNomPro = loProEntCD.cNomPro;
                    loProLstCN.pcDesPro = loProEntCD.cDesPro;
                    loProLstCN.pnPrePro = loProEntCD.nPrePro;
                    loProLstCN.pnStoPro = loProEntCD.nStoPro;
                    loProLstCN.pnIdeSed = loProEntCD.nIdeSed;
                    loProLstCN.ptFecPro = loProEntCD.tFecPro;

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
            SedeRepositorioCD loSedeRepoCD = new SedeRepositorioCD();
            ILogger<ProductoGestorCN> loLogger = new LoggerFactory().CreateLogger<ProductoGestorCN>();
            ProductoActualizarRPT loProActRPT = new ProductoActualizarRPT();
            
            ProductoEntidadCD loProEntRQT = new ProductoEntidadCD();
            ProductoEntidadCD loProEntRPT = new ProductoEntidadCD();

            SedeEntidadCD loSedeEntRQT = new SedeEntidadCD();
            SedeEntidadCD loSedeEntRPT = new SedeEntidadCD();

            try
            {
                loProEntRPT = loProRepoCD.mxObtenerProducto(toProActRQT.pnIdePro);
                if (loProEntRPT == null)
                {
                    loProActRPT.Code = "404";
                    loProActRPT.Message = $"El producto con ID {toProActRQT.pnIdePro} no existe.";
                    return loProActRPT;
                }

                loSedeEntRPT = loSedeRepoCD.mxObtenerSede(toProActRQT.pnIdeSed);
                if (loSedeEntRPT == null)
                {
                    loProActRPT.Code = "404";
                    loProActRPT.Message = $"La sede con ID {toProActRQT.pnIdeSed} no existe.";
                    return loProActRPT;
                }

                loProEntRQT.nIdePro = toProActRQT.pnIdePro;
                loProEntRQT.cNomPro = toProActRQT.pcNomPro;
                loProEntRQT.cDesPro = toProActRQT.pcDesPro;
                loProEntRQT.nPrePro = toProActRQT.pnPrePro;
                loProEntRQT.nStoPro = toProActRQT.pnStoPro;
                loProEntRQT.nIdeSed = toProActRQT.pnIdeSed;                                                   

                loProEntRPT = loProRepoCD.mxActualizarProducto(loProEntRQT);

                if (loProEntRPT == null)
                {
                    loProActRPT.Code = "500";
                    loProActRPT.Message = $"No se pudo actualizar el producto con ID {toProActRQT.pnIdePro}.";
                    return loProActRPT;
                }

                loProActRPT.pnIdePro = loProEntRPT.nIdePro;
                loProActRPT.pcNomPro = loProEntRPT.cNomPro;
                loProActRPT.pcDesPro = loProEntRPT.cDesPro;
                loProActRPT.pnPrePro = loProEntRPT.nPrePro;
                loProActRPT.pnStoPro = loProEntRPT.nStoPro;
                loProActRPT.pnIdeSed = loProEntRPT.nIdeSed;
                loProActRPT.ptFecPro = loProEntRPT.tFecPro;
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