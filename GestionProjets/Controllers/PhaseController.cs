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
        [HttpGet("getbyprojet/{id}")]

        public IActionResult GetByProject(Guid id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Phase0"))
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
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Phase1"))
            {
                var phases = _phaseRepository.GetPhases();
            return new OkObjectResult(phases);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Phase2"))
            {
                var phase = _phaseRepository.GetPhaseByID(id);
            return new OkObjectResult(phase);
            }
            else
            {
                return BadRequest();
            }
        }

        internal bool Authorization(Phase phase)
        {

            Guid LoggedInuserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Guid projetId = phase.ProjetId;
            Guid projetChefId = _projetRepository.GetProjetByID(projetId).ChefId;
            Guid projetUserId = _projetRepository.GetProjetByID(projetId).UserId;
            if (projetUserId == LoggedInuserId || projetChefId == LoggedInuserId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] Phase phase)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Phase3"))
            {
                if (Authorization(phase))
                {
                    using (var scope = new TransactionScope())
            {
                _phaseRepository.InsertPhase(phase);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = phase.Id }, phase);
            }
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Phase phase)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Phase4"))
            {
                if (Authorization(phase))
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
                else
                {
                    return BadRequest();
    }
}
            else
{
    return BadRequest();
}
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Phase5"))
            {
                _phaseRepository.DeletePhase(id);
            return new OkResult();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
