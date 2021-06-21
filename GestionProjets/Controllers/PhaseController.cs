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
    public class PhaseController : ControllerBase
    {
        private readonly IPhaseRepository _phaseRepository;
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;
        private readonly IMapper _mapper;


        public PhaseController(IPhaseRepository phaseRepository, IProjetRepository projetRepository, IAutorisationRepository autorisationRepository, IMapper mapper)
        {
            _phaseRepository = phaseRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
            _mapper = mapper;

        }
        [HttpGet("getbyprojet/{id}")]
        [Ref("Phase0")]
        public IActionResult GetByProject(Guid id)
        {
            
                var phases = _phaseRepository.GetPhasesByProject(id);

               var phasesDTO = phases.Select(_mapper.Map<PhaseDTO>);

                return new OkObjectResult(phasesDTO);
           
        }

        [HttpGet]
        [Ref("Phase1")]
        public IActionResult Get()
        {
           
                var phases = _phaseRepository.GetPhases();
                var phasesDTO = phases.Select(_mapper.Map<PhaseDTO>);

                return new OkObjectResult(phasesDTO);
            
        }

        [HttpGet("{id}")]
        [Ref("Phase2")]
        public IActionResult Get(Guid id)
        {
            
                var phase = _phaseRepository.GetPhaseByID(id);

                PhaseDTO phaseDTO = _mapper.Map<PhaseDTO>(phase);

                return new OkObjectResult(phase);
            
        }

       
        [HttpPost]
        [Ref("Phase3")]
        public IActionResult Post([FromBody] Phase phase)
        {
            
                    using (var scope = new TransactionScope())
            {
                _phaseRepository.InsertPhase(phase);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = phase.Id }, phase);
            }
               
        }

        [HttpPut]
        [Ref("Phase4")]
        public IActionResult Put([FromBody] Phase Model)
        {
            
                    if (Model != null)
            {
                using (var scope = new TransactionScope())
                {
                    _phaseRepository.UpdatePhase(Model);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
    
        }

        [HttpDelete("{id}")]
        [Ref("Phase5")]
        public IActionResult Delete(Guid id)
        {
           
                _phaseRepository.DeletePhase(id);
            return new OkResult();
           
        }
    }
}
