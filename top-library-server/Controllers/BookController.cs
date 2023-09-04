using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;
using top_library_dblayer;
using top_library_models.Models;

namespace top_library_server.Controllers
{
    /// <summary>
    /// Set of methods to manipulate projects
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private EntityGateway _db = new();

        /// <summary>
        /// Returns full info about exissting projects
        /// </summary>
        [HttpGet]
        public IActionResult GetAllBooks() =>
            Ok(new
            {
                status = "ok",
                books = _db.GetBooks().Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Title
                })
            });


        /// <summary>
        /// Get full information about project
        /// </summary>

        [HttpGet("{id:guid}")]

        public IActionResult GetBookById(Guid id)
        {
            var potentialBook = _db.GetBooks().FirstOrDefault(x => x.Id == id);
            if (potentialBook != null)
                return NotFound(new
                {
                    status = "Fail",
                    message = $"Book with id {id} is not found!"
                });
            else
                return Ok(new
                {
                    status = "Ok",
                    book = potentialBook
                });
        }
         
        /// <summary>
        /// Save new project (id should be absent) or update an existing one
        /// </summary>
        [HttpPost]
        public IActionResult PostBook([FromBody] JObject bookJson)
        {
            try
            {
                var book = bookJson.ToObject<Book>() ??
                    throw new Exception("Could not deserialize your object!");
                _db.AddOrUpdate(book);
                return Ok(new
                {
                    status = "Ok",
                    id = book.Id
                });
            }
            catch (Exception E)
            {

                return BadRequest(new
                {
                    status = "Fail",
                    message = E.Message
                });
            }
        }


        /// <summary>
        /// Delete project
        /// </summary>

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBookById(Guid id)
        {
            var potentialBook = _db.GetBooks().FirstOrDefault(x => x.Id == id);
            if (potentialBook is null)
                return NotFound(new
                {
                    status = "Fail",
                    message = $"Book with id {id} is not found!"
                });
            else
            {
                _db.Delete(potentialBook);
                return Ok(new
                {
                    status = "Ok"
                });
            }
        }
    }
}
