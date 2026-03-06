using EsquemaAPI.Esquemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Transversal;
using WS = ReferenciaServicios.WRGestionProductos;

namespace WAProductos.Controllers
{
    [RoutePrefix("api")]
    public class ProductosController : ApiController
    {     
        // GET api/productos
        [HttpGet]
        [Route("obtenerProductos")]
        public IHttpActionResult rmObtenerProductos()
        {
            try
            {
                WS.WSGestionProductos loWS = new WS.WSGestionProductos();
                WS.ProductosListRPT loWSRPT = loWS.wmObtenerProductos();

                ProductoListaCN[] laProductosCN = null;

                if (loWSRPT.paProductos != null)
                {
                    List<ProductoListaCN> loProLstCN = new List<ProductoListaCN>();

                    foreach (WS.ProductoListaCN loProLst in loWSRPT.paProductos)
                    {
                        ProductoListaCN loProducto = new ProductoListaCN
                        {
                            pnIdePro = loProLst.pnIdePro,
                            pcNomPro = loProLst.pcNomPro,
                            pcDesPro = loProLst.pcDesPro,
                            pnPrePro = loProLst.pnPrePro,
                            pnStoPro = loProLst.pnStoPro,
                            pnIdeSed = loProLst.pnIdeSed,
                            ptFecPro = loProLst.ptFecPro
                        };

                        loProLstCN.Add(loProducto);
                    }

                    laProductosCN = loProLstCN.ToArray();
                }

                ProductosListRPT loRPT = new ProductosListRPT
                {
                    pnCodigo = loWSRPT.pnCodigo,
                    pcMensaje = loWSRPT.pcMensaje,
                    paProductos = laProductosCN
                };

                return Content((HttpStatusCode)loRPT.pnCodigo, loRPT);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/productos
        [HttpPost]
        [Route("crearProducto")]
        public IHttpActionResult rmCrearProducto(ProductoCrearRQT toProCreRQT)
        {
            try
            {
                if (toProCreRQT == null)
                    return BadRequest(Constantes._M_CUERPO_SOLICITUD_VACIO);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                WS.WSGestionProductos loWS = new WS.WSGestionProductos();
                WS.ProductoCrearRPT loWSRPT = loWS.wmCrearProducto(new WS.ProductoCrearRQT
                {
                    pcNomPro = toProCreRQT.pcNomPro,
                    pcDesPro = toProCreRQT.pcDesPro,
                    pnPrePro = toProCreRQT.pnPrePro,
                    pnStoPro = toProCreRQT.pnStoPro,
                    pnIdeSed = toProCreRQT.pnIdeSed
                });

                ProductoCrearRPT loRPT = new ProductoCrearRPT
                {
                    pnCodigo = loWSRPT.pnCodigo,
                    pcMensaje = loWSRPT.pcMensaje,
                    pnIdePro = loWSRPT.pnIdePro,
                    pcNomPro = loWSRPT.pcNomPro,
                    pcDesPro = loWSRPT.pcDesPro,
                    pnPrePro = loWSRPT.pnPrePro,
                    pnStoPro = loWSRPT.pnStoPro,
                    pnIdeSed = loWSRPT.pnIdeSed,
                    ptFecPro = loWSRPT.ptFecPro
                };

                return Content((HttpStatusCode)loRPT.pnCodigo, loRPT);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/productos
        [HttpPut]
        [Route("actualizarProducto")]
        public IHttpActionResult rmActualizarProducto(ProductoActualizarRQT toActPro)
        {
            try
            {
                if (toActPro == null)
                    return BadRequest(Constantes._M_CUERPO_SOLICITUD_VACIO);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                WS.WSGestionProductos loWS = new WS.WSGestionProductos();
                WS.ProductoActualizarRPT loWSRPT = loWS.wmActualizarProducto(new WS.ProductoActualizarRQT
                {
                    pnIdePro = toActPro.pnIdePro,
                    pcNomPro = toActPro.pcNomPro,
                    pcDesPro = toActPro.pcDesPro,
                    pnPrePro = toActPro.pnPrePro,
                    pnStoPro = toActPro.pnStoPro,
                    pnIdeSed = toActPro.pnIdeSed
                });

                ProductoActualizarRPT loRPT = new ProductoActualizarRPT
                {
                    pnCodigo = loWSRPT.pnCodigo,
                    pcMensaje = loWSRPT.pcMensaje,
                    pnIdePro = loWSRPT.pnIdePro,
                    pcNomPro = loWSRPT.pcNomPro,
                    pcDesPro = loWSRPT.pcDesPro,
                    pnPrePro = loWSRPT.pnPrePro,
                    pnStoPro = loWSRPT.pnStoPro,
                    pnIdeSed = loWSRPT.pnIdeSed,
                    ptFecPro = loWSRPT.ptFecPro
                };

                return Content((HttpStatusCode)loRPT.pnCodigo, loRPT);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/productos
        [HttpDelete]
        [Route("eliminarProducto")]
        public IHttpActionResult rmEliminarProducto(ProductoEliminarRQT toEliPro)
        {
            try
            {
                if (toEliPro == null)
                    return BadRequest(Constantes._M_CUERPO_SOLICITUD_VACIO);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                WS.WSGestionProductos loWS = new WS.WSGestionProductos();
                WS.ProductoEliminarRPT loWSRPT = loWS.wmEliminarProducto(new WS.ProductoEliminarRQT
                {
                    pnIdePro = toEliPro.pnIdePro
                });

                ProductoEliminarRPT loRPT = new ProductoEliminarRPT
                {
                    pnCodigo = loWSRPT.pnCodigo,
                    pcMensaje = loWSRPT.pcMensaje,
                    pnIdePro = loWSRPT.pnIdePro
                };

                return Content((HttpStatusCode)loRPT.pnCodigo, loRPT);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // TRASLADAR api/productos/trasladar
        [HttpPost]
        [Route("trasladarProducto")]
        public IHttpActionResult rmTrasladarProducto(ProductoTrasladarRQT toTraPro)
        {
            try
            {
                if (toTraPro == null)
                    return BadRequest(Constantes._M_CUERPO_SOLICITUD_VACIO);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                WS.WSGestionProductos loWS = new WS.WSGestionProductos();
                WS.ProductoTrasladarRPT loWSRPT = loWS.wmTrasladarProducto(new WS.ProductoTrasladarRQT
                {
                    pnIdeProOrigen = toTraPro.pnIdeProOrigen,
                    pnCanTraslado = toTraPro.pnCanTraslado,
                    pnIdeSedDestino = toTraPro.pnIdeSedDestino                    
                });

        ProductoTrasladarRPT loRPT = new ProductoTrasladarRPT
                {
                    pnCodigo = loWSRPT.pnCodigo,
                    pcMensaje = loWSRPT.pcMensaje,
                    pnIdeProOrigen = loWSRPT.pnIdeProOrigen,                    
                    pnIdeSedDestino = loWSRPT.pnIdeSedDestino,
                    pnCanTraslado = loWSRPT.pnCanTraslado                    
                };
                return Content((HttpStatusCode)loRPT.pnCodigo, loRPT);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}