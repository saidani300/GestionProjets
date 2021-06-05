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
    public class ReunionController : ControllerBase
    {
        private readonly IReunionRepository _reunionRepository;
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;

        public ReunionController(IReunionRepository reunionRepository, IProjetRepository projetRepository, IAutorisationRepository autorisationRepository)
        {
            _reunionRepository = reunionRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Reunion0"))
            {
                var reunions = _reunionRepository.GetReunions();
                return new OkObjectResult(reunions);
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
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Reunion1"))
            {
                var reunion = _reunionRepository.GetReunionByID(id);
            return new OkObjectResult(reunion);
        }
            else
            {
                return BadRequest();
    }
}
        internal bool Authorization(Reunion reunion)
        {

            Guid LoggedInuserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Guid projetId = reunion.ProjetId;
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
        public IActionResult Post([FromBody] Reunion reunion)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Reunion2"))
            {
                if (Authorization(reunion))
                {
                    using (var scope = new TransactionScope())
            {
                _reunionRepository.InsertReunion(reunion);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = reunion.Id }, reunion);
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
        public IActionResult Put([FromBody] Reunion reunion)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Reunion3"))
            {
                if (Authorization(reunion))
                {
                    if (reunion != null)
            {
                using (var scope = new TransactionScope())
                {
                    _reunionRepository.UpdateReunion(reunion);
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
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Reunion4"))
            {
                _reunionRepository.DeleteReunion(id);
            return new OkResult();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
