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
        [Ref("Objectif0")]

        public IActionResult GetByProject(Guid id)
        {
           
                var objectifs = _objectifRepository.GetobjectifsByProject(id);
                return new OkObjectResult(objectifs);
           
        }
        [HttpGet]
        [Ref("Objectif1")]
        public IActionResult Get()
        {
           
                var objectifs = _objectifRepository.GetObjectifs();
            return new OkObjectResult(objectifs);
            
        }

        [HttpGet("{id}")]
        [Ref("Objectif2")]
        public IActionResult Get(Guid id)
        {
            
                var objectif = _objectifRepository.GetObjectifByID(id);
            return new OkObjectResult(objectif);
            
        }

       
        [HttpPost]
        [Ref("Objectif3")]

        public IActionResult Post([FromBody] Objectif objectif)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    using (var scope = new TransactionScope())
            {
                _objectifRepository.InsertObjectif(objectif);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = objectif.Id }, objectif);
            }
                
        }

        [HttpPut]
        [Ref("Objectif4")]
        [AuthorizeUpdate]
        public IActionResult Put([FromBody] Objectif Model)
        {
           
                    if (Model != null)
            {
                using (var scope = new TransactionScope())
                {
                    _objectifRepository.UpdateObjectif(Model);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
               
        }

        [HttpDelete("{id}")]
        [Ref("Objectif5")]

        public IActionResult Delete(Guid id)
        {
            
                _objectifRepository.DeleteObjectif(id);
            return new OkResult();
            
        }
    }
}
