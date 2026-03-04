using Dapper;
using Datos.Entidades;
using System.Data;
using Transversal;

namespace Datos.Repositorios
{
    public class SedeRepositorioCD
    {

        public SedeEntidadCD mxObtenerSede(int tnIdeSed, IDbConnection loIConexion, IDbTransaction loTransaccion)
        {
             DynamicParameters loParametros = new DynamicParameters();
             loParametros.Add("tnIdeSed", tnIdeSed);
             return loIConexion.QuerySingleOrDefault<SedeEntidadCD>(Constantes.SP_SEDE_OBTENER, loParametros, transaction: loTransaccion, commandType: CommandType.StoredProcedure);            
        }
    }
}