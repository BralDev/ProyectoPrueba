using System.Data;
using System.Data.SqlClient;

namespace Datos.Conexion
{
    public class ConexionCD
    {
        private readonly string lcUrlConexion;

        public ConexionCD(string tcCadenaConexion)
        {
            this.lcUrlConexion = tcCadenaConexion;
        }

        public IDbConnection mxObtenerConexion() => new SqlConnection(this.lcUrlConexion);
    }
}