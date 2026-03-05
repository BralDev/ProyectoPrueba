using Dapper;
using Datos.Entidades;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Transversal;

namespace Datos.Repositorios
{
    public class ProductoRepositorioCD
    {
        public ProductoEntidadCD mxCrearProducto(ProductoEntidadCD toPro, IDbConnection toIConexion, IDbTransaction toTransaccion)
        {
            DynamicParameters loParametros = new DynamicParameters();
            loParametros.Add("tcNomPro", toPro.cNomPro);
            loParametros.Add("tcDesPro", toPro.cDesPro);
            loParametros.Add("tnPrePro", toPro.nPrePro);
            loParametros.Add("tnStoPro", toPro.nStoPro);
            loParametros.Add("@tnIdeSed", toPro.nIdeSed);
            loParametros.Add("@ttFecPro", toPro.tFecPro);

            return toIConexion.QuerySingle<ProductoEntidadCD>(Constantes.SP_PRODUCTO_CREAR, loParametros, transaction: toTransaccion, commandType: CommandType.StoredProcedure);
        }

        public int mxEliminarProductoId(int tnIdePro, IDbConnection toIConexion, IDbTransaction toTransaccion)
        {
            DynamicParameters loParametros = new DynamicParameters();
            loParametros.Add("tnIdePro", tnIdePro);

            return toIConexion.Execute(Constantes.SP_PRODUCTO_ELIMINAR, loParametros, transaction: toTransaccion, commandType: CommandType.StoredProcedure);

        }

        public List<ProductoEntidadCD> mxObtenerProductos(IDbConnection toIDbConexion)
        {
            return toIDbConexion.Query<ProductoEntidadCD>(Constantes.SP_PRODUCTO_LISTAR, commandType: CommandType.StoredProcedure).ToList();
        }

        public ProductoEntidadCD mxActualizarProductoId(ProductoEntidadCD toPro, IDbConnection toIConexion, IDbTransaction toTransaccion)
        {
            DynamicParameters loParametros = new DynamicParameters();
            loParametros.Add("tnIdePro", toPro.nIdePro);
            loParametros.Add("tcNomPro", toPro.cNomPro);
            loParametros.Add("tcDesPro", toPro.cDesPro);
            loParametros.Add("tnPrePro", toPro.nPrePro);
            loParametros.Add("tnStoPro", toPro.nStoPro);
            loParametros.Add("@tnIdeSed", toPro.nIdeSed);

            return toIConexion.QuerySingle<ProductoEntidadCD>(Constantes.SP_PRODUCTAR_EDITAR, loParametros, transaction: toTransaccion, commandType: CommandType.StoredProcedure);
        }

        public ProductoEntidadCD mxObtenerProductoId(int tnIdePro, IDbConnection toIConexion, IDbTransaction toTransaccion)
        {
            DynamicParameters loParametros = new DynamicParameters();
            loParametros.Add("tnIdePro", tnIdePro);

            return toIConexion.QuerySingleOrDefault<ProductoEntidadCD>(Constantes.SP_PRODUCTO_OBTENER, loParametros, transaction: toTransaccion, commandType: CommandType.StoredProcedure);
        }

        public int mxObtenerStockProducto(int tnIdePro, int tnIdeSed, IDbConnection toIConexion, IDbTransaction toTransaccion)
        {
            DynamicParameters loParametros = new DynamicParameters();
            loParametros.Add("tnIdePro", tnIdePro);
            loParametros.Add("tnIdeSed", tnIdeSed);
            return toIConexion.QuerySingleOrDefault<int>(Constantes.SP_OBTENER_STOCK_PRODUCTO, loParametros, transaction: toTransaccion, commandType: CommandType.StoredProcedure);
        }

        public int mxValidarProductoNombre(string tcNomPro, int tnIdeSed, IDbConnection toIConexion, IDbTransaction toTransaccion)
        {
            DynamicParameters loParametros = new DynamicParameters();
            loParametros.Add("tcNomPro", tcNomPro);
            loParametros.Add("tnIdeSed", tnIdeSed);
            return toIConexion.QuerySingleOrDefault<int>(Constantes.SP_VALIRDAR_NOMBRE_PRODUCTO, loParametros, transaction: toTransaccion, commandType: CommandType.StoredProcedure);
        }

        public int mxActualizarStockProducto(int tnIdePro, int tnStoPro, int tnIdeSed, IDbConnection toIConexion, IDbTransaction toTransaccion)
        {
            DynamicParameters loParametros = new DynamicParameters();
            loParametros.Add("tnIdePro", tnIdePro);
            loParametros.Add("tnStoPro", tnStoPro);
            loParametros.Add("tnIdeSed", tnIdeSed);
            return toIConexion.Execute(Constantes.SP_ACTUALIZAR_STOCK_PRODUCTO, loParametros, transaction: toTransaccion, commandType: CommandType.StoredProcedure);
        }
    }
}