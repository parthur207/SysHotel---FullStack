using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SysHotel.API.Controllers.Queries
{
    [Route("api/user")]
    [ApiController]
    public class UserQueriesController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> PostLogin([FromBody] Create)
        {

            return Ok();
        }

        // GET api/<UserController>/5
        [HttpGet("{idUser}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
