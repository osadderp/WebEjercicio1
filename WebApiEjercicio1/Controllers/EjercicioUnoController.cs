using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiEjercicio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjercicioUnoController : ControllerBase
    {
        Bal.Bal bal;
        public EjercicioUnoController()
        {
            bal = new Bal.Bal();
        }

        // POST api/<EjercicioUnoController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Respone>> Post([FromBody] Request request)
        {
            Respone respone;
            respone =await bal.calcuate(request);
            return Ok(respone);
        }

        // GET: api/<EjercicioUnoController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<EjercicioUnoController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


        //// PUT api/<EjercicioUnoController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<EjercicioUnoController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
