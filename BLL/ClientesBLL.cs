using APICurso.IBLL;
using APICurso.IRepository;
using APICurso.Models;
using System.Diagnostics;

namespace APICurso.BLL
{
    public class ClientesBLL : IClientesBLL
    {
        private readonly IClientesRepository _clientesRepository;

        public ClientesBLL(IClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        public async Task<ResponseCliente> ActualizarCliente(Cliente cliente)
        {
            try
            {
                var clienteactualizado = await _clientesRepository.ActualizarCliente(cliente);
                ResponseCliente responseCliente = new ResponseCliente();
                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = 0;
                responseModel.errormsg = "Cliente actualizado con éxito";

                responseCliente.cliente = clienteactualizado;
                responseCliente.errores = responseModel;
                return responseCliente;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseCliente> Crear(Cliente cliente)
        {
            try
            {
                var id =  await _clientesRepository.Crear(cliente);

                cliente.Id = id;

                ResponseCliente responseCliente = new ResponseCliente();
                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = 0;
                responseModel.errormsg = "Cliente creado con éxito";

                responseCliente.cliente = cliente;
                responseCliente.errores = responseModel;
                return responseCliente;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<ResponseListaClientes> ListaClientes()
        {
            try
            {
                var listaClientes =  await _clientesRepository.ListaClientes();

                ResponseListaClientes responseLista = new ResponseListaClientes();
                ResponseModel responseModel = new ResponseModel();
                responseLista.clientes = listaClientes.ToList();
                responseModel.errorcode = 0;
                responseModel.errormsg = "Lista de clientes devuelta con éxito";

                responseLista.errores = responseModel;

                return responseLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseCliente> ObtenerCliente(int id)
        {
            try
            {
                var cliente = await _clientesRepository.ObtenerCliente(id);

                ResponseCliente responseCliente = new ResponseCliente();
                ResponseModel responseModel = new ResponseModel();


                if (cliente != null)
                {
                    responseCliente.cliente = cliente;
                    responseModel.errorcode = 0;
                    responseModel.errormsg = "Cliente encontrado con éxito";
                    
                }
                else
                {
                    responseModel.errorcode = 1;
                    responseModel.errormsg = "No se ha podido encontrar el cliente con código: " + id.ToString();
                }
               
                responseCliente.errores = responseModel;
                return responseCliente;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
