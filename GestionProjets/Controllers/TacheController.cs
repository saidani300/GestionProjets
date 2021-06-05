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
    [Authorize(Roles = "Responsable,Chefdeprojet")]
    public class TacheController : ControllerBase
    {
        private readonly ITacheRepository _tacheRepository;
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;

        public TacheController(ITacheRepository tacheRepository  , IProjetRepository projetRepository, IAutorisationRepository autorisationRepository)
        {
            _tacheRepository = tacheRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
        }
        [HttpGet("getbyprojet/{id}")]

        public IActionResult GetByProject(Guid id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Tache0"))
            {
                var taches = _tacheRepository.GetTachesByProject(id);
                return new OkObjectResult(taches);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("getbyAction/{id}")]

        public IActionResult GetByAction(Guid id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Tache1"))
            {
                var taches = _tacheRepository.GetTachesByAction(id);
                return new OkObjectResult(taches);
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
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Tache2"))
            {
                var taches = _tacheRepository.GetTaches();
            return new OkObjectResult(taches);
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
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Tache3"))
            {
                var tache = _tacheRepository.GetTacheByID(id);
            return new OkObjectResult(tache);
        }
            else
            {
                return BadRequest();
    }

}

        internal bool Authorization(Tache tache)
        {

            Guid LoggedInuserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Guid projetId = tache.ProjetId;
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
        public IActionResult Post([FromBody] Tache tache)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Tache4"))
            {
                if (Authorization(tache))
                {
                    using (var scope = new TransactionScope())
            {
                _tacheRepository.InsertTache(tache);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = tache.Id }, tache);
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
        [Authorize(Roles = "Responsable,Chefdeprojet,Membre")]
        [HttpPut]
        public IActionResult Put([FromBody] Tache tache)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Tache5"))
            {
                if (Authorization(tache))
                {
                    if (tache != null)
            {
                using (var scope = new TransactionScope())
                {
                    _tacheRepository.UpdateTache(tache);
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
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Tache6"))
            {
                _tacheRepository.DeleteTache(id);
            return new OkResult();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
