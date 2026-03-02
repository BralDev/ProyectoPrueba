using System.Data;
using System.Data.SqlClient;

namespace Datos.Conexion
{
    public class ConexionCD
    {
        private readonly string lcUrlConexion;

        public ConexionCD()
        {

            this.lcUrlConexion = "Server=localhost;Database=PRUEBA;Trusted_Connection=True; Integrated Security = True; TrustServerCertificate = True; ";
        }

        public IDbConnection mxObtenerConexion() => new SqlConnection(lcUrlConexion);
    }
}