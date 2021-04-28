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
    public class AuthorImagesController : ControllerBase
    {
        IAuthorImageService _authorImageService;
        public AuthorImagesController(IAuthorImageService authorImageService)
        {
            _authorImageService = authorImageService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _authorImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _authorImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyauthorid")]
        public IActionResult GetByAuthorId(int id)
        {
            var result = _authorImageService.GetByAuthorId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] AuthorImage authorImage)
        {
            var result = _authorImageService.Add(file, authorImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery(Name = ("Id"))] int Id)
        {

            var authorImage = _authorImageService.GetById(Id).Data;

            var result = _authorImageService.Delete(authorImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromQuery(Name = ("Id"))] int Id)
        {
            var authorImage = _authorImageService.GetById(Id).Data;
            var result = _authorImageService.Update(file, authorImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
