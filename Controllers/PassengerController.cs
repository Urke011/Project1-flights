using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Flights.Dtos;
using Flights.ReadModels;
using Flights.Domain.Entities;
using Flights.Data;

namespace Flights.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {

        private readonly Entities _entities;
        public PassengerController(Entities entities)
        {
            _entities = entities;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Register(Domain.Entities.Passenger dto)
        {
            _entities.Passengers.Add(new Domain.Entities.Passenger(
                dto.Email,
                dto.FirstName,
                dto.LastName,
                dto.Gender
                ));
            _entities.SaveChanges();
            // System.Diagnostics.Debug.WriteLine(Passenger.Count);
            return CreatedAtAction(nameof(Find), new { email = dto.Email });
            // throw new NotImplementedException();
        }
        [HttpGet("{email}")]
        public ActionResult<PassengerRm> Find(string email)
        {
            var passenger = _entities.Passengers.FirstOrDefault(x => x.Email == email);

            if (passenger == null)
                return NotFound();

            var rm = new PassengerRm(
                passenger.Email,
                passenger.FirstName,
                passenger.LastName,
                passenger.Gender
                );

            return Ok(rm);
        }
    }
}