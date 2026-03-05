using Dapper;
using Datos.Entidades;
using System.Data;
using Transversal;

namespace Datos.Repositorios
{
    public class SedeRepositorioCD
    {

        public SedeEntidadCD mxObtenerSede(int tnIdeSed, IDbConnection toIConexion, IDbTransaction toTransaccion)
        {
             DynamicParameters loParametros = new DynamicParameters();
             loParametros.Add("tnIdeSed", tnIdeSed);
             return toIConexion.QuerySingleOrDefault<SedeEntidadCD>(Constantes.SP_SEDE_OBTENER, loParametros, transaction: toTransaccion, commandType: CommandType.StoredProcedure);            
        }
    }
}