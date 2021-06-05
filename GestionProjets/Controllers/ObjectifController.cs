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
    public class ObjectifController : ControllerBase
    {
        private readonly IObjectifRepository _objectifRepository;
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;

        public ObjectifController(IObjectifRepository objectifRepository, IProjetRepository projetRepository, IAutorisationRepository autorisationRepository)
        {
            _objectifRepository = objectifRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
        }

        [HttpGet("getbyprojet/{id}")]

        public IActionResult GetByProject(Guid id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Objectif0"))
            {
                var objectifs = _objectifRepository.GetobjectifsByProject(id);
                return new OkObjectResult(objectifs);
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
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Objectif1"))
            {
                var objectifs = _objectifRepository.GetObjectifs();
            return new OkObjectResult(objectifs);
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
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Objectif2"))
            {
                var objectif = _objectifRepository.GetObjectifByID(id);
            return new OkObjectResult(objectif);
            }
            else
            {
                return BadRequest();
            }
        }

        internal bool Authorization(Objectif objectif)
        {

            Guid LoggedInuserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Guid projetId = objectif.ProjetId;
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
        public IActionResult Post([FromBody] Objectif objectif)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Objectif3"))
            {
                if (Authorization(objectif))
                {
                    using (var scope = new TransactionScope())
            {
                _objectifRepository.InsertObjectif(objectif);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = objectif.Id }, objectif);
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
        public IActionResult Put([FromBody] Objectif objectif)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Objectif4"))
            {
                if (Authorization(objectif))
                {
                    if (objectif != null)
            {
                using (var scope = new TransactionScope())
                {
                    _objectifRepository.UpdateObjectif(objectif);
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

            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Objectif5"))
            {
                _objectifRepository.DeleteObjectif(id);
            return new OkResult();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
