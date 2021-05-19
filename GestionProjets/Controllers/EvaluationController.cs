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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionProjets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Responsable")]
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IProjetRepository _projetRepository;

        public EvaluationController(IEvaluationRepository evaluationRepository , IProjetRepository projetRepository)
        {
            _evaluationRepository = evaluationRepository;
            _projetRepository = projetRepository;

        }

        internal bool Authorization(Evaluation evaluation)
        {

            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid projetId = evaluation.IdProjet;
            Guid projetUserId = _projetRepository.GetProjetByID(projetId.ToString()).UserId;
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
            var evaluations = _evaluationRepository.GetEvaluations();
            return new OkObjectResult(evaluations);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var evaluation = _evaluationRepository.GetEvaluationByID(id);
            return new OkObjectResult(evaluation);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Evaluation evaluation)
        {
            if (Authorization(evaluation))
            {
                using (var scope = new TransactionScope())
                {
                    _evaluationRepository.InsertEvaluation(evaluation);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = evaluation.Id }, evaluation);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Evaluation evaluation)
        {
            if (Authorization(evaluation))
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
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Evaluation evaluation = _evaluationRepository.GetEvaluationByID(id);
            if (Authorization(evaluation))
            {
                _evaluationRepository.DeleteEvaluation(id);
            return new OkResult();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
