using GestionProjets.Models;
using GestionProjets.Repository;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Responsable")]
    public class ProjetController : ControllerBase
    {
        private readonly IProjetRepository _projetRepository;

        public ProjetController(IProjetRepository projetRepository)
        {
            _projetRepository = projetRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var projets = _projetRepository.GetProjets();
            return new OkObjectResult(projets);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var projet = _projetRepository.GetProjetByID(id);
            return new OkObjectResult(projet);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Projet projet)
        {
            using (var scope = new TransactionScope())
            {
                _projetRepository.InsertProjet(projet);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = projet.Id }, projet);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Projet projet)
        {
            if (projet != null)
            {
                using (var scope = new TransactionScope())
                {
                    _projetRepository.UpdateProjet(projet);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _projetRepository.DeleteProjet(id);
            return new OkResult();
        }


       
    }
}
