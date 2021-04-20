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
    public class ReunionController : ControllerBase
    {
        private readonly IReunionRepository _reunionRepository;

        public ReunionController(IReunionRepository reunionRepository)
        {
            _reunionRepository = reunionRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var reunions = _reunionRepository.GetReunions();
            return new OkObjectResult(reunions);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var reunion = _reunionRepository.GetReunionByID(id);
            return new OkObjectResult(reunion);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Reunion reunion)
        {
            using (var scope = new TransactionScope())
            {
                _reunionRepository.InsertReunion(reunion);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = reunion.Id }, reunion);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Reunion reunion)
        {
            if (reunion != null)
            {
                using (var scope = new TransactionScope())
                {
                    _reunionRepository.UpdateReunion(reunion);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _reunionRepository.DeleteReunion(id);
            return new OkResult();
        }
    }
}
