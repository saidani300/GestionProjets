﻿using AutoMapper;
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
    [Authorize(Roles = "Responsable,Chefdeprojet")]
    public class ActionController : ControllerBase
    {
        private readonly IActionRepository _actionRepository;
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;
        private readonly IMapper _mapper;

        public ActionController(IActionRepository actionRepository , IProjetRepository projetRepository , IAutorisationRepository autorisationRepository, IMapper mapper)
        {
            _actionRepository = actionRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
            _mapper = mapper;

        }
        [HttpGet("getbyprojet/{id}")]
        [Ref("Action0")]

        public IActionResult GetByProject(Guid id)
        {
           
                var actions = _actionRepository.GetActionsByProject(id);
                var actionsDTO = actions.Select(_mapper.Map<ActionDTO>);

                return new OkObjectResult(actionsDTO);
            
        }

        [HttpGet("getbyphase/{id}")]
        [Ref("Action1")]

        public IActionResult GetByPhase(Guid id)
        {
            
                var actions = _actionRepository.GetActionsByPhase(id);
                var actionsDTO = actions.Select(_mapper.Map<ActionDTO>);

                return new OkObjectResult(actionsDTO);
            
        }

        [HttpGet("{id}")]
        [Ref("Action2")]

        public IActionResult Get(Guid id)
        {
            
                var action = _actionRepository.GetActionByID(id);
                ActionDTO actionDTO = _mapper.Map<ActionDTO>(action);

                return new OkObjectResult(actionDTO);
           
        }


        internal bool Authorization(Models.Action action, Guid projetId)
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

        [HttpPost("AjouterActionProjet/{id}")]
        [Ref("Action3")]

        public IActionResult PostProjet([FromBody] Models.Action action , Guid Id)
        {
                     
                using (var scope = new TransactionScope())
                {
                    _actionRepository.InsertActionProjet(action, Id);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = action.Id }, action);
                }
            
        }

        [HttpPost("AjouterActionPhase/{id}")]
        [Ref("Action4")]

        public IActionResult PostPhase([FromBody] Models.Action action, Guid Id)
        {
            
                    using (var scope = new TransactionScope())
                    {
                        _actionRepository.InsertActionPhase(action, Id);
                        scope.Complete();
                        return CreatedAtAction(nameof(Get), new { id = action.Id }, action);
                    }
               
        }

        [HttpPut]
        [Ref("Action5")]

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
        [Ref("Action6")]

        public IActionResult Delete(Guid id)
        {
            
                Models.Action action = _actionRepository.GetActionByID(id);
           
                _actionRepository.DeleteAction(id);
                return new OkResult();
        }
    }
}
