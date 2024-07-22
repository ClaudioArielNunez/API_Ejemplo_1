namespace Front_End.Models
{
    public class ResponseDto //Esta es la info que envia la api al front
    {
        public object? Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
