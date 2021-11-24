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
    public class PurchaseController : ControllerBase
    {
        IPurchaseLogic pl;

        public PurchaseController(IPurchaseLogic pl)
        {
            this.pl = pl;
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
        }

        // PUT api/<PurchaseController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Purchase value)
        {
            pl.Update(value);
        }

        // DELETE api/<PurchaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pl.Delete(id);
        }
    }
}
