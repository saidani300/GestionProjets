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
    public class ActionController : ControllerBase
    {
        private readonly IActionRepository _actionRepository;

        public ActionController(IActionRepository actionRepository)
        {
            _actionRepository = actionRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var actions = _actionRepository.GetActions();
            return new OkObjectResult(actions);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            var action = _actionRepository.GetActionByID(id);
            return new OkObjectResult(action);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Models.Action action)
        {
            using (var scope = new TransactionScope())
            {
                _actionRepository.InsertAction(action);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = action.Id }, action);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Models.Action action)
        {
            if (action != null)
            {
                using (var scope = new TransactionScope())
                {
                    _actionRepository.UpdateAction(action);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _actionRepository.DeleteAction(id);
            return new OkResult();
        }
    }
}
