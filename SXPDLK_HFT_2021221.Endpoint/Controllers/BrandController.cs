using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SXPDLK_HFT_2021221.Endpoint.Services;
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
    public class BrandController : ControllerBase
    {
        IBrandLogic bl;
        IHubContext<SignalRHub> hub;
        public BrandController(IBrandLogic bl, IHubContext<SignalRHub> hub)
        {
            this.hub= hub;
            this.bl = bl;
        }
        // GET: /brand
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return bl.ReadAll();
        }

        // GET /brand/5
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return bl.Read(id);
        }

        // POST /brand
        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            bl.Create(value);
            hub.Clients.All.SendAsync("BrandCreated", value);
        }

        // PUT /brand
        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            bl.Update(value);
            hub.Clients.All.SendAsync("BrandUpdated", value);
        }

        // DELETE /brand/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var did=this.bl.Read(id);
            bl.Delete(id);
            hub.Clients.All.SendAsync("BrandDeleted", did);
        }
    }
}
