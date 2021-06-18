using AutoMapper;
using GestionProjets.AuthorizationAttributes;
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
        private readonly IMapper _mapper;


        public MesureController(IMesureRepository mesureRepository ,IProjetRepository projetRepository , IAutorisationRepository autorisationRepository, IMapper mapper)
        {
            _mesureRepository = mesureRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
            _mapper = mapper;

        }

        [HttpGet("getbyindicateur/{id}")]
        [Ref("Mesure0")]

        public IActionResult GetByIndicateur(Guid id)
        {

            var mesures = _mesureRepository.GetMesuresByIndicateur(id) ;
                var mesuresDTO = mesures.Select(_mapper.Map<MesureDTO>);

                return new OkObjectResult(mesuresDTO);
           
        }

        [HttpGet]
        [Ref("Mesure1")]

        public IActionResult Get()
        {
           
                var mesures = _mesureRepository.GetMesures();
                var mesuresDTO = mesures.Select(_mapper.Map<MesureDTO>);

                return new OkObjectResult(mesuresDTO);
            
        }

        [HttpGet("{id}")]
        [Ref("Mesure2")]

        public IActionResult Get(Guid id)
        {
           
                var mesure = _mesureRepository.GetMesureByID(id);
                MesureDTO mesureDTO = _mapper.Map<MesureDTO>(mesure);

                return new OkObjectResult(mesureDTO);
           
        }

        internal bool Authorization(Mesure mesure , Guid projetId)
        {

            Guid LoggedInuserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Guid projetChefId = (Guid)_projetRepository.GetProjetByID(projetId).ChefId;
            Guid projetUserId = _projetRepository.GetProjetByID(projetId).UserId;
            if (projetUserId == LoggedInuserId || projetChefId == LoggedInuserId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpPost]
        [Ref("Mesure3")]

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
        [Ref("Mesure4")]

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
        [Ref("Mesure5")]

        public IActionResult Delete(Guid id)
        {
           
                _mesureRepository.DeleteMesure(id);
            return new OkResult();
           
        }
    }
}
