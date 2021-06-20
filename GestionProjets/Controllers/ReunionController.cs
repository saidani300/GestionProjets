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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionProjets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Responsable")]
    public class ReunionController : ControllerBase
    {
        private readonly IReunionRepository _reunionRepository;
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;
        private readonly INotificationRepository _notificationRepository;

        private readonly IMapper _mapper;


        public ReunionController(IReunionRepository reunionRepository, IProjetRepository projetRepository, IAutorisationRepository autorisationRepository, INotificationRepository notificationRepository, IMapper mapper)
        {
            _reunionRepository = reunionRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
            _notificationRepository = notificationRepository;

            _mapper = mapper;

        }

        [HttpGet("getbyprojet/{id}")]
        [Ref("Reunion0")]
        public IActionResult GetByProject(Guid id)
        {
            
                var reunions = _reunionRepository.GetReunionsByProjet(id);

                var reunionsDTO = reunions.Select(_mapper.Map<ReunionDTO>);

                return new OkObjectResult(reunionsDTO);
            
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Ref("Reunion1")]

        public IActionResult Get()
        {
           
                var reunions = _reunionRepository.GetReunions();
                var reunionsDTO = reunions.Select(_mapper.Map<ReunionDTO>);

                return new OkObjectResult(reunionsDTO);
          
        }

        [HttpGet("{id}")]
        [Ref("Reunion2")]

        public IActionResult Get(Guid id)
        {
           
                var reunion = _reunionRepository.GetReunionByID(id);

                ReunionDTO reunionDTO = _mapper.Map<ReunionDTO>(reunion);

                return new OkObjectResult(reunionDTO);
        
           
}
       
        [HttpPost]
        [Ref("Reunion3")]

        public IActionResult Post([FromBody] Reunion reunion)
        {

            using (var scope = new TransactionScope())
            {
                _reunionRepository.InsertReunion(reunion);
                scope.Complete();
            }
            //Notification
            Reunion r = _reunionRepository.GetReunionByID(reunion.Id);
                if (r.Utilisateurs != null)
                {
                    foreach (Utilisateur utilisateur in r.Utilisateurs)
                    {
                        Notification notification = new Notification()
                        {
                            Nom = "Notification",
                            Description = $"Vous êtes invité à une réunion le {r.Date}.",
                            DateCreation = DateTime.Now,
                            SourceId = r.Id,
                            UserId = utilisateur.Id
                        };
                        _notificationRepository.InsertNotification(notification);
                    }
                }
                return CreatedAtAction(nameof(Get), new { id = reunion.Id }, reunion);
            
               
        }

        [HttpPut]
        [Ref("Reunion4")]
        [AuthorizeUpdate]

        public IActionResult Put([FromBody] Reunion Model)
        {
           
                    if (Model != null)
            {
                using (var scope = new TransactionScope())
                {

                    _reunionRepository.UpdateReunion(Model);
                    scope.Complete();
                }
                //Notification
                Reunion r = _reunionRepository.GetReunionByID(Model.Id);

                if (r.Utilisateurs != null)
                    {
                        foreach (Utilisateur utilisateur in r.Utilisateurs)
                        {
                            Notification notification = new Notification()
                            {
                                Nom = "Notification",
                                Description = $"Vous êtes invité à une réunion le {r.Date}.",
                                DateCreation = DateTime.Now,
                                SourceId = r.Id,
                                UserId = utilisateur.Id
                            };
                            _notificationRepository.InsertNotification(notification);
                        }
                    }
                    return new OkResult();
                }
            
            return new NoContentResult();
                
        }

        [HttpDelete("{id}")]
        [Ref("Reunion5")]

        public IActionResult Delete(Guid id)
        {
            
                _reunionRepository.DeleteReunion(id);
            return new OkResult();
            
        }
    }
}
