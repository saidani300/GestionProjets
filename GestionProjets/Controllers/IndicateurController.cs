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
    public class IndicateurController : ControllerBase
    {
        private readonly IIndicateurRepository _indicateurRepository;
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;

        public IndicateurController(IIndicateurRepository indicateurRepository, IProjetRepository projetRepository, IAutorisationRepository autorisationRepository)
        {
            _indicateurRepository = indicateurRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
        }

        internal bool Authorization(Indicateur indicateur)
        {

            Guid LoggedInuserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Guid projetId = indicateur.ProjetId;
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

        [HttpGet]
        public IActionResult Get()
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Indicateur0"))
            {
                    var indicateurs = _indicateurRepository.GetIndicateurs();
            return new OkObjectResult(indicateurs);
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

            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Indicateur1"))
            {
                var indicateur = _indicateurRepository.GetIndicateurByID(id);
            return new OkObjectResult(indicateur);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Indicateur indicateur)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Indicateur2"))
            {
                if (Authorization(indicateur))
                {
                    using (var scope = new TransactionScope())
            {
                _indicateurRepository.InsertIndicateur(indicateur);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = indicateur.Id }, indicateur);
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
        public IActionResult Put([FromBody] Indicateur indicateur)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Indicateur3"))
            {
                if (Authorization(indicateur))
                {
                    if (indicateur != null)
            {
                using (var scope = new TransactionScope())
                {
                    _indicateurRepository.UpdateIndicateur(indicateur);
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
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Indicateur4"))
            {
                _indicateurRepository.DeleteIndicateur(id);
            return new OkResult();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
