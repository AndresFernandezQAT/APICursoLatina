using APICurso.Models;

namespace APICurso.IRepository
{
    public interface IClientesRepository
    {
        public Task<int> Crear(Cliente cliente);
        public Task<IEnumerable<Cliente>> ListaClientes();

        public Task<Cliente> ObtenerCliente(int id);
        public Task<Cliente> ActualizarCliente(Cliente cliente);


    }
}
