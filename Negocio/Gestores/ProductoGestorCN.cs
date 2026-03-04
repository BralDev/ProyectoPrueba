using Datos.Conexion;
using Datos.Entidades;
using Datos.Repositorios;
using Esquema.Esquemas;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Negocio.Transacciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Transversal;

namespace Negocio.Gestores
{
    public class ProductoGestorCN
    {

        private readonly ConexionCD loConexionCD;

        public ProductoGestorCN(string lcConexion)
        {
            this.loConexionCD = new ConexionCD(lcConexion);
        }

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

            using (TransaccionCN loTran = new TransaccionCN(this.loConexionCD.mxObtenerConexion()))
            {
                try
                {
                    loSedeEntRPT = loSedeRepoCD.mxObtenerSede(toProCreRQT.pnIdeSed, loTran.Conexion, loTran.Transaccion);
                    if (loSedeEntRPT == null)
                    {
                        loTran.mxRollback();
                        loProCreRPT.Code = 404;
                        loProCreRPT.Message = $"La sede con ID {toProCreRQT.pnIdeSed} no existe.";
                        return loProCreRPT;
                    }

                    loProEntRQT.cNomPro = toProCreRQT.pcNomPro;
                    loProEntRQT.cDesPro = toProCreRQT.pcDesPro;
                    loProEntRQT.nPrePro = toProCreRQT.pnPrePro;
                    loProEntRQT.nStoPro = toProCreRQT.pnStoPro;
                    loProEntRQT.nIdeSed = toProCreRQT.pnIdeSed;
                    loProEntRQT.tFecPro = DateTime.Now;

                    loProEntRPT = loProRepoCD.mxCrearProducto(loProEntRQT, loTran.Conexion, loTran.Transaccion);
                    if (loProEntRPT == null)
                    {
                        loTran.mxRollback();
                        loProCreRPT.Code = 500;
                        loProCreRPT.Message = "No se pudo crear el producto.";
                        return loProCreRPT;
                    }

                    loProCreRPT.pnIdePro = loProEntRPT.nIdePro;
                    loProCreRPT.pcNomPro = loProEntRPT.cNomPro;
                    loProCreRPT.pcDesPro = loProEntRPT.cDesPro;
                    loProCreRPT.pnPrePro = loProEntRPT.nPrePro;
                    loProCreRPT.pnStoPro = loProEntRPT.nStoPro;
                    loProCreRPT.pnIdeSed = loProEntRPT.nIdeSed;
                    loProCreRPT.ptFecPro = loProEntRPT.tFecPro;
                    loProCreRPT.Code = 201;
                    loProCreRPT.Message = "Producto creado exitosamente.";
                    loTran.mxCommit();
                }
                catch (Exception ex)
                {
                    loTran.mxRollback();
                    loLogger.LogError(ex, $"Error crítico al crear el producto: {toProCreRQT.pcNomPro}");
                    throw new Exception("Ocurrió un problema interno al procesar el producto.", ex);
                }
            }
            return loProCreRPT;
        }

        public ProductoEliminarRPT mxEliminarProducto(ProductoEliminarRQT toProEliRQT)
        {
            ProductoRepositorioCD loProRepoCD = new ProductoRepositorioCD();
            ILogger<ProductoGestorCN> loLogger = new LoggerFactory().CreateLogger<ProductoGestorCN>();
            ProductoEliminarRPT loProEliRPT = new ProductoEliminarRPT();
            ProductoEntidadCD loProEntCD = new ProductoEntidadCD();
            int lnConfirmacion = 0;

            using (TransaccionCN loTran = new TransaccionCN(this.loConexionCD.mxObtenerConexion()))
            {
                try
                {
                    // Validar que el producto existe
                    loProEntCD = loProRepoCD.mxObtenerProducto(toProEliRQT.pnIdePro, loTran.Conexion, loTran.Transaccion);
                    if (loProEntCD == null)
                    {
                        loTran.mxRollback();
                        loProEliRPT.Code = 404;
                        loProEliRPT.Message = $"El producto con ID {toProEliRQT.pnIdePro} no existe.";
                        return loProEliRPT;
                    }

                    // Eliminar producto
                    lnConfirmacion = loProRepoCD.mxEliminarProducto(toProEliRQT.pnIdePro, loTran.Conexion, loTran.Transaccion);
                    if (lnConfirmacion <= 0)
                    {
                        loTran.mxRollback();
                        loProEliRPT.Code = 500;
                        loProEliRPT.Message = $"No se pudo eliminar el producto con ID {toProEliRQT.pnIdePro}.";
                        return loProEliRPT;
                    }
                        
                    loProEliRPT.pnIdePro = loProEntCD.nIdePro;
                    loProEliRPT.Code = 200;
                    loProEliRPT.Message = $"Producto con ID {toProEliRQT.pnIdePro} eliminado exitosamente.";

                    // Todo ok                        
                    loTran.mxCommit();
                }
                catch (Exception ex)
                {
                    loTran.mxRollback();
                    loLogger.LogError(ex, $"Error crítico al intentar eliminar el producto: {toProEliRQT.pnIdePro}");
                    throw new Exception("Ocurrió un problema interno al eliminar el producto. Por favor, intente más tarde.", ex);
                }
                
            }

            return loProEliRPT;
        }

