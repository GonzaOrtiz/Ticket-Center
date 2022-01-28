﻿using System;

namespace _cubits.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int seatNumber { get; set; }
        public decimal Price { get; set; }
        public string OriginProperty { get; set; }
        public string DestinationProperty { get; set; }
        public string PersonProperty { get; set; }

    }
}
