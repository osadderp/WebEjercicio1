using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace WebApiEjercicio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjercicioDosController : ControllerBase
    {
        Bal.Bal bal;
        public EjercicioDosController()
        {
            bal = new Bal.Bal();
        }
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<int>>> Post([FromBody] RequestP2 request)
        {
            List<int> lst;
            lst = await bal.calcuate2(request);
            return Ok(lst);
        }
    }
}
