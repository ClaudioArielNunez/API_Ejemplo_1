﻿using ApiFotos.Data;
using ApiFotos.Models;
using ApiFotos.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;

namespace ApiFotos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarvelFotosController : Controller
    {
        private readonly AppDbContext context;
        private ResponseDto response;

        public MarvelFotosController(AppDbContext context)
        {
            this.context = context;
            this.response = new ResponseDto(); 
        }

        [HttpGet ("GetPhotos")]
        public ResponseDto GetPhotos()
        {
            try
            {
                IEnumerable<MarvelFotos> listaFotos = context.Fotos.ToList();
                response.Data = listaFotos;
            }
            catch (Exception ex)
            {
                //En caso de q haya error
                response.IsSuccess = false;     
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet("GetPhotoById/{id}")]
        public ResponseDto GetPhotoById(int id) 
        {
            try
            {
                var photo = context.Fotos.FirstOrDefault(x => x.Id == id);
                response.Data = photo;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet("GetPhotoByTitle/{titulo}")]
        public ResponseDto GetPhotoByTitle(string titulo)
        {
            try
            {
                var photo = context.Fotos.FirstOrDefault(x => x.Titulo == titulo);
                response.Data = photo;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost("PostPhoto")]
        public ResponseDto PostPhoto([FromBody] MarvelFotos foto)
        {
            try
            {
                context.Fotos.Add(foto);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        //Metodo actualizar el id viene incrustado
        [HttpPut("PutPhoto")]
        public ResponseDto PutPhotoById([FromBody] MarvelFotos foto)
        {
            try
            {
                context.Fotos.Update(foto);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpDelete("DeletePhotoById/{id}")]
        public ResponseDto DeletePhotoById(int id)
        {
            try
            {
                var foto = context.Fotos.FirstOrDefault(x => x.Id == id);
                if (foto != null)
                {
                    context.Fotos.Remove(foto);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message=ex.Message;
            }            
            return response;
        }

    }
}
