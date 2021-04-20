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
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationController(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
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
            using (var scope = new TransactionScope())
            {
                _evaluationRepository.InsertEvaluation(evaluation);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = evaluation.Id }, evaluation);
            }
        }

        [HttpPut]
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
        public IActionResult Delete(string id)
        {
            _evaluationRepository.DeleteEvaluation(id);
            return new OkResult();
        }
    }
}
