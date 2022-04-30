using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SXPDLK_HFT_2021221.Endpoint.Services;
using SXPDLK_HFT_2021221.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SXPDLK_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IGuitarLogic gl;
        IBrandLogic bl;
        IPurchaseLogic pl;
        public StatController(IGuitarLogic gl, IBrandLogic bl, IPurchaseLogic pl)
        {
            this.gl = gl;
            this.bl = bl;
            this.pl = pl;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGRatingByCities()
        {
            return pl.AVGRatingByCities();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string,double>>AVGPriceByRanking()
        {
            return gl.AVGPriceByRanking();
        }
        [HttpGet]
        public double AVGPrice()
        {
            return gl.AVGPrice();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string,double>>AVGPriceByBrands()
        {
            return gl.AVGPriceByBrands();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByTypes()
        {
            return gl.AVGPriceByTypes();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGReliabilityByBrands()
        {
            return gl.AVGReliabilityByBrands();
        }
    }
}
