using Negocio.Esquemas;
using Negocio.Gestores;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace WSGestionProductos
{
    /// <summary>
    /// Descripción breve de WSGestionProductos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSGestionProductos : System.Web.Services.WebService
    {

        private readonly ProductoGestorCN loProGesCN;

        public WSGestionProductos()
        {
            loProGesCN = new ProductoGestorCN();
        }

        [WebMethod(Description = "Obtiene la lista de todos los productos.")]
        public ProductosListRPT mxObtenerProductos()
        {
            return loProGesCN.mxObtenerProductos();
        }

        [WebMethod(Description = "Crea un nuevo producto.")]
        public ProductoCrearRPT mxCrearProducto(ProductoCrearRQT toCrePro)
        {
            mxValidarRequest(toCrePro);
            return loProGesCN.mxCrearProducto(toCrePro);
        }

        [WebMethod(Description = "Actualiza un producto existente.")]
        public ProductoActualizarRPT mxActualizarProducto(ProductoActualizarRQT toActPro)
        {
            mxValidarRequest(toActPro);
            return loProGesCN.mxActualizarProducto(toActPro);
        }

        [WebMethod(Description = "Elimina un producto por su identificador.")]
        public int mxEliminarProducto(int tnIdePro)
        {
            if (tnIdePro <= 0)
                throw new SoapException("El ID del producto debe ser mayor a 0.",
                    SoapException.ClientFaultCode);
            return loProGesCN.mxEliminarProducto(tnIdePro);
        }

        private void mxValidarRequest<T>(T toRequest)
        {
            if (toRequest == null)
                throw new SoapException("Request nulo.",
                    SoapException.ClientFaultCode);

            ValidationContext loContexto = new ValidationContext(toRequest);
            List<ValidationResult> loErrLst = new List<ValidationResult>();

            if (!Validator.TryValidateObject(toRequest, loContexto, loErrLst, true))
            {
                string lcMensajes = string.Join(" | ", loErrLst.Select(e => e.ErrorMessage));
                throw new SoapException(
                    $"Validación fallida: {lcMensajes}",
                    SoapException.ClientFaultCode
                );
            }
        }
    }
}
