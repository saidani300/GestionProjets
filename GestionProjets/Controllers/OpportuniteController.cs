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
        [HttpGet("getbyprojet/{id}")]

        public IActionResult GetByProject(Guid id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Opportunite0"))
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
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Opportunite1"))
            {
                var opportunites = _opportuniteRepository.GetOpportunites();
            return new OkObjectResult(opportunites);
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
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Opportunite2"))
            {
                var opportunite = _opportuniteRepository.GetOpportuniteByID(id);
            return new OkObjectResult(opportunite);
        }
            else
            {
                return BadRequest();
    }
}

        internal bool Authorization(Opportunite opportunite, Guid projetId)
        {

            Guid LoggedInuserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
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
        public IActionResult Post([FromBody] Opportunite opportunite)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Opportunite3"))
            {
                //if (Authorization(opportunite))
                //{
                    using (var scope = new TransactionScope())
            {
                _opportuniteRepository.InsertOpportunite(opportunite);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = opportunite.Id }, opportunite);
            }
                //}
                //else
                //{
                //    return BadRequest();
                //}
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Opportunite opportunite)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Opportunite4"))
            {
                //if (Authorization(opportunite))
                //{
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
                //}
                //else
                //{
                //    return BadRequest();
                //}
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
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Opportunite5"))
            {
                _opportuniteRepository.DeleteOpportunite(id);
            return new OkResult();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
