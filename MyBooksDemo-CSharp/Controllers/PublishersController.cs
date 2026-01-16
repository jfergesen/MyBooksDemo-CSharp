using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooksDemo_CSharp.Data.Services;
using MyBooksDemo_CSharp.Data.ViewModels;

namespace MyBooksDemo_CSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publishersService;
        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;                
        }
        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers() { 
            var allPublishers = _publishersService.GetAllPublishers();
            return Ok(allPublishers);
        }

        [HttpPost("add-publisher")]
        public IActionResult AddBook([FromBody] PublisherVM publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok();
        }

        [HttpGet("get-publisher-books-with-authors/{publisherId}")]
        public IActionResult GetPublisherData(int publisherId)
        {
            var response = _publishersService.GetPublisherData(publisherId);
            return Ok(response);
        }
        [HttpGet("delete-publisher-by-id/{id}")]
        public IActionResult DeletPublisherById(int id)
        {
            _publishersService.DeletePublisherById(id);
            return Ok();
        }

    }
}
