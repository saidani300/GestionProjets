using GestionProjets.Models;
using GestionProjets.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace GestionProjets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacheController : ControllerBase
    {
        private readonly ITacheRepository _tacheRepository;

        public TacheController(ITacheRepository tacheRepository)
        {
            _tacheRepository = tacheRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var taches = _tacheRepository.GetTaches();
            return new OkObjectResult(taches);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            var tache = _tacheRepository.GetTacheByID(id);
            return new OkObjectResult(tache);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tache tache)
        {
            using (var scope = new TransactionScope())
            {
                _tacheRepository.InsertTache(tache);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = tache.Id }, tache);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Tache tache)
        {
            if (tache != null)
            {
                using (var scope = new TransactionScope())
                {
                    _tacheRepository.UpdateTache(tache);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _tacheRepository.DeleteTache(id);
            return new OkResult();
        }
    }
}
