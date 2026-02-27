using Datos.Conexion;
using Datos.Entidades;
using Datos.Interfaces;
using Datos.Repositorios;
using Microsoft.Extensions.Logging;
using Negocio.Esquemas;
using Negocio.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Transversal;

namespace Negocio.Gestores
{
    public class GestorProducto
    {
        //private readonly IProductoRepositorio repositorio;
        //private readonly ILogger<GestorProducto> _logger;
        private int confirmacion;

        //public GestorProducto(IProductoRepositorio repositorio, ILogger<GestorProducto> logger)
        //{
        //    this.repositorio = repositorio;
        //    this._logger = logger;
        //}

        //int IGestorProducto.createProducto(ProductCreateDto dtoProducto)
        //{
        //    Producto entiProducto = new Producto
        //    {
        //        cNomPro = dtoProducto.cNomPro,
        //        cDesPro = dtoProducto.cDesPro,
        //        nPrePro = dtoProducto.nPrePro,
        //        nStoPro = dtoProducto.nStoPro
        //    };

        //    this.confirmacion = repositorio.createProducto(entiProducto);
        //    if (this.confirmacion <= 0)
        //    {
        //        _logger.LogWarning(Constantes._M_NO_REGISTRO, dtoProducto.cNomPro);
        //    }
        //    return this.confirmacion;
        //}

        //int IGestorProducto.deleteProducto(int id)
        //{
        //    this.confirmacion = repositorio.deleteProducto(id);
        //    if (this.confirmacion <= 0)
        //    {
        //        _logger.LogWarning(Constantes._M_ERROR_ELIMINAR, id);
        //    }
        //    return this.confirmacion;
        //}

        public ProductosRPT mxObtenerProductos(ProductosRQT toProductos)
        {
            ProductoRepositorio loProductosCD = new ProductoRepositorio();
            ProductosRPT loRespuesta = new ProductosRPT();
            Producto loProducto = new Producto();
            List<Producto> laLstProductos = new List<Producto>();
            try
            {
                var productos = loProductosCD.listProducto();

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

        //int IGestorProducto.updateProducto(ProductUpdateDto dtoProducto)
        //{
        //    Producto entiProducto = new Producto
        //    {
        //        nIdePro = dtoProducto.nIdePro,
        //        cNomPro = dtoProducto.cNomPro,
        //        cDesPro = dtoProducto.cDesPro,
        //        nPrePro = dtoProducto.nPrePro,
        //        nStoPro = dtoProducto.nStoPro
        //    };

        //    this.confirmacion = repositorio.updateProducto(entiProducto);
        //    if (this.confirmacion <= 0)
        //    {
        //        _logger.LogWarning(Constantes._M_ERROR_ACTUALIZAR, dtoProducto.cNomPro);
        //    }
        //    return this.confirmacion;
        //}
    }
}
