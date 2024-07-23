using Front_End.Models;

namespace Front_End.Services.IServices
{
    //La carpeta Services es la q ejerce la comunicacion con la Api
    //Los servicios no se implementan a traves de clases, sino de interfaces
    public interface IMarvelService
    {
        //Traemos todos los metodos
        Task<ResponseDto> GetPhotosAsync();
        Task<ResponseDto> GetPhotoByIdAsync(int id);
        Task<ResponseDto> GetPhotoByTitleAsync(string title);
        Task<ResponseDto> PostPhotoAsync(MarvelFoto photo);
        Task<ResponseDto> PutPhotoAsync(MarvelFoto photo);
        Task<ResponseDto> DeletePhotoByIdAsync(int id);
    }
}
