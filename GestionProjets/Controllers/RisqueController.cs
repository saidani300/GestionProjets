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

        [HttpGet]
        public IActionResult Get()
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Risque0"))
            {
                var risques = _risqueRepository.GetRisques();
            return new OkObjectResult(risques);
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
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Risque1"))
            {
                var risque = _risqueRepository.GetRisqueByID(id);
            return new OkObjectResult(risque);
            }
            else
            {
                return BadRequest();
            }
        }

        internal bool Authorization(Risque risque)
        {

            Guid LoggedInuserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Guid projetId = risque.ProjetId;
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
        public IActionResult Post([FromBody] Risque risque)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Risque2"))
            {
                if (Authorization(risque))
                {
                    using (var scope = new TransactionScope())
            {
                _risqueRepository.InsertRisque(risque);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = risque.Id }, risque);
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
        public IActionResult Put([FromBody] Risque risque)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Risque3"))
            {
                if (Authorization(risque))
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
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Risque4"))
            {
                _risqueRepository.DeleteRisque(id);
            return new OkResult();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
