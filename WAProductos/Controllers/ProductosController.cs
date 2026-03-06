using EsquemaAPI.Esquemas;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using Transversal;
using WS = ReferenciaServicios.WRGestionProductos;

namespace WAProductos.Controllers
{
    [RoutePrefix("api/productos")]
    public class ProductosController : ApiController
    {
        // GET api/productos
        [HttpGet]
        [Route("")]
        public IHttpActionResult waObtenerProductos()
        {
            try
            {
                WS.WSGestionProductos loWS = new WS.WSGestionProductos();
                WS.ProductosListRPT loWSRPT = loWS.wmObtenerProductos();

                if (loWSRPT.pnCodigo == Constantes._M_CODIGO_SIN_CONTENIDO)
                    return StatusCode(HttpStatusCode.NoContent);
                if (loWSRPT.pnCodigo != Constantes._M_CODIGO_EXITOSO)
                    return BadRequest(loWSRPT.pcMensaje);
                
                ProductosListRPT loRPT = new ProductosListRPT
                {
                    pnCodigo = loWSRPT.pnCodigo,
                    pcMensaje = loWSRPT.pcMensaje,
                    paProductos = loWSRPT.paProductos?.Select(p => new ProductoListaCN
                    {
                        pnIdePro = p.pnIdePro,
                        pcNomPro = p.pcNomPro,
                        pcDesPro = p.pcDesPro,
                        pnPrePro = p.pnPrePro,
                        pnStoPro = p.pnStoPro,
                        pnIdeSed = p.pnIdeSed,
                        ptFecPro = p.ptFecPro
                    }).ToArray()
                };

                return Ok(loRPT);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/productos
        [HttpPost]
        [Route("")]
        public IHttpActionResult waCrearProducto(ProductoCrearRQT toProCreRQT)
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

                if (loRPT.pnCodigo == Constantes._M_CODIGO_NO_ENCONTRADO)
                    return NotFound();
                if (loRPT.pnCodigo != Constantes._M_CODIGO_CREDADO)
                    return BadRequest(loRPT.pcMensaje);

                return Created($"api/productos/{loRPT.pnIdePro}", loRPT);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/productos
        [HttpPut]
        [Route("")]
        public IHttpActionResult waActualizarProducto(ProductoActualizarRQT toActPro)
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

                if (loRPT.pnCodigo == Constantes._M_CODIGO_NO_ENCONTRADO)
                    return NotFound();
                if (loRPT.pnCodigo != Constantes._M_CODIGO_EXITOSO)
                    return BadRequest(loRPT.pcMensaje);

                return Ok(loRPT);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/productos
        [HttpDelete]
        [Route("")]
        public IHttpActionResult waEliminarProducto(ProductoEliminarRQT toEliPro)
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

                return StatusCode((HttpStatusCode)loRPT.pnCodigo);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}