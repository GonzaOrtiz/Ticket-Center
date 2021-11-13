using _cubits.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _cubits.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            var movieList = new List<Movie>();
            var movie = new Movie();

            movie.Id = 1;
            movie.Name = "Venom";

            var lap = 0;
            while (lap < 20)
            {
                lap++;

                movie.Id = lap;
                movie.Name = "Venom" + lap;
                movieList.Add(movie);
            }

            return View(movieList);
        }
    }
}
