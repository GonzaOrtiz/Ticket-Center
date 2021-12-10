using _cubits.Data;
using _cubits.Data.Models;
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
        private readonly ApplicationDbContext _dbContext;

        public PersonController(ApplicationDbContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }
        //public PersonController(e)
        //{
        //    _cache = cache;
        //}

        //[HttpGet]
        //[Route("")]
        //public IActionResult GetAll()
        //{
        //    var people = _cache.Get<List<Person>>(CacheKey) ?? new List<Person>();

        //    return Ok(people);
        //}

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var personList = _dbContext
                .Set<PersonModel>()
                .ToList();

            var response = personList
                .Select(l => new Person
                {
                    Id = l.Id,
                    FirstName = l.FirstName,
                    LastName = l.LastName,
                    Email = l.Email,
                    Dni = l.Dni
                })
                .ToList();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            //var productList = _cache.Get<List<Person>>(CacheKey) ?? new List<Person>();
            //var product = productList.Where(p => p.Id == id).FirstOrDefault();

            //if (product == null)
            //    return NotFound();

            //return Ok(product);

            var person = _dbContext
                .Set<PersonModel>()
                .Where(l => l.Id == id)
                .FirstOrDefault();

            if (person == null)
                return NotFound();

            var response = new Person
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Dni = person.Dni
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] Person personParam)
        {
            var person = new PersonModel
            {
                FirstName = personParam.FirstName,
                LastName = personParam.LastName,
                Email = personParam.Email,
                Dni = personParam.Dni
            };

            _dbContext.Add(person);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = person.Id }, new { id = person.Id });
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
