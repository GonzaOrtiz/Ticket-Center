using _cubits.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace _cubits.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            var ticketList = new List<Ticket>();
            var ticket = new Ticket();
            var person = new Person();
            var origin = new Origin();
            var destiny = new Destiny();

            person.FirstName = "Lionel";
            person.LastName = "Messi";
            origin.Description = "San Francisco";
            destiny.Description = "Cordoba";

            for (int i = 1; i<= 5; i++)
            {
                ticket.Id = i;
                ticket.Date = DateTime.Now;
                ticket.seatNumber = i + 1;
                ticket.Price = 500;
                //ticket.OriginId = i + i;
                //ticket.DestinyId = i;
                //ticket.PersonId = i;
                ticket.Person = person;
                ticket.Origin = origin;
                ticket.Destiny = destiny;

                ticketList.Add(ticket);
            }

            return View(ticketList);
        }
    }
}
