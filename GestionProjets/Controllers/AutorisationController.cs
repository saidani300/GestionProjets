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

        public IActionResult Post([FromBody] Models.Autorisation Model)
        {
            
                using (var scope = new TransactionScope())
            {
                _autorisationRepository.InsertAutorisation(Model);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = Model.Id }, Model);
            }
            
        }
        [HttpPut]
        [Ref("Autorisation3")]

        public IActionResult Put([FromBody] Models.Autorisation Model)
        {
            
                if (Model != null)
            {
                using (var scope = new TransactionScope())
                {
                    _autorisationRepository.UpdateAutorisation(Model);
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
