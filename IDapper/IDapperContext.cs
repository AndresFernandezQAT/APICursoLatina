using System.Data;

namespace APICurso.IDapper
{
    public interface IDapperContext
    {
        public IDbConnection CrearConexion();
    }
}
