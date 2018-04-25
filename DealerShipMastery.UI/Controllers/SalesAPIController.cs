using DealerShipMastery.Data.ADO;
using DealerShipMastery.Models.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DealerShipMastery.UI.Controllers
{
    public class SalesAPIController : ApiController
    {
        [Route("api/sales/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(decimal? minRate, decimal? maxRate, string make, string model)
        {
            var repo = new MobileSuitRepositoryADO();

            try
            {
                var parameters = new MobileSuitSearchParametersSales()
                {
                    MinRate = minRate,
                    MaxRate = maxRate,
                    Make = make,
                    Model = model,

                };

                var result = repo.SaleSearch(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
