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

        public EvaluationController(IEvaluationRepository evaluationRepository , IProjetRepository projetRepository, IAutorisationRepository autorisationRepository)
        {
            _evaluationRepository = evaluationRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;


        }
        [HttpGet("getbyprojet/{id}")]

        public IActionResult GetByProject(Guid id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Evaluation0"))
            {
                var evaluations = _evaluationRepository.GetEvaluationsByProjet(id);
                return new OkObjectResult(evaluations);
            }
            else
            {
                return BadRequest();
            }
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
        public IActionResult Get()
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Evaluation1"))
            {
                var evaluations = _evaluationRepository.GetEvaluations();
            return new OkObjectResult(evaluations);
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
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Evaluation2"))
            {
                var evaluation = _evaluationRepository.GetEvaluationByID(id);
            return new OkObjectResult(evaluation);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Evaluation evaluation)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Evaluation3"))
            {
            //    if (Authorization(evaluation))
            //{
                using (var scope = new TransactionScope())
                {
                    _evaluationRepository.InsertEvaluation(evaluation);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = evaluation.Id }, evaluation);
                }
            //}
            //else
            //{
            //    return BadRequest();
            //}
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Evaluation evaluation)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Evaluation4"))
            {
            //    if (Authorization(evaluation))
            //{
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
            //}
            //else
            //{
            //    return BadRequest();
            //}
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
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Evaluation5"))
            {
                Evaluation evaluation = _evaluationRepository.GetEvaluationByID(id);
            //if (Authorization(evaluation))
            //{
                _evaluationRepository.DeleteEvaluation(id);
            return new OkResult();
            //}
            //else
            //{
            //    return BadRequest();
            //}
        }
            else
            {
                return BadRequest();
    }
}
    }
}
