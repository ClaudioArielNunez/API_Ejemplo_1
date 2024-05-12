namespace ApiFotos.Models.Dto
{
    //Nos va a servir para estandarizar la respuesta a las solicitudes que le hagamos
    public class ResponseDto
    {
        public object? Data { get;set; } //puede devolver vacio
        public bool IsSuccess { get; set; } = true; //por defecto devuelve true
        public string Message { get; set; } = ""; //por defecto devuelve vacio
    }
    /*
     Data: Esta propiedad puede contener cualquier tipo de datos (debido a que su 
    tipo es object), lo que la hace muy flexible. El signo de interrogación (?) indica
    que la propiedad puede contener null, permitiendo que la propiedad esté vacía si 
    no hay datos para devolver.
    Uso: Utilizada para devolver los datos solicitados. Por ejemplo, podría contener 
    una lista de fotos, un único objeto foto, un mensaje de error, etc.
     */
    /*
     IsSuccess:Es útil para control de flujo en el cliente que consume la API. 
    El cliente puede verificar esta propiedad para decidir cómo proceder después de 
    recibir la respuesta. Si IsSuccess es false, el cliente puede manejar el error de 
    manera adecuada.
     */
}
