using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using top_library_dblayer;

namespace top_library_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private EntityGateway _db = new();

        [HttpGet]
        public IActionResult GetAllRooms() =>
    Ok(new
    {
        status = "ok",
        rooms = _db.GetRooms().Select(x => new
        {
            x.Id,
            x.Name
        })
    });

        [HttpGet("{id:guid}")]

        public IActionResult GetRoomById(Guid id)
        {
            var potentialRoom = _db.GetRooms().FirstOrDefault(x => x.Id == id);
            if (potentialRoom != null)
                return NotFound(new
                {
                    status = "Fail",
                    message = $"Room with id {id} is not found!"
                });
            else
                return Ok(new
                {
                    status = "Ok",
                    room = potentialRoom
                });
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteRoomById(Guid id)
        {
            var potentialRoom = _db.GetRooms().FirstOrDefault(x => x.Id == id);
            if (potentialRoom is null)
                return NotFound(new
                {
                    status = "Fail",
                    message = $"Room with id {id} is not found!"
                });
            else
            {
                _db.Delete(potentialRoom);
                return Ok(new
                {
                    status = "Ok"
                });
            }
        }
    }
}
