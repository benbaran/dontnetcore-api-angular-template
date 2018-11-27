using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Person;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace web.Controllers
{


    // I like my API paths to be all lowercase, feel free to use the default though
    //[Route("api/[controller]")]

    //[Authorize]
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // Add an ILogger for dependancy injection
        private ILogger<PersonController> _logger;
        private IPersonService _service;

        // Add a constructor for dependancy injection
        public PersonController(ILogger<PersonController> logger, IPersonService service)
        {
            _logger = logger;
            _service = service;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return Ok(_service.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(Guid id)
        {
            return _service.Read(id);
        }

    // GET api/patient/search/{term}
    [HttpGet("search/{term}")]
    public ActionResult<Person> Search(string term)
    {
      return Ok(_service.Find(term));
    }

    // POST api/values
    [HttpPost]
        public void Post([FromBody] string value)
        {
            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
        }
    }
}
