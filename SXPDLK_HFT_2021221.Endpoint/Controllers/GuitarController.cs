using Microsoft.AspNetCore.Mvc;
using SXPDLK_HFT_2021221.Logic;
using SXPDLK_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SXPDLK_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GuitarController : ControllerBase
    {
        IGuitarLogic gl;

        public GuitarController(IGuitarLogic gl)
        {
            this.gl = gl;
        }

        // GET: api/<GuitarController>
        [HttpGet]
        public IEnumerable<Guitar> Get()
        {
            return gl.ReadAll();
        }

        // GET api/<GuitarController>/5
        [HttpGet("{id}")]
        public Guitar Get(int id)
        {
            return gl.Read(id);
        }

        // POST api/<GuitarController>
        [HttpPost]
        public void Post([FromBody] Guitar value)
        {
            gl.Create(value);
        }

        // PUT api/<GuitarController>/5
        [HttpPut]
        public void Put([FromBody] Guitar value)
        {
            gl.Update(value);
        }

        // DELETE api/<GuitarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            gl.Delete(id);
        }
    }
}
