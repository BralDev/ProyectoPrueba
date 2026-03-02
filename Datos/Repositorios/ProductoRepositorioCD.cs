using Dapper;
using Datos.Conexion;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Transversal;

namespace Datos.Repositorios
{
    public class ProductoRepositorioCD
    {

        private readonly ConexionCD loConexion;

        public ProductoRepositorioCD()
        {            
            this.loConexion = new ConexionCD();
        }

        public int mxCrearProducto(ProductoCD toPro)
        {
            using (IDbConnection loIConexion = this.loConexion.mxObtenerConexion())
            {
                DynamicParameters loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toPro.cNomPro);
                loParametros.Add("tcDesPro", toPro.cDesPro);
                loParametros.Add("tnPrePro", toPro.nPrePro);
                loParametros.Add("tnStoPro", toPro.nStoPro);
                loParametros.Add("@ttFecPro", toPro.tFecPro);

                return loIConexion.ExecuteScalar<int>(Constantes.SP_PRODUCTO_CREAR, loParametros, commandType: CommandType.StoredProcedure);
            }
        }

        public int mxEliminarProducto(int tnIdePro)
        {
            using (IDbConnection loIConexion = this.loConexion.mxObtenerConexion())
            {
                DynamicParameters loParametros = new DynamicParameters();
                loParametros.Add("tnIdePro", tnIdePro);

                return loIConexion.Execute(Constantes.SP_PRODUCTO_ELIMINAR, loParametros, commandType: CommandType.StoredProcedure);
            }
        }
        public List<ProductoCD> mxObtenerProductos()
        {
            using (IDbConnection loIConexion = this.loConexion.mxObtenerConexion())
            {                
                return loIConexion.Query<ProductoCD>(Constantes.SP_PRODUCTO_LISTAR, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public DateTime mxActualizarProducto(ProductoCD producto)
        {
            using (IDbConnection loIConexion = this.loConexion.mxObtenerConexion())
            {
                DynamicParameters loParametros = new DynamicParameters();
                loParametros.Add("tnIdePro", producto.nIdePro);
                loParametros.Add("tcNomPro", producto.cNomPro);
                loParametros.Add("tcDesPro", producto.cDesPro);
                loParametros.Add("tnPrePro", producto.nPrePro);
                loParametros.Add("tnStoPro", producto.nStoPro);

                return loIConexion.QuerySingleOrDefault<DateTime>(Constantes.SP_PRODUCTAR_EDITAR, loParametros, commandType: CommandType.StoredProcedure);
            }
        }
    }
}