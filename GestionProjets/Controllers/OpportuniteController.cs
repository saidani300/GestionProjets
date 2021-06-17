using GestionProjets.AuthorizationAttributes;
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
        [Ref("Opportunite0")]

        public IActionResult GetByProject(Guid id)
        {
            
                var opportunites = _opportuniteRepository.GetOpportunitesByProject(id);
                return new OkObjectResult(opportunites);
            
        }

        [HttpGet]
        [Ref("Opportunite1")]
        public IActionResult Get()
        {
            
                var opportunites = _opportuniteRepository.GetOpportunites();
            return new OkObjectResult(opportunites);
           
        }

        [HttpGet("{id}")]
        [Ref("Opportunite2")]
        public IActionResult Get(Guid id)
        {
           
                var opportunite = _opportuniteRepository.GetOpportuniteByID(id);
            return new OkObjectResult(opportunite);
        
}

        internal bool Authorization(Opportunite opportunite, Guid projetId)
        {

            Guid LoggedInuserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Guid projetChefId = (Guid)_projetRepository.GetProjetByID(projetId).ChefId;
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
        [Ref("Opportunite3")]
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
        [Ref("Opportunite4")]
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
        [Ref("Opportunite5")]
        public IActionResult Delete(Guid id)
        {
            
                _opportuniteRepository.DeleteOpportunite(id);
            return new OkResult();
            
        }
    }
}
