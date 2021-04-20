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
    public class MesureController : ControllerBase
    {
        private readonly IMesureRepository _mesureRepository;

        public MesureController(IMesureRepository mesureRepository)
        {
            _mesureRepository = mesureRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var mesures = _mesureRepository.GetMesures();
            return new OkObjectResult(mesures);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var mesure = _mesureRepository.GetMesureByID(id);
            return new OkObjectResult(mesure);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Mesure mesure)
        {
            using (var scope = new TransactionScope())
            {
                _mesureRepository.InsertMesure(mesure);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = mesure.Id }, mesure);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Mesure mesure)
        {
            if (mesure != null)
            {
                using (var scope = new TransactionScope())
                {
                    _mesureRepository.UpdateMesure(mesure);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _mesureRepository.DeleteMesure(id);
            return new OkResult();
        }
    }
}
