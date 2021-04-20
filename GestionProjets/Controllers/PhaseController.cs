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
    public class PhaseController : ControllerBase
    {
        private readonly IPhaseRepository _phaseRepository;

        public PhaseController(IPhaseRepository phaseRepository)
        {
            _phaseRepository = phaseRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var phases = _phaseRepository.GetPhases();
            return new OkObjectResult(phases);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var phase = _phaseRepository.GetPhaseByID(id);
            return new OkObjectResult(phase);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Phase phase)
        {
            using (var scope = new TransactionScope())
            {
                _phaseRepository.InsertPhase(phase);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = phase.Id }, phase);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Phase phase)
        {
            if (phase != null)
            {
                using (var scope = new TransactionScope())
                {
                    _phaseRepository.UpdatePhase(phase);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _phaseRepository.DeletePhase(id);
            return new OkResult();
        }
    }
}
