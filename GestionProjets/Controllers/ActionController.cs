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
    [Authorize(Roles = "Responsable,Chefdeprojet")]
    public class ActionController : ControllerBase
    {
        private readonly IActionRepository _actionRepository;
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;
        public ActionController(IActionRepository actionRepository , IProjetRepository projetRepository , IAutorisationRepository autorisationRepository)
        {
            _actionRepository = actionRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
        }

        [HttpGet("{id}")]
        [Route("/GetByProject")]
        public IActionResult GetByProject(Guid id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Action1"))
            {
                var actions = _actionRepository.GetActionsByProject(id);
                return new OkObjectResult(actions);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        
        public IActionResult Get(string id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Action2"))
            {
                var action = _actionRepository.GetActionByID(id);
            return new OkObjectResult(action);
            }
            else
            {
                return BadRequest();
            }
        }

        public bool Authorization(Models.Action action)
        {

            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid projetId = action.ProjetId;
            Guid projetChefId = _projetRepository.GetProjetByID(projetId.ToString()).ChefId;
            Guid projetUserId = _projetRepository.GetProjetByID(projetId.ToString()).UserId;
            if (projetUserId.ToString() == LoggedInuserId || projetChefId.ToString() == LoggedInuserId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Models.Action action)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Action3"))
            {
                if (Authorization(action))
            {
                using (var scope = new TransactionScope())
                {
                    _actionRepository.InsertAction(action);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = action.Id }, action);
                }
            }
            else
            {return BadRequest();}}
            else
            {return BadRequest();}
        }

        [HttpPut]
        public IActionResult Put([FromBody] Models.Action action)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Action4"))
            {
                if (Authorization(action))
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
            else
            {
                return BadRequest();
            }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Action4"))
            {
                Models.Action action = _actionRepository.GetActionByID(id);
            if (Authorization(action))
            {
                _actionRepository.DeleteAction(id);
                return new OkResult();
            }
            else
            {
                return BadRequest();
            }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
