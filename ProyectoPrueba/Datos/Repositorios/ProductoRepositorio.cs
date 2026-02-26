using Dapper;
using ProyectoPrueba.Datos.Conexion;
using ProyectoPrueba.Datos.Entidades;
using ProyectoPrueba.Datos.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProyectoPrueba.Datos.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {

        private readonly DbConexion conexion;
        public ProductoRepositorio(DbConexion conexion) {

            this.conexion = conexion;

        }
        public int createProducto(Producto producto)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("nombre", producto.Nombre);
                parametros.Add("descripcion", producto.Descripcion);
                parametros.Add("precio", producto.Precio);
                parametros.Add("stock", producto.Stock);

                return conn.Execute("sp_Product_Create", parametros, commandType: CommandType.StoredProcedure);
                
            }
        }

        public int deleteProducto(int id)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("id", id);

                return conn.Execute("sp_Product_Delete", parametros, commandType: CommandType.StoredProcedure);                
            }
        }
        public List<Producto> listProducto()
        {            
            using (var conn = conexion.ObtenerConexion())
            {
                return conn.Query<Producto>("sp_Product_GetAll",commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int updateProducto(Producto producto)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("id", producto.Id);
                parametros.Add("nombre", producto.Nombre);
                parametros.Add("descripcion", producto.Descripcion);
                parametros.Add("precio", producto.Precio);
                parametros.Add("stock", producto.Stock);

                return conn.Execute("sp_EditProcedure", parametros, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
