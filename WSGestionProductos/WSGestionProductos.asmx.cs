using Esquema.Esquemas;
using Negocio.Gestores;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;

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

        [WebMethod(Description = "Obtiene la lista de todos los productos.")]
        public ProductosListRPT wmObtenerProductos()
        {
            string lcConexion = ConfigurationManager.ConnectionStrings["SQLConexion"].ConnectionString;
            ProductoGestorCN loProGesCN = new ProductoGestorCN(lcConexion);
            return loProGesCN.mxObtenerProductos();
        }

        [WebMethod(Description = "Crea un nuevo producto.")]
        public ProductoCrearRPT wmCrearProducto(ProductoCrearRQT toCrePro)
        {
            string lcConexion = ConfigurationManager.ConnectionStrings["SQLConexion"].ConnectionString;
            ProductoGestorCN loProGesCN = new ProductoGestorCN(lcConexion);            
            return loProGesCN.mxCrearProducto(toCrePro);
        }

        [WebMethod(Description = "Actualiza un producto existente.")]
        public ProductoActualizarRPT wmActualizarProducto(ProductoActualizarRQT toActPro)
        {
            string lcConexion = ConfigurationManager.ConnectionStrings["SQLConexion"].ConnectionString;
            ProductoGestorCN loProGesCN = new ProductoGestorCN(lcConexion);            
            return loProGesCN.mxActualizarProducto(toActPro);
        }

        [WebMethod(Description = "Elimina un producto por su identificador.")]
        public ProductoEliminarRPT wmEliminarProducto(ProductoEliminarRQT toEliPro)
        {
            string lcConexion = ConfigurationManager.ConnectionStrings["SQLConexion"].ConnectionString;
            ProductoGestorCN loProGesCN = new ProductoGestorCN(lcConexion);           
            return loProGesCN.mxEliminarProducto(toEliPro);
        }
    }
}