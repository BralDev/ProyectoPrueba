using System.Collections.Generic;
using System.Web.Services;
using Negocio.Esquemas;
using Negocio.Gestores;

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
        public ProductosRPT ListarProductos()
        {            
            return _gestorProducto.mxObtenerProductos();
        }

        [WebMethod(Description = "Crea un nuevo producto.")]
        public int CrearProducto(ProductCreateDto dtoProducto)
        {
            return _gestorProducto.mxCrearProducto(dtoProducto);
        }

        [WebMethod(Description = "Actualiza un producto existente.")]
        public int ActualizarProducto(ProductUpdateDto dtoProducto)
        {
            return _gestorProducto.mxActualizarProducto(dtoProducto);
        }

        [WebMethod(Description = "Elimina un producto por su identificador.")]
        public int EliminarProducto(int idProducto)
        {
            return _gestorProducto.mxEliminarProducto(idProducto);
        }
    }
}