        public ProductosListRPT mxObtenerProductos()
        {
            ProductoRepositorioCD loProRepoCD = new ProductoRepositorioCD();
            ProductosListRPT loProLstRPT = new ProductosListRPT();
            ProductoListaCN loProLstCN = null;
            List<ProductoListaCN> laLstProductos = new List<ProductoListaCN>();

            using (IDbConnection loIDbConexion = this.loConexionCD.mxObtenerConexion())
            {
                loIDbConexion.Open();

                try
                {
                    List<ProductoEntidadCD> loListProductos = loProRepoCD.mxObtenerProductos(loIDbConexion);

                    if (loListProductos.Count == 0)
                    {
                        loProLstRPT.Code = 204;
                        loProLstRPT.Message = "La lista de productos se encuentra vacía.";
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
                    loProLstRPT.Code = 200;
                    loProLstRPT.Message = "Productos obtenidos exitosamente.";
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los productos desde la base de datos.", ex);
                }
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


            using (TransaccionCN loTran = new TransaccionCN(this.loConexionCD.mxObtenerConexion()))
            {
                try
                {
                    // Validar que el producto existe
                    loProEntRPT = loProRepoCD.mxObtenerProducto(toProActRQT.pnIdePro, loTran.Conexion, loTran.Transaccion);
                    if (loProEntRPT == null)
                    {
                        loTran.mxRollback();
                        loProActRPT.Code = 404;
                        loProActRPT.Message = $"El producto con ID {toProActRQT.pnIdePro} no existe.";
                        return loProActRPT;
                    }

                    // Validar que la sede existe
                    loSedeEntRPT = loSedeRepoCD.mxObtenerSede(toProActRQT.pnIdeSed, loTran.Conexion, loTran.Transaccion);
                    if (loSedeEntRPT == null)
                    {
                        loTran.mxRollback();
                        loProActRPT.Code = 404;
                        loProActRPT.Message = $"La sede con ID {toProActRQT.pnIdeSed} no existe.";
                        return loProActRPT;
                    }

                    // Preparar entidad
                    loProEntRQT.nIdePro = toProActRQT.pnIdePro;
                    loProEntRQT.cNomPro = toProActRQT.pcNomPro;
                    loProEntRQT.cDesPro = toProActRQT.pcDesPro;
                    loProEntRQT.nPrePro = toProActRQT.pnPrePro;
                    loProEntRQT.nStoPro = toProActRQT.pnStoPro;
                    loProEntRQT.nIdeSed = toProActRQT.pnIdeSed;

                    // Actualizar producto
                    loProEntRPT = loProRepoCD.mxActualizarProducto(loProEntRQT, loTran.Conexion, loTran.Transaccion);
                    if (loProEntRPT == null)
                    {
                        loTran.mxRollback();
                        loProActRPT.Code = 500;
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
                    loProActRPT.Code = 200;
                    loProActRPT.Message = $"Producto con ID {toProActRQT.pnIdePro} actualizado exitosamente.";

                    // Todo ok
                    loTran.mxCommit();
                }
                catch (Exception ex)
                {
                    loTran.mxRollback();
                    loLogger.LogError(ex, $"Error crítico al intentar actualizar el producto: {toProActRQT.pcNomPro}");
                    throw new Exception("Ocurrió un problema interno al procesar el producto. Por favor, intente más tarde.", ex);
                }                
            }

            return loProActRPT;
        }
    }
}