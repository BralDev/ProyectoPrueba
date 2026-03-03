using Dapper;
using Datos.Conexion;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal;

namespace Datos.Repositorios
{
    public class SedeRepositorioCD
    {
        private readonly ConexionCD loConexion;

        public SedeRepositorioCD()
        {
            this.loConexion = new ConexionCD();
        }

        public SedeEntidadCD mxObtenerSede(int tnIdeSed)
        {
            DynamicParameters loParametros;
            using (IDbConnection loIConexion = this.loConexion.mxObtenerConexion())
            {
                loParametros = new DynamicParameters();
                loParametros.Add("tnIdeSed", tnIdeSed);
                return loIConexion.QuerySingleOrDefault<SedeEntidadCD>(Constantes.SP_SEDE_OBTENER, loParametros, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
