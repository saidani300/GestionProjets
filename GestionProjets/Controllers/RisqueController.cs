using GestionProjets.Models;
using GestionProjets.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionProjets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RisqueController : ControllerBase
    {
        private readonly IRisqueRepository _risqueRepository;

        public RisqueController(IRisqueRepository risqueRepository)
        {
            _risqueRepository = risqueRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var risques = _risqueRepository.GetRisques();
            return new OkObjectResult(risques);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var risque = _risqueRepository.GetRisqueByID(id);
            return new OkObjectResult(risque);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Risque risque)
        {
            using (var scope = new TransactionScope())
            {
                _risqueRepository.InsertRisque(risque);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = risque.Id }, risque);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Risque risque)
        {
            if (risque != null)
            {
                using (var scope = new TransactionScope())
                {
                    _risqueRepository.UpdateRisque(risque);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _risqueRepository.DeleteRisque(id);
            return new OkResult();
        }
    }
}
