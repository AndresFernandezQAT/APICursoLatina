using APICurso.IBLL;
using APICurso.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APICurso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase                                        
    {
        private readonly IClientesBLL _clientesBLL;

        public ClientesController(IClientesBLL clientesBLL)
        {
            _clientesBLL = clientesBLL;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<ResponseListaClientes>> ObtenerClientes()
        {
            try
            {
                var resultado = await _clientesBLL.ListaClientes();
                return resultado;
            }
            catch (Exception)
            {

                ResponseListaClientes responseCliente = new ResponseListaClientes();

                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al obtener la lista de clientes";
                responseCliente.errores = responseModel;
                return responseCliente;

                             
                
            }
        }
        [HttpGet]
        [Route("Obtener")]
        public async Task<ActionResult<ResponseCliente>> ObtenerCliente(int id)
        {
            try
            {
                return await _clientesBLL.ObtenerCliente(id);

            }
            catch (Exception)
            {

                ResponseCliente responseCliente = new ResponseCliente();

                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al buscar el cliente";
                responseCliente.errores = responseModel;
                return new JsonResult(responseCliente);
            }
        }

        [HttpPost]
        [Route("Crear")]
        public async Task<ActionResult<ResponseCliente>> Crear(Cliente cliente)
        {
            try
            {
                var response = await _clientesBLL.Crear(cliente);
                return  new JsonResult(response);
            }
            catch (Exception)
            {
                ResponseCliente responseCliente = new ResponseCliente();

                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al insertar el cliente";
                responseCliente.errores = responseModel;
                return new JsonResult(responseCliente);
            }
        }

        [AcceptVerbs("POST", "PUT")]
        [Route("Actualizar")]
        public async Task<ActionResult<ResponseCliente>> Actualizar(Cliente cliente)
        {
            try
            {
                var response = await _clientesBLL.ActualizarCliente(cliente);
                return new JsonResult(response);
            }
            catch (Exception)
            {

                ResponseCliente responseCliente = new ResponseCliente();

                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al actualizar el cliente";
                responseCliente.errores = responseModel;
                return new JsonResult(responseCliente);
            }
        }

    }
}
        