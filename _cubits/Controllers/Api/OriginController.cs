using _cubits.Data;
using _cubits.Data.Models;
using _cubits.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace _cubits.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OriginController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public OriginController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var originList = _dbContext
                .Set<OriginModel>()
                .ToList();

            var response = originList
                .Select(l => new Origin
                {
                    Id = l.Id,
                    Description = l.Description,
                })
                .ToList();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {

            var origin = _dbContext
                .Set<OriginModel>()
                .Where(l => l.Id == id)
                .FirstOrDefault();

            if (origin == null)
                return NotFound();

            var response = new Origin
            {
                Id = origin.Id,
                Description = origin.Description,

            };

            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] Origin origimParam)
        {
            var origin = new OriginModel
            {
                Description = origimParam.Description
            };

            _dbContext.Add(origin);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = origin.Id }, new { id = origin.Id });
        }
    }
   
}
