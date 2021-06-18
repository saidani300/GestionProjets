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
    [Authorize(Roles = "Responsable")]
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;
        private readonly IMapper _mapper;


        public EvaluationController(IEvaluationRepository evaluationRepository , IProjetRepository projetRepository, IAutorisationRepository autorisationRepository, IMapper mapper)
        {
            _evaluationRepository = evaluationRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
            _mapper = mapper;



        }
        [HttpGet("getbyopportunite/{id}")]
        [Ref("Evaluation0")]

        public IActionResult GetByOpportunite(Guid id)
        {
            
                var evaluations = _evaluationRepository.GetEvaluationsByOpportunite(id);
                var evaluationsDTO = evaluations.Select(_mapper.Map<EvaluationDTO>);

                return new OkObjectResult(evaluationsDTO);
           
        }

        [HttpGet("getbyrisque/{id}")]
        [Ref("Evaluation0")]

        public IActionResult GetByRisque(Guid id)
        {

            var evaluations = _evaluationRepository.GetEvaluationsByRisque(id);
            var evaluationsDTO = evaluations.Select(_mapper.Map<EvaluationDTO>);

            return new OkObjectResult(evaluationsDTO);

        }

        internal bool Authorization(Evaluation evaluation , Guid projetId)
        {

            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid projetUserId = _projetRepository.GetProjetByID(projetId).UserId;
            if (projetUserId.ToString() == LoggedInuserId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpGet]
        [Ref("Evaluation1")]
        public IActionResult Get()
        {
           
                var evaluations = _evaluationRepository.GetEvaluations();
                var evaluationsDTO = evaluations.Select(_mapper.Map<EvaluationDTO>);

                return new OkObjectResult(evaluationsDTO);
            
        }

        [HttpGet("{id}")]
        [Ref("Evaluation2")]

        public IActionResult Get(Guid id)
        {
            
                var evaluation = _evaluationRepository.GetEvaluationByID(id);
                EvaluationDTO evaluationDTO = _mapper.Map<EvaluationDTO>(evaluation);

                return new OkObjectResult(evaluationDTO);
            
        }

        [HttpPost]
        [Ref("Evaluation3")]

        public IActionResult Post([FromBody] Evaluation evaluation)
        {
           
                using (var scope = new TransactionScope())
                {
                    _evaluationRepository.InsertEvaluation(evaluation);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = evaluation.Id }, evaluation);
                }
        }

        [HttpPut]
        [Ref("Evaluation4")]

        public IActionResult Put([FromBody] Evaluation evaluation)
        {
            
          
                if (evaluation != null)
            {
                using (var scope = new TransactionScope())
                {
                    _evaluationRepository.UpdateEvaluation(evaluation);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
           
        }

        [HttpDelete("{id}")]
        [Ref("Evaluation5")]

        public IActionResult Delete(Guid id)
        {
            
                Evaluation evaluation = _evaluationRepository.GetEvaluationByID(id);
            
                _evaluationRepository.DeleteEvaluation(id);
            return new OkResult();
           
}
    }
}
