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
    public class TypeProjetController : ControllerBase
    {
        private readonly ITypeProjetRepository _typeprojetRepository;

        public TypeProjetController(ITypeProjetRepository typeprojetRepository)
        {
            _typeprojetRepository = typeprojetRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var typeprojets = _typeprojetRepository.GetTypeProjets();
            return new OkObjectResult(typeprojets);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            var typeprojet = _typeprojetRepository.GetTypeProjetByID(id);
            return new OkObjectResult(typeprojet);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TypeProjet typeprojet)
        {
            using (var scope = new TransactionScope())
            {
                _typeprojetRepository.InsertTypeProjet(typeprojet);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = typeprojet.Id }, typeprojet);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] TypeProjet typeprojet)
        {
            if (typeprojet != null)
            {
                using (var scope = new TransactionScope())
                {
                    _typeprojetRepository.UpdateTypeProjet(typeprojet);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _typeprojetRepository.DeleteTypeProjet(id);
            return new OkResult();
        }
    }
}
