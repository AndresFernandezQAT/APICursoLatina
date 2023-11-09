using APICurso.IDapper;
using APICurso.IRepository;
using APICurso.Models;
using Dapper;
using System.Data;

namespace APICurso.Repository
{
    public class ClientesRepository : IClientesRepository        

    {

        private readonly IDapperContext _context;

        // inyectamos la interfaz de IDapperContext para poder obtener cadena de conexion en cada método
        public ClientesRepository(IDapperContext context)
        {
            _context = context;
        }
        public async Task<int> Crear(Cliente cliente)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@nombre", cliente.Nombre, DbType.String, ParameterDirection.Input);
                param.Add("@telefono", cliente.Telefono, DbType.String, ParameterDirection.Input);
                param.Add("@contacto", cliente.Contacto, DbType.String, ParameterDirection.Input);

                using (var conn = _context.CrearConexion())
                {
                    var id = await conn.QuerySingleAsync<int>("crear_cliente", param, commandType: CommandType.StoredProcedure);                    
                    return id;                   
                }
            }
            catch (Exception)
            {               
                throw;
            }
        }

        public async Task<IEnumerable<Cliente>> ListaClientes()
        {
            try
            {
                using(var conn = _context.CrearConexion())
                {
                    return await conn.QueryAsync<Cliente>("lista_clientes"); 
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Cliente> ObtenerCliente(int id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@id", id, DbType.Int64, ParameterDirection.Input);
                using (var conn = _context.CrearConexion())
                {
                    return await conn.QuerySingleOrDefaultAsync<Cliente>("obtener_cliente", param, commandType: CommandType.StoredProcedure);                
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
