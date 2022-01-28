using _cubits.Data;
using _cubits.Data.Models;
using _cubits.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace _cubits.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public DestinationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var destination = _dbContext.Destiny.ToList();

            return Ok(destination);
        }
    }
}
