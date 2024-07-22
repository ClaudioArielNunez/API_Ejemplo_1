using static Front_End.Utility.SD;

namespace Front_End.Models
{
    public class RequestDto //Esta es la clase q envia los datos cuando hace la solicitud
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; } = string.Empty; //a la q socilitamos la info
        public object? Data { get; set; } //data q enviamos o no
    }
}
