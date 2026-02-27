using Datos.Conexion;
using Datos.Interfaces;
using Datos.Repositorios;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Negocio.Interfaces;

namespace Negocio.Gestores
{
    public static class GestorProductoFactory
    {
        public static IGestorProducto Crear()
        {            
            DbConexion conexion = new DbConexion();
            IProductoRepositorio repositorio = new ProductoRepositorio(conexion);
            ILogger<GestorProducto> logger = new NullLogger<GestorProducto>();

            return new GestorProducto(repositorio, logger);
        }
    }
}
