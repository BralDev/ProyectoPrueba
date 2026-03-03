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

        public ProductoCD mxCrearProducto(ProductoCD toPro)
        {
            DynamicParameters loParametros;            
            using (IDbConnection loIConexion = this.loConexion.mxObtenerConexion())
            {
                loParametros = new DynamicParameters();
                loParametros.Add("tcNomPro", toPro.cNomPro);
                loParametros.Add("tcDesPro", toPro.cDesPro);
                loParametros.Add("tnPrePro", toPro.nPrePro);
                loParametros.Add("tnStoPro", toPro.nStoPro);
                loParametros.Add("@tnIdeSed", toPro.nIdeSed);
                loParametros.Add("@ttFecPro", toPro.tFecPro);

                return loIConexion.QuerySingle<ProductoCD>(Constantes.SP_PRODUCTO_CREAR, loParametros, commandType: CommandType.StoredProcedure);
            }
        }

        public int mxEliminarProducto(int tnIdePro)
        {
            DynamicParameters loParametros;
            using (IDbConnection loIConexion = this.loConexion.mxObtenerConexion())
            {
                loParametros = new DynamicParameters();
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

        public ProductoCD mxActualizarProducto(ProductoCD toPro)
        {
            DynamicParameters loParametros;
            using (IDbConnection loIConexion = this.loConexion.mxObtenerConexion())
            {
                loParametros = new DynamicParameters();
                loParametros.Add("tnIdePro", toPro.nIdePro);
                loParametros.Add("tcNomPro", toPro.cNomPro);
                loParametros.Add("tcDesPro", toPro.cDesPro);
                loParametros.Add("tnPrePro", toPro.nPrePro);
                loParametros.Add("tnStoPro", toPro.nStoPro);
                loParametros.Add("@tnIdeSed", toPro.nIdeSed);

                return loIConexion.QuerySingle<ProductoCD>(Constantes.SP_PRODUCTAR_EDITAR, loParametros, commandType: CommandType.StoredProcedure);
            }
        }

        public ProductoCD mxObtenerProducto(int tnIdePro)
        {
            DynamicParameters loParametros;
            using (IDbConnection loIConexion = this.loConexion.mxObtenerConexion())
            {
                loParametros = new DynamicParameters();
                loParametros.Add("tnIdePro", tnIdePro);
                return loIConexion.QuerySingleOrDefault<ProductoCD>(Constantes.SP_PRODUCTO_OBTENER, loParametros, commandType: CommandType.StoredProcedure);
            }
        }
    }
}