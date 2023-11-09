namespace APICurso.Models
{
    public class ResponseCliente
    {
        public Cliente cliente { get; set; } = new Cliente();
        public ResponseModel errores { get; set; } = new ResponseModel();  
    }
}
