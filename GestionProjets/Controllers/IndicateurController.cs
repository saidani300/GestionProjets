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

       

        [HttpGet]
        [Ref("Indicateur0")]

        public IActionResult Get()
        {
            
                    var indicateurs = _indicateurRepository.GetIndicateurs();
            return new OkObjectResult(indicateurs);
           
        }

        [HttpGet("{id}")]
        [Ref("Indicateur1")]

        public IActionResult Get(Guid id)
        {
            
                var indicateur = _indicateurRepository.GetIndicateurByID(id);
            return new OkObjectResult(indicateur);
           
        }

        [HttpPost]
        [Ref("Indicateur2")]

        public IActionResult Post([FromBody] Indicateur indicateur)
        {
           
                    using (var scope = new TransactionScope())
            {
                _indicateurRepository.InsertIndicateur(indicateur);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = indicateur.Id }, indicateur);
            }
               
        }

        [HttpPut]
        [Ref("Indicateur3")]
        [AuthorizeUpdate]
        public IActionResult Put([FromBody] Indicateur Model)
        {
           
                    if (Model != null)
            {
                using (var scope = new TransactionScope())
                {
                    _indicateurRepository.UpdateIndicateur(Model);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
              
        }

        [HttpDelete("{id}")]
        [Ref("Indicateur4")]

        public IActionResult Delete(Guid id)
        {
            
                _indicateurRepository.DeleteIndicateur(id);
            return new OkResult();
            
            
        }
    }
}
