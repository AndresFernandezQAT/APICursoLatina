using APICurso.IDapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace APICurso.Dapper
{
    public class DapperContext : IDapperContext
    {

        private readonly IConfiguration _iConfiguration;
        private readonly string? _cadenaconexion;
        public DapperContext(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
            _cadenaconexion = _iConfiguration.GetConnectionString("API");           
        }
        public IDbConnection CrearConexion()
        {
            return new SqlConnection(_cadenaconexion);
        }
    }
}
