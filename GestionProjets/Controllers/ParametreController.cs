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
    public class ParametreController : ControllerBase
    {
        private readonly IParametreRepository _parametreRepository;

        public ParametreController(IParametreRepository parametreRepository)
        {
            _parametreRepository = parametreRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var parametres = _parametreRepository.GetParametres();
            return new OkObjectResult(parametres);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var parametre = _parametreRepository.GetParametreByID(id);
            return new OkObjectResult(parametre);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Parametre parametre)
        {
            using (var scope = new TransactionScope())
            {
                _parametreRepository.InsertParametre(parametre);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = parametre.Id }, parametre);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Parametre parametre)
        {
            if (parametre != null)
            {
                using (var scope = new TransactionScope())
                {
                    _parametreRepository.UpdateParametre(parametre);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _parametreRepository.DeleteParametre(id);
            return new OkResult();
        }
    }
}
