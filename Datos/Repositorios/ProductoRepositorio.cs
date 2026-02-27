using Dapper;
using Datos.Conexion;
using Datos.Entidades;
using Datos.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Transversal;

namespace Datos.Repositorios
{
    public class ProductoRepositorio
    {

        private readonly DbConexion conexion;

        public ProductoRepositorio()
        {
            DbConexion conexion = new DbConexion();
            this.conexion = conexion;
        }

        public int createProducto(ProductoCD producto)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("tcNomPro", producto.cNomPro);
                parametros.Add("tcDesPro", producto.cDesPro);
                parametros.Add("tnPrePro", producto.nPrePro);
                parametros.Add("tnStoPro", producto.nStoPro);

                return conn.Execute(Constantes.SP_PRODUCTO_CREAR, parametros, commandType: CommandType.StoredProcedure);

            }
        }

        public int deleteProducto(int id)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("tnIdePro", id);

                return conn.Execute(Constantes.SP_PRODUCTO_ELIMINAR, parametros, commandType: CommandType.StoredProcedure);
            }
        }
        public List<ProductoCD> listProducto()
        {
            using (var conn = conexion.ObtenerConexion())
            {
                return conn.Query<ProductoCD>(Constantes.SP_PRODUCTO_LISTAR, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int updateProducto(ProductoCD producto)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("tnIdePro", producto.nIdePro);
                parametros.Add("tcNomPro", producto.cNomPro);
                parametros.Add("tcDesPro", producto.cDesPro);
                parametros.Add("tnPrePro", producto.nPrePro);
                parametros.Add("tnStoPro", producto.nStoPro);

                return conn.Execute(Constantes.SP_PRODUCTAR_EDITAR, parametros, commandType: CommandType.StoredProcedure);
            }
        }
    }
}