namespace APICurso.Models
{
    public class ResponseListaClientes
    {
        public  List<Cliente> clientes { get; set; } = new List<Cliente>();
        public ResponseModel errores { get; set; } = new ResponseModel();

    }
}
