using _cubits.Data;
using _cubits.Data.Models;
using _cubits.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace _cubits.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TicketController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var ticketList = _dbContext
                .Set<TicketModel>()
                .ToList();

            var response = ticketList
                .Select(l => new Ticket
                {
                    Id = l.Id,
                    Date = l.Date,
                    seatNumber = l.seatNumber,
                    Price = l.Price,
                    OriginProperty = l.OriginProperty,
                    DestinationProperty = l.DestinationProperty,
                    PersonProperty = l.PersonProperty
                })
                .ToList();

            return Ok(response);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {

            var ticket = _dbContext
                .Set<TicketModel>()
                .Where(l => l.Id == id)
                .FirstOrDefault();

            if (ticket == null)
                return NotFound();

            var response = new Ticket
            {
                Id = ticket.Id,
                Date = ticket.Date,
                seatNumber = ticket.seatNumber,
                Price = ticket.Price,
                OriginProperty = ticket.OriginProperty,
                DestinationProperty = ticket.DestinationProperty,
                PersonProperty = ticket.PersonProperty
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] Ticket ticketParam)
        {
            var ticket = new TicketModel
            {
                Date = ticketParam.Date,
                seatNumber = ticketParam.seatNumber,
                Price = ticketParam.Price,
                OriginProperty = ticketParam.OriginProperty,
                DestinationProperty = ticketParam.DestinationProperty,
                PersonProperty = ticketParam.PersonProperty
            };

            _dbContext.Add(ticket);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = ticket.Id }, new { id = ticket.Id });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {

            var ticket = _dbContext
               .Set<TicketModel>()
               .Where(l => l.Id == id)
               .FirstOrDefault();
            if (ticket == null)
                return NotFound();

            _dbContext.Remove(ticket);
            _dbContext.SaveChanges();

            return Ok(ticket);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(Guid id, [FromBody] Ticket model)
        {
            var ticket = _dbContext
           .Set<TicketModel>()
           .Where(l => l.Id == id)
           .FirstOrDefault();
            if (ticket == null)
                return NotFound();

            ticket.Date = model.Date;
            ticket.seatNumber = model.seatNumber;
            ticket.Price = model.Price;
            ticket.OriginProperty = model.OriginProperty;
            ticket.DestinationProperty = model.DestinationProperty;
            ticket.PersonProperty = model.PersonProperty;

            _dbContext.Update(ticket);

            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
