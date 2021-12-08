using _cubits.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _cubits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IMemoryCache _cache;
        private const string CacheKey = "Persons";
        public PersonController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var people = _cache.Get<List<Person>>(CacheKey) ?? new List<Person>();

            return Ok(people);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {

            var people = _cache.Get<List<Person>>(CacheKey) ?? new List<Person>();

            var person = people.Where(x => x.Id == id)
                                .FirstOrDefault();

            return Ok(people);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            var personList = _cache.Get<List<Person>>(CacheKey) ?? new List<Person>();
            var person = personList.Where(p => p.Id == id).FirstOrDefault();

            if (person == null)
                return NotFound();

            personList.Remove(person);

            _cache.Set(CacheKey, personList);

            return Ok(person);
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(Guid id, [FromBody] Person model)
        {
            var persontList = _cache.Get<List<Person>>(CacheKey) ?? new List<Person>();
            var person = persontList.Where(p => p.Id == id).FirstOrDefault();

            if (person == null)
                return NotFound();

            persontList.Remove(person);

            person.FirstName = model.FirstName;
            person.LastName = model.LastName;
            person.Dni = model.Dni;
            person.Email = model.Email;

            persontList.Add(person);

            _cache.Set(CacheKey, persontList);

            return Ok();
        }
    }
}
