using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooksDemo_CSharp.Data.Services;
using MyBooksDemo_CSharp.Data.ViewModels;

namespace MyBooksDemo_CSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorsService;
        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;                
        }

        [HttpGet("get-all-authors")]
        public IActionResult GetAllAuthors()
        {
            var allAuthors = _authorsService.GetAllAuthors();
            return Ok(allAuthors);
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok();
        }
        [HttpGet("get-author-with-books-by-id/{authorid}")]
        public IActionResult GetAuthorWithBooks(int authorid)
        {
            var response = _authorsService.GetAuthorWithBooks(authorid);
            return Ok(response);
        }

    }
}
