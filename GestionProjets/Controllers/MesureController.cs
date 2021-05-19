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
    public class MesureController : ControllerBase
    {
        private readonly IMesureRepository _mesureRepository;
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;


        public MesureController(IMesureRepository mesureRepository ,IProjetRepository projetRepository , IAutorisationRepository autorisationRepository)
        {
            _mesureRepository = mesureRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;

        }

        [HttpGet("~/getbyprojet/{id}")]

        public IActionResult GetByProject(Guid id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Mesure1"))
            {
                var mesures = _mesureRepository.GetMesuresByProject(id);
                return new OkObjectResult(mesures);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Mesure2"))
            {
                var mesures = _mesureRepository.GetMesures();
            return new OkObjectResult(mesures);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Mesure3"))
            {
                var mesure = _mesureRepository.GetMesureByID(id);
            return new OkObjectResult(mesure);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Mesure mesure)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Mesure4"))
            {
                using (var scope = new TransactionScope())
            {
                _mesureRepository.InsertMesure(mesure);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = mesure.Id }, mesure);
            }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Mesure mesure)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Mesure5"))
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
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Mesure6"))
            {
                _mesureRepository.DeleteMesure(id);
            return new OkResult();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
