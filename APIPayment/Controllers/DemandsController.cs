using APIPayment.Domain.Entities;
using APIPayment.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandsController : ControllerBase
    {
        private readonly DemandService _demandService;

        public DemandsController(DemandService demandService)
        {
            _demandService = demandService;
        }

        [HttpPost(Name = "Insert Demand")]
        public Task<ActionResult<Demand>> InsertDemand([FromBody] Demand demand)
        {
            demand.Id = "";
            return _demandService.Handler(demand);
        }
    }
}
