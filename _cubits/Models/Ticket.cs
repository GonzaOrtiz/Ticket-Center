using System;

namespace _cubits.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int seatNumber { get; set; }
        public decimal Price { get; set; }
        public int PersonId { get; set; }
        public int OriginId { get; set; }
        public int DestinyId { get; set; }
        public Person Person { get; set; }
        public Origin Origin { get; set; }
        public Destiny Destiny { get; set; }

    }
}
