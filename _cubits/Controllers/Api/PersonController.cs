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
        private readonly ApplicationDbContext _dbContext;

        public PersonController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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

            var person = _dbContext
               .Set<PersonModel>()
               .Where(l => l.Id == id)
               .FirstOrDefault();
            if (person == null)
                return NotFound();

            _dbContext.Remove(person);
            _dbContext.SaveChanges();

            return Ok(person);
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(Guid id, [FromBody] Person model)
        {
            var person = _dbContext
           .Set<PersonModel>()
           .Where(l => l.Id == id)
           .FirstOrDefault();
            if (person == null)
                return NotFound();

            person.FirstName = model.FirstName;
            person.LastName = model.LastName;
            person.Dni = model.Dni;
            person.Email = model.Email;

            _dbContext.Update(person);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
