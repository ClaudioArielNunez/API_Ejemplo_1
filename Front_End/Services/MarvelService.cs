using Front_End.Models;
using Front_End.Utility;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Text.Json.Serialization;

namespace Front_End.Services
{
    public class MarvelService
    {
        private readonly IHttpClientFactory clientFactory;

        //crea y administra instancias de http client
        //HttpClient es una clase que permite enviar y recibir solicitudes HTTP
        public MarvelService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        //Este método realiza la mayoría de las operaciones de comunicación con la API.
        private async Task<ResponseDto> SendAsync(RequestDto requestDto)
        {
            //Crea una instancia de ResponseDto para almacenar la respuesta.
            var response = new ResponseDto();
            
            try
            {
                //Crea un HttpClient usando clientFactory y lo llama "MarvelApi". Esto es para hacer solicitudes HTTP.
                HttpClient client = clientFactory.CreateClient("MarvelApi"); //puede ser cualquier nombre

                //Crea un nuevo mensaje de solicitud HTTP (HttpRequestMessage).
                //Agrega un encabezado a la solicitud indicando que espera recibir datos en formato JSON.
                //Establece la URL de la solicitud usando la URL proporcionada en requestDto.
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(requestDto.Url);

                //Si hay datos en requestDto.Data, los convierte a JSON y los agrega al cuerpo de la solicitud.
                if (requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                //Según el tipo de API (requestDto.ApiType), establece el método HTTP de la solicitud (POST, PUT, DELETE o GET).
                switch (requestDto.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                //Envía la solicitud HTTP y espera la respuesta (HttpResponseMessage).
                HttpResponseMessage apiResponse = await client.SendAsync(message);

                //Maneja diferentes códigos de estado HTTP:
                /*
                    NotFound: La solicitud no encontró el recurso.
                    Unauthorized: La solicitud no está autorizada.
                    Forbidden: El acceso está denegado.
                    InternalServerError: Error interno del servidor.
                    Default: Si el código de estado no es uno de los anteriores, lee el contenido de la respuesta,
                    lo convierte a JSON y lo deserializa en ResponseDto.
                 */
                switch (apiResponse.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        response.IsSuccess = false;
                        response.Message = "Not Found";
                        break;
                    case System.Net.HttpStatusCode.Unauthorized:
                        response.IsSuccess = false;
                        response.Message = "Unauthorized";
                        break;
                    case System.Net.HttpStatusCode.Forbidden:
                        response.IsSuccess = false;
                        response.Message = "Access Denied";
                        break;
                    case System.Net.HttpStatusCode.InternalServerError:
                        response.IsSuccess = false;
                        response.Message = "Internal Server Error";
                        break;
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        response = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        break;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
