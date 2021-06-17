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
    [Authorize(Roles = "Admin")]

    public class AutorisationController : ControllerBase
    {
        private readonly IAutorisationRepository _autorisationRepository;

        public AutorisationController(IAutorisationRepository autorisationRepository)
        {
            _autorisationRepository = autorisationRepository;
        }

        [HttpGet]
        [Ref("Autorisation0")]

        public IActionResult Get()
        {
           
                var autorisations = _autorisationRepository.GetAutorisations();
            return new OkObjectResult(autorisations);
           
        }

        [HttpGet("{id}")]
        [Ref("Autorisation1")]

        public IActionResult Get(Guid id)
        {
           
                var autorisation = _autorisationRepository.GetAutorisationByID(id);
            return new OkObjectResult(autorisation);
           
        }

        
        [HttpPost]
        [Ref("Autorisation2")]

        public IActionResult Post([FromBody] Models.Autorisation autorisation)
        {
            
                using (var scope = new TransactionScope())
            {
                _autorisationRepository.InsertAutorisation(autorisation);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = autorisation.Id }, autorisation);
            }
            
        }
        [HttpPut]
        [Ref("Autorisation3")]

        public IActionResult Put([FromBody] Models.Autorisation autorisation)
        {
            
                if (autorisation != null)
            {
                using (var scope = new TransactionScope())
                {
                    _autorisationRepository.UpdateAutorisation(autorisation);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
            
        }
       
        [HttpDelete("{id}")]
        [Ref("Autorisation4")]

        public IActionResult Delete(Guid id)
        {
            
                _autorisationRepository.DeleteAutorisation(id);
            return new OkResult();
            
        }
    }
}
