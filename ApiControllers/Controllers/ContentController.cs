using ApiControllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllers.Controllers
{
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        [HttpGet("string")]
        public string GetString() => "Это строковый ответ";

        [HttpGet("object/{format?}")]
        [FormatFilter]
        public Reservation GetObject() => new Reservation
        {
            ReservationId = 100,
            ClientName = "Джо",
            Location = "Зал заседаний"
        };

        [HttpPost]
        [Consumes("application/json")]
        public Reservation ReseiveJson([FromBody] Reservation reservation)
        {
            reservation.ClientName = "Json";
            return reservation;
        }

        [HttpPost]
        [Consumes("application/xml")]
        public Reservation ReseiveXml([FromBody] Reservation reservation)
        {
            reservation.ClientName = "Xml";
            return reservation;
        }
    }
}
