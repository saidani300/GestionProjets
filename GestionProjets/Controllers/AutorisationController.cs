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
        public IActionResult Get()
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Autorisation0"))
            {
                var autorisations = _autorisationRepository.GetAutorisations();
            return new OkObjectResult(autorisations);
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

            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Autorisation1"))
            {
                var autorisation = _autorisationRepository.GetAutorisationByID(id);
            return new OkObjectResult(autorisation);
            }
            else
            {
                return BadRequest();
            }
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] Models.Autorisation autorisation)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Autorisation2"))
            {
                using (var scope = new TransactionScope())
            {
                _autorisationRepository.InsertAutorisation(autorisation);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = autorisation.Id }, autorisation);
            }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] Models.Autorisation autorisation)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Autorisation3"))
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
            else
            {
                return BadRequest();
            }
        }
       
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Autorisation4"))
            {
                _autorisationRepository.DeleteAutorisation(id);
            return new OkResult();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
