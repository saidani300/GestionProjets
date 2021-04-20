using GestionProjets.Models;
using GestionProjets.Repository;
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
        private readonly IAutorisationRepository _actionRepository;

        public AutorisationController(IAutorisationRepository actionRepository)
        {
            _actionRepository = actionRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var actions = _actionRepository.GetAutorisations();
            return new OkObjectResult(actions);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var action = _actionRepository.GetAutorisationByID(id);
            return new OkObjectResult(action);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Models.Autorisation action)
        {
            using (var scope = new TransactionScope())
            {
                _actionRepository.InsertAutorisation(action);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = action.Id }, action);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Models.Autorisation action)
        {
            if (action != null)
            {
                using (var scope = new TransactionScope())
                {
                    _actionRepository.UpdateAutorisation(action);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _actionRepository.DeleteAutorisation(id);
            return new OkResult();
        }
    }
}
