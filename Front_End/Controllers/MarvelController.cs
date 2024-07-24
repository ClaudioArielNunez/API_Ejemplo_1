using Front_End.Models;
using Front_End.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace Front_End.Controllers
{
   
    public class MarvelController : Controller  
    {
        private readonly IMarvelService _marvelService;
        public MarvelController(IMarvelService marvelService)
        {
            _marvelService = marvelService;
        }
                

        public async Task<IActionResult> MarvelIndex()
        {
            List<MarvelFoto>? photos = new List<MarvelFoto>();
            ResponseDto? response = await _marvelService.GetPhotosAsync();

            if (response != null && response.IsSuccess == true)
            {
                string? jsonPhotos = Convert.ToString(response.Data);
                photos = JsonConvert.DeserializeObject<List<MarvelFoto>>(jsonPhotos);
            }
            return View(photos);
        }

        public async Task<IActionResult> MarvelCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MarvelCreate(MarvelFoto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _marvelService.PostPhotoAsync(model);

                if(response != null && response.IsSuccess == true)
                {
                    return RedirectToAction(nameof(MarvelIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> MarvelDelete(int id)
        {
            
            ResponseDto? response = await _marvelService.GetPhotoByIdAsync(id);

            if(response != null && response.IsSuccess == true)
            {
                string? jsonPhoto = (string)response.Data;
                MarvelFoto? model = JsonConvert.DeserializeObject<MarvelFoto>(jsonPhoto);

                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> MarvelDelete(MarvelFoto model)
        {
            ResponseDto? response = await _marvelService.DeletePhotoByIdAsync(model.Id);

            if (response != null && response.IsSuccess == true)
            {
                return RedirectToAction(nameof(MarvelIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> MarvelEdit(int id)
        {
            ResponseDto? response = await _marvelService.GetPhotoByIdAsync(id);
            if(response != null && response.IsSuccess == true)
            {
                string jsonPhoto = Convert.ToString(response.Data);
                MarvelFoto? model = JsonConvert.DeserializeObject<MarvelFoto>(jsonPhoto);
				

				return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> MarvelEdit(MarvelFoto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _marvelService.PutPhotoAsync(model);
                if(response != null && response.IsSuccess == true)
                {
                    return RedirectToAction(nameof(MarvelIndex));
                }
            }

            return View(model);
        }
    }
}
