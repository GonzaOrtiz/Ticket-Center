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

        public IActionResult Index()
        {       
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
