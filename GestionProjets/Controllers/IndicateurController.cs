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
    public class IndicateurController : ControllerBase
    {
        private readonly IIndicateurRepository _indicateurRepository;

        public IndicateurController(IIndicateurRepository indicateurRepository)
        {
            _indicateurRepository = indicateurRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var indicateurs = _indicateurRepository.GetIndicateurs();
            return new OkObjectResult(indicateurs);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var indicateur = _indicateurRepository.GetIndicateurByID(id);
            return new OkObjectResult(indicateur);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Indicateur indicateur)
        {
            using (var scope = new TransactionScope())
            {
                _indicateurRepository.InsertIndicateur(indicateur);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = indicateur.Id }, indicateur);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Indicateur indicateur)
        {
            if (indicateur != null)
            {
                using (var scope = new TransactionScope())
                {
                    _indicateurRepository.UpdateIndicateur(indicateur);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _indicateurRepository.DeleteIndicateur(id);
            return new OkResult();
        }
    }
}
