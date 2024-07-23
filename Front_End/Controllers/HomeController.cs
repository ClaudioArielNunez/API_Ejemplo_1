using Front_End.Models;
using Front_End.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Front_End.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMarvelService _marvelService;

        public HomeController(ILogger<HomeController> logger, IMarvelService marvelService)
        {
            _logger = logger;
            _marvelService = marvelService;
        }

        public async Task<IActionResult> IndexAsync()
        {    
            List<MarvelFoto>? photos = new List<MarvelFoto>();

            ResponseDto? response = await _marvelService.GetPhotosAsync();

            if(response != null && response.IsSuccess == true)
            {
                string? jsonPhotos = Convert.ToString(response.Data);
                photos = JsonConvert.DeserializeObject<List<MarvelFoto>>(jsonPhotos);
            }

            return View(photos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}