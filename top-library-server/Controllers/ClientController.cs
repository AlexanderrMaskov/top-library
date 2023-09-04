using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using top_library_dblayer;

namespace top_library_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private EntityGateway _db = new();

        [HttpGet]
        public IActionResult GetAllClients() =>
            Ok(new
            {
                status = "ok",
                clients = _db.GetClients().Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Phone
                })
            });

        [HttpGet("{id:guid}")]

        public IActionResult GetClientById(Guid id)
        {
            var potentialClient = _db.GetClients().FirstOrDefault(x => x.Id == id);
            if (potentialClient != null)
                return NotFound(new
                {
                    status = "Fail",
                    message = $"Client with id {id} is not found!"
                });
            else
                return Ok(new
                {
                    status = "Ok",
                    client = potentialClient
                });
        }
    }
}
