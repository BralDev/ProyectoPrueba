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
        public ProductoEntidadCD mxCrearProducto(ProductoEntidadCD toPro, IDbConnection loIConexion, IDbTransaction loTransaccion)
        {                                 
            DynamicParameters loParametros = new DynamicParameters();
            loParametros.Add("tcNomPro", toPro.cNomPro);
            loParametros.Add("tcDesPro", toPro.cDesPro);
            loParametros.Add("tnPrePro", toPro.nPrePro);
            loParametros.Add("tnStoPro", toPro.nStoPro);
            loParametros.Add("@tnIdeSed", toPro.nIdeSed);
            loParametros.Add("@ttFecPro", toPro.tFecPro);

            return loIConexion.QuerySingle<ProductoEntidadCD>(Constantes.SP_PRODUCTO_CREAR, loParametros, transaction: loTransaccion, commandType: CommandType.StoredProcedure);            
        }

        public int mxEliminarProducto(int tnIdePro, IDbConnection loIConexion, IDbTransaction loTransaccion)
        {         
            DynamicParameters loParametros = new DynamicParameters();
            loParametros.Add("tnIdePro", tnIdePro);

            return loIConexion.Execute(Constantes.SP_PRODUCTO_ELIMINAR, loParametros, transaction: loTransaccion, commandType: CommandType.StoredProcedure);
            
        }
   
        public List<ProductoEntidadCD> mxObtenerProductos(IDbConnection loIDbConexion)
        {
            return loIDbConexion.Query<ProductoEntidadCD>(Constantes.SP_PRODUCTO_LISTAR, commandType: CommandType.StoredProcedure).ToList();
        }

        public ProductoEntidadCD mxActualizarProducto(ProductoEntidadCD toPro, IDbConnection loIConexion, IDbTransaction loTransaccion)
        {       
            DynamicParameters loParametros = new DynamicParameters();
            loParametros.Add("tnIdePro", toPro.nIdePro);
            loParametros.Add("tcNomPro", toPro.cNomPro);
            loParametros.Add("tcDesPro", toPro.cDesPro);
            loParametros.Add("tnPrePro", toPro.nPrePro);
            loParametros.Add("tnStoPro", toPro.nStoPro);
            loParametros.Add("@tnIdeSed", toPro.nIdeSed);
            
            return loIConexion.QuerySingle<ProductoEntidadCD>(Constantes.SP_PRODUCTAR_EDITAR, loParametros, transaction: loTransaccion, commandType: CommandType.StoredProcedure);            
        }

        public ProductoEntidadCD mxObtenerProducto(int tnIdePro, IDbConnection loIConexion, IDbTransaction loTransaccion)
        {                        
            DynamicParameters loParametros = new DynamicParameters();
            loParametros.Add("tnIdePro", tnIdePro);

            return loIConexion.QuerySingleOrDefault<ProductoEntidadCD>(Constantes.SP_PRODUCTO_OBTENER, loParametros, transaction: loTransaccion, commandType: CommandType.StoredProcedure);            
        }
    }
}