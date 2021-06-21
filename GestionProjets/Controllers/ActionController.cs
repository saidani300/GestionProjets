using AutoMapper;
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
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;

        public ActionController(IActionRepository actionRepository , IProjetRepository projetRepository , IAutorisationRepository autorisationRepository, IMapper mapper, IAuthorizationService authorizationService)
        {
            _actionRepository = actionRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
            _mapper = mapper;
            _authorizationService = authorizationService;

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

        [HttpPost]
        [Ref("Action3")]

        public IActionResult PostProjet([FromBody] Models.Action Model)
        {
                     
                using (var scope = new TransactionScope())
                {
                    _actionRepository.InsertAction(Model);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = Model.Id }, Model);
                }
            
        }

       

        [HttpPut]
        [Ref("Action4")]
        public async Task<IActionResult> Put([FromBody] Models.Action Model)
        {
           
                if (Model != null)
            {
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, Model, "EditPolicy");
                if (authorizationResult.Succeeded)
                {
                    using (var scope = new TransactionScope())
                {
                    _actionRepository.UpdateAction(Model);
                    scope.Complete();
                    return new OkResult();
                }
                    return new UnauthorizedResult();
                }
            }
            return new NoContentResult();
           
        }

        [HttpDelete("{id}")]
        [Ref("Action5")]

        public IActionResult Delete(Guid id)
        {
            
                Models.Action action = _actionRepository.GetActionByID(id);
           
                _actionRepository.DeleteAction(id);
                return new OkResult();
        }
    }
}
