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
    public class ObjectifController : ControllerBase
    {
        private readonly IObjectifRepository _objectifRepository;

        public ObjectifController(IObjectifRepository objectifRepository)
        {
            _objectifRepository = objectifRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var objectifs = _objectifRepository.GetObjectifs();
            return new OkObjectResult(objectifs);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var objectif = _objectifRepository.GetObjectifByID(id);
            return new OkObjectResult(objectif);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Objectif objectif)
        {
            using (var scope = new TransactionScope())
            {
                _objectifRepository.InsertObjectif(objectif);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = objectif.Id }, objectif);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Objectif objectif)
        {
            if (objectif != null)
            {
                using (var scope = new TransactionScope())
                {
                    _objectifRepository.UpdateObjectif(objectif);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _objectifRepository.DeleteObjectif(id);
            return new OkResult();
        }
    }
}
