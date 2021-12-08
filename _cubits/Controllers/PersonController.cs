using _cubits.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _cubits.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IMemoryCache _cache;
        private const string CacheKey = "Persons";

        public PersonsController(IMemoryCache cache)
        {
            _cache = cache;

        }
        public IActionResult Index()
        {
            var persons = _cache.Get<List<Person>>(CacheKey) ?? new List<Person>();         

            return View(persons);
        }
        [HttpPost]
        public IActionResult Create(Person model)
        {
            model.Id =  Guid.NewGuid();
            var people = _cache.Get<List<Person>>(CacheKey) ?? new List<Person>();
            people.Add(model);
            _cache.Set(CacheKey, people);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Person model)
        {
            var people = _cache.Get<List<Person>>(CacheKey) ?? new List<Person>();

            var person = people.Where(x => x.Id == model.Id)
                                .FirstOrDefault();

            people.Remove(person);

            person.FirstName = model.FirstName;
            person.LastName = model.LastName;
            person.Email = model.Email;
            person.Dni = model.Dni;

            people.Add(person);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var people = _cache.Get<List<Person>>(CacheKey) ?? new List<Person>();

            var person = people.Where(x => x.Id == id)
                                .FirstOrDefault();


            return View(person);
        }
        public IActionResult Detail()
        {

            return View();
        }
        public IActionResult Delete(Guid id)
        {
            var people = _cache.Get<List<Person>>(CacheKey) ?? new List<Person>();
            var person = people.Where(x => x.Id == id)
                    .FirstOrDefault();

            people.Remove(person);


            return RedirectToAction("Index");
        }
    }
}
