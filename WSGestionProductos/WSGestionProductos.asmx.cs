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

        private readonly GestorProducto _gestorProducto;

        public WSGestionProductos()
        {
            _gestorProducto = new GestorProducto();
        }

        [WebMethod(Description = "Obtiene la lista de todos los productos.")]
        public ProductosListRPT ListarProductos()
        {
            return _gestorProducto.mxObtenerProductos();
        }

        [WebMethod(Description = "Crea un nuevo producto.")]
        public int CrearProducto(ProductoCrearRQT requestProducto)
        {
            ValidarRequest(requestProducto);
            return _gestorProducto.mxCrearProducto(requestProducto);
        }

        private void ValidarRequest<T>(T request)
        {
            if (request == null)
                throw new SoapException("Request nulo.",
                    SoapException.ClientFaultCode);

            var contexto = new ValidationContext(request);
            var errores = new List<ValidationResult>();

            if (!Validator.TryValidateObject(request, contexto, errores, true))
            {
                string mensajes = string.Join(" | ", errores.Select(e => e.ErrorMessage));
                throw new SoapException(
                    $"Validación fallida: {mensajes}",
                    SoapException.ClientFaultCode
                );
            }
        }

        [WebMethod(Description = "Actualiza un producto existente.")]
        public int ActualizarProducto(ProductoActualizarRQT requestProducto)
        {
            ValidarRequest(requestProducto);
            return _gestorProducto.mxActualizarProducto(requestProducto);
        }

        [WebMethod(Description = "Elimina un producto por su identificador.")]
        public int EliminarProducto(int idProducto)
        {
            if (idProducto <= 0)
                throw new SoapException("El ID del producto debe ser mayor a 0.",
                    SoapException.ClientFaultCode);
            return _gestorProducto.mxEliminarProducto(idProducto);
        }
    }
}
