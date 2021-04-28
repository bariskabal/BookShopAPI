using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookImagesController : ControllerBase
    {
        IBookImageService _bookImageService;
        public BookImagesController(IBookImageService bookImageService)
        {
            _bookImageService = bookImageService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _bookImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _bookImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] BookImage bookImage)
        {
            var result = _bookImageService.Add(file, bookImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery(Name = ("Id"))] int Id)
        {

            var bookImage = _bookImageService.GetById(Id).Data;

            var result = _bookImageService.Delete(bookImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromQuery(Name = ("Id"))] int Id)
        {
            var bookImage = _bookImageService.GetById(Id).Data;
            var result = _bookImageService.Update(file, bookImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
