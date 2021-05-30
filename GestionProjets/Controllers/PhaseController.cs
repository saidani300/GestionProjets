using GestionProjets.Models;
using GestionProjets.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionProjets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Responsable")]
    public class PhaseController : ControllerBase
    {
        private readonly IPhaseRepository _phaseRepository;
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;

        public PhaseController(IPhaseRepository phaseRepository, IProjetRepository projetRepository, IAutorisationRepository autorisationRepository)
        {
            _phaseRepository = phaseRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
        }
        [HttpGet("~/getbyprojet/{id}")]

        public IActionResult GetByProject(Guid id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Mesure1"))
            {
                var phases = _phaseRepository.GetPhasesByProject(id);
                return new OkObjectResult(phases);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var phases = _phaseRepository.GetPhases();
            return new OkObjectResult(phases);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
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
        public IActionResult Delete(Guid id)
        {
            _phaseRepository.DeletePhase(id);
            return new OkResult();
        }
    }
}
