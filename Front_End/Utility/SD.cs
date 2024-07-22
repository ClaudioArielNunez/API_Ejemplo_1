namespace Front_End.Utility
{
    public class SD
    {
        //almacenamos num de local host
        public static string ApiMarvel { get; set; } = string.Empty;

        //las peticiones que tendremos
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
