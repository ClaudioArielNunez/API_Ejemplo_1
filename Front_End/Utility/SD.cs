namespace Front_End.Utility
{
    public class SD
    {
        //almacenamos num (direccion) de local host
        //Esta en appsetting.json
        //"ServiceUrls": { "ApiMarvel": "https://localhost:7123/"  }
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
