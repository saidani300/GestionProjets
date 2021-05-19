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
    public class OpportuniteController : ControllerBase
    {
        private readonly IOpportuniteRepository _opportuniteRepository;
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;

        public OpportuniteController(IOpportuniteRepository opportuniteRepository, IProjetRepository projetRepository, IAutorisationRepository autorisationRepository)
        {
            _opportuniteRepository = opportuniteRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
        }
        [HttpGet("~/getbyprojet/{id}")]

        public IActionResult GetByProject(Guid id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Mesure1"))
            {
                var opportunites = _opportuniteRepository.GetOpportunitesByProject(id);
                return new OkObjectResult(opportunites);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var opportunites = _opportuniteRepository.GetOpportunites();
            return new OkObjectResult(opportunites);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var opportunite = _opportuniteRepository.GetOpportuniteByID(id);
            return new OkObjectResult(opportunite);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Opportunite opportunite)
        {
            using (var scope = new TransactionScope())
            {
                _opportuniteRepository.InsertOpportunite(opportunite);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = opportunite.Id }, opportunite);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Opportunite opportunite)
        {
            if (opportunite != null)
            {
                using (var scope = new TransactionScope())
                {
                    _opportuniteRepository.UpdateOpportunite(opportunite);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _opportuniteRepository.DeleteOpportunite(id);
            return new OkResult();
        }
    }
}
