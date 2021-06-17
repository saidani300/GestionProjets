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
        [Ref("Parametre0")]

        public IActionResult Get()
        {
            
                var parametres = _parametreRepository.GetParametres();
            return new OkObjectResult(parametres);
           
        }

        [HttpGet("{id}")]
        [Ref("Parametre1")]

        public IActionResult Get(Guid id)
        {
           
                var parametre = _parametreRepository.GetParametreByID(id);
            return new OkObjectResult(parametre);
            
        }

        internal bool Authorization(Parametre parametre, Guid projetId)
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
        [Ref("Parametre2")]

        public IActionResult Post([FromBody] Parametre parametre)
        {
            
                    using (var scope = new TransactionScope())
            {
                _parametreRepository.InsertParametre(parametre);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = parametre.Id }, parametre);
            }
               
        }

        [HttpPut]
        [Ref("Parametre3")]

        public IActionResult Put([FromBody] Parametre parametre)
        {
           
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
               
        }

        [HttpDelete("{id}")]
        [Ref("Parametre4")]

        public IActionResult Delete(Guid id)
        {
           
                _parametreRepository.DeleteParametre(id);
            return new OkResult();
           
        }
    }
}
