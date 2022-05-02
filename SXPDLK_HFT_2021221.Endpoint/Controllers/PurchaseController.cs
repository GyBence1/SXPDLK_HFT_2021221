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
    public class PurchaseController : ControllerBase
    {
        IPurchaseLogic pl;
        IHubContext<SignalRHub> hub;
        public PurchaseController(IPurchaseLogic pl, IHubContext<SignalRHub> hub)
        {
            this.pl = pl;
            this.hub = hub;
        }


        // GET: api/<PurchaseController>
        [HttpGet]
        public IEnumerable<Purchase> Get()
        {
            return pl.ReadAll();
        }

        // GET api/<PurchaseController>/5
        [HttpGet("{id}")]
        public Purchase Get(int id)
        {
            return pl.Read(id);
        }

        // POST api/<PurchaseController>
        [HttpPost]
        public void Post([FromBody] Purchase value)
        {
            pl.Create(value);
            hub.Clients.All.SendAsync("PurchaseCreated", value);
        }

        // PUT api/<PurchaseController>/5
        [HttpPut]
        public void Put([FromBody] Purchase value)
        {
            pl.Update(value);
            hub.Clients.All.SendAsync("PurchaseUpdated", value);
        }

        // DELETE api/<PurchaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var asd=this.pl.Read(id);
            pl.Delete(id);
            hub.Clients.All.SendAsync("PurchaseDeleted", asd);
        }
    }
}
