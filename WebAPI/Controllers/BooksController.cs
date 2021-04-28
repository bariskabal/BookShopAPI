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
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _bookService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getpopularbooks")]
        public IActionResult GetPopularBooks()
        {
            var result = _bookService.GetPopularBooks();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getnewestsbooks")]
        public IActionResult GetNewestsBooks()
        {
            var result = _bookService.GetNewestsBooks();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Book book)
        {
            var result = _bookService.Add(book);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _bookService.GetBookDetailsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbyfilter")]
        public IActionResult GetByFilter(string textFilter)
        {
            var result = _bookService.GetBookByFilter(textFilter);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbycategoryid")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _bookService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbyauthorid")]
        public IActionResult GetByAuthor(int authorId)
        {
            var result = _bookService.GetAllByAuthorId(authorId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbyauthorandcategoryid")]
        public IActionResult GetByAuthorIdAndCategoryId(int authorId,int categoryId)
        {
            var result = _bookService.GetByAuthorCategoryId(authorId,categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
