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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionProjets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Responsable")]
    public class RisqueController : ControllerBase
    {
        private readonly IRisqueRepository _risqueRepository;
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;

        public RisqueController(IRisqueRepository risqueRepository, IProjetRepository projetRepository, IAutorisationRepository autorisationRepository)
        {
            _risqueRepository = risqueRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
        }

        [HttpGet("getbyprojet/{id}")]
        [Ref("Risque0")]

        public IActionResult GetByProject(Guid id)
        {
           
                var Risques = _risqueRepository.GetRisquesByProjet(id);
                return new OkObjectResult(Risques);
            
        }


        [HttpGet]
        [Ref("Risque1")]

        public IActionResult Get()
        {
            
                var risques = _risqueRepository.GetRisques();
            return new OkObjectResult(risques);
           
        }

        [HttpGet("{id}")]
        [Ref("Risque2")]

        public IActionResult Get(Guid id)
        {
           
                var risque = _risqueRepository.GetRisqueByID(id);
            return new OkObjectResult(risque);
           
        }

        internal bool Authorization(Risque risque, Guid projetId)
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
        [Ref("Risque3")]

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
        [Ref("Risque4")]

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
        [Ref("Risque4")]

        public IActionResult Delete(Guid id)
        {
           
                _risqueRepository.DeleteRisque(id);
            return new OkResult();
           
        }
    }
}
