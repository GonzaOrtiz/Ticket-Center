using System;

namespace _cubits.Models
{
    public class Person
    {
        public Guid Id{ get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
    }
}
