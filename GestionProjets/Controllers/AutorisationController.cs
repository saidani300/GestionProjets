using GestionProjets.Models;
using GestionProjets.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionProjets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AutorisationController : ControllerBase
    {
        private readonly IAutorisationRepository _autorisationRepository;

        public AutorisationController(IAutorisationRepository autorisationRepository)
        {
            _autorisationRepository = autorisationRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var autorisations = _autorisationRepository.GetAutorisations();
            return new OkObjectResult(autorisations);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var autorisation = _autorisationRepository.GetAutorisationByID(id);
            return new OkObjectResult(autorisation);
        }

        [Authorize(Roles = "Responsable")]
        [HttpPost]
        public IActionResult Post([FromBody] Models.Autorisation autorisation)
        {
            using (var scope = new TransactionScope())
            {
                _autorisationRepository.InsertAutorisation(autorisation);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = autorisation.Id }, autorisation);
            }
        }
        [Authorize(Roles = "Responsable")]
        [HttpPut]
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
        [Authorize(Roles = "Responsable")]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _autorisationRepository.DeleteAutorisation(id);
            return new OkResult();
        }
    }
}
