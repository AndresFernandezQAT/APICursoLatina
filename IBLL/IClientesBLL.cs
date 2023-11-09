using APICurso.Models;

namespace APICurso.IBLL
{
    public interface IClientesBLL
    {
        public Task<ResponseCliente> Crear(Cliente cliente);
        public Task<ResponseListaClientes> ListaClientes();
        public Task<ResponseCliente> ObtenerCliente(int id);

    }
}
