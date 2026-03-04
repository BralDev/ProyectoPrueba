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

            SedeEntidadCD loSedeEntRPT = new SedeEntidadCD();

            using (TransaccionCN loTran = new TransaccionCN(this.loConexionCD.mxObtenerConexion()))
            {
                try
                {
                    loSedeEntRPT = loSedeRepoCD.mxObtenerSede(toProCreRQT.pnIdeSed, loTran.Conexion, loTran.Transaccion);
                    if (loSedeEntRPT == null)
                    {
                        loTran.mxRollback();
                        loProCreRPT.pnCodigo = Constantes._M_CODIGO_NO_ENCONTRADO;
                        loProCreRPT.pcMensaje = Constantes._M_SEDE_NO_EXISTE;
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
                        loProCreRPT.pnCodigo = Constantes._M_CODIGO_ERROR;
                        loProCreRPT.pcMensaje = Constantes._M_ERROR_BASE_DATOS;
                        return loProCreRPT;
                    }

                    loProCreRPT.pnIdePro = loProEntRPT.nIdePro;
                    loProCreRPT.pcNomPro = loProEntRPT.cNomPro;
                    loProCreRPT.pcDesPro = loProEntRPT.cDesPro;
                    loProCreRPT.pnPrePro = loProEntRPT.nPrePro;
                    loProCreRPT.pnStoPro = loProEntRPT.nStoPro;
                    loProCreRPT.pnIdeSed = loProEntRPT.nIdeSed;
                    loProCreRPT.ptFecPro = loProEntRPT.tFecPro;
                    loProCreRPT.pnCodigo = Constantes._M_CODIGO_CREDADO;
                    loProCreRPT.pcMensaje = Constantes._M_REGISTRO_EXITOSO;
                    loTran.mxCommit();
                }
                catch (Exception ex)
                {
                    loTran.mxRollback();
                    loLogger.LogError(ex, Constantes._M_ERROR_REGISTRO);
                    throw new Exception(Constantes._M_ERROR_REGISTRO, ex);
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
                        loProEliRPT.pnCodigo = Constantes._M_CODIGO_NO_ENCONTRADO;
                        loProEliRPT.pcMensaje = Constantes._M_PRODUCTO_NO_EXISTE;
                        return loProEliRPT;
                    }

                    // Eliminar producto
                    lnConfirmacion = loProRepoCD.mxEliminarProducto(toProEliRQT.pnIdePro, loTran.Conexion, loTran.Transaccion);
                    if (lnConfirmacion <= 0)
                    {
                        loTran.mxRollback();
                        loProEliRPT.pnCodigo = Constantes._M_CODIGO_ERROR;
                        loProEliRPT.pcMensaje = Constantes._M_ERROR_BASE_DATOS;
                        return loProEliRPT;
                    }
                        
                    loProEliRPT.pnIdePro = loProEntCD.nIdePro;
                    loProEliRPT.pnCodigo = Constantes._M_CODIGO_EXITOSO;
                    loProEliRPT.pcMensaje = Constantes._M_ELIMINACION_EXITOSA;

                    // Todo ok                        
                    loTran.mxCommit();
                }
                catch (Exception ex)
                {
                    loTran.mxRollback();
                    loLogger.LogError(ex, Constantes._M_ERROR_ELIMINAR);
                    throw new Exception(Constantes._M_ERROR_ELIMINAR, ex);
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
                        loProLstRPT.pnCodigo = Constantes._M_CODIGO_SIN_CONTENIDO;
                        loProLstRPT.pcMensaje = Constantes._M_RECURSO_LISTA_VACIO;
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
                    loProLstRPT.pnCodigo = Constantes._M_CODIGO_EXITOSO;
                    loProLstRPT.pcMensaje = Constantes._M_CARGA_REGISTROS;
                }
                catch (Exception ex)
                {
                    loProLstRPT.pnCodigo = Constantes._M_CODIGO_ERROR;
                    loProLstRPT.pcMensaje = Constantes._M_ERROR_BASE_DATOS;
                    throw new Exception(Constantes._M_ERROR_BASE_DATOS, ex);
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
                        loProActRPT.pnCodigo = Constantes._M_CODIGO_NO_ENCONTRADO;
                        loProActRPT.pcMensaje = Constantes._M_PRODUCTO_NO_EXISTE;
                        return loProActRPT;
                    }

                    // Validar que la sede existe
                    loSedeEntRPT = loSedeRepoCD.mxObtenerSede(toProActRQT.pnIdeSed, loTran.Conexion, loTran.Transaccion);
                    if (loSedeEntRPT == null)
                    {
                        loTran.mxRollback();
                        loProActRPT.pnCodigo = Constantes._M_CODIGO_NO_ENCONTRADO;
                        loProActRPT.pcMensaje = Constantes._M_SEDE_NO_EXISTE;
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
                        loProActRPT.pnCodigo = Constantes._M_CODIGO_ERROR;
                        loProActRPT.pcMensaje = Constantes._M_ERROR_BASE_DATOS;
                        return loProActRPT;
                    }
                        
                    loProActRPT.pnIdePro = loProEntRPT.nIdePro;
                    loProActRPT.pcNomPro = loProEntRPT.cNomPro;
                    loProActRPT.pcDesPro = loProEntRPT.cDesPro;
                    loProActRPT.pnPrePro = loProEntRPT.nPrePro;
                    loProActRPT.pnStoPro = loProEntRPT.nStoPro;
                    loProActRPT.pnIdeSed = loProEntRPT.nIdeSed;
                    loProActRPT.ptFecPro = loProEntRPT.tFecPro;
                    loProActRPT.pnCodigo = Constantes._M_CODIGO_EXITOSO;
                    loProActRPT.pcMensaje = Constantes._M_ACTUALIZACION_EXITOSA;

                    // Todo ok
                    loTran.mxCommit();
                }
                catch (Exception ex)
                {
                    loTran.mxRollback();
                    loLogger.LogError(ex, Constantes._M_ERROR_ACTUALIZAR);
                    throw new Exception(Constantes._M_ERROR_ACTUALIZAR, ex);
                }                
            }

            return loProActRPT;
        }
    }
}