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
    public class ParametreController : ControllerBase
    {
        private readonly IParametreRepository _parametreRepository;
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;

        public ParametreController(IParametreRepository parametreRepository,  IProjetRepository projetRepository, IAutorisationRepository autorisationRepository)
        {
            _parametreRepository = parametreRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Parametre0"))
            {
                var parametres = _parametreRepository.GetParametres();
            return new OkObjectResult(parametres);
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

            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Parametre1"))
            {
                var parametre = _parametreRepository.GetParametreByID(id);
            return new OkObjectResult(parametre);
            }
            else
            {
                return BadRequest();
            }
        }

        internal bool Authorization(Parametre parametre, Guid projetId)
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
        public IActionResult Post([FromBody] Parametre parametre)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Parametre2"))
            {
                //if (Authorization(parametre))
                //{
                    using (var scope = new TransactionScope())
            {
                _parametreRepository.InsertParametre(parametre);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = parametre.Id }, parametre);
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
        public IActionResult Put([FromBody] Parametre parametre)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Parametre3"))
            {
                //if (Authorization(parametre))
                //{
                    if (parametre != null)
            {
                using (var scope = new TransactionScope())
                {
                    _parametreRepository.UpdateParametre(parametre);
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
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Parametre4"))
            {
                _parametreRepository.DeleteParametre(id);
            return new OkResult();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
