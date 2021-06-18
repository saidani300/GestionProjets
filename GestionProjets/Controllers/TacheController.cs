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
    [Authorize(Roles = "Responsable,Chefdeprojet")]
    public class TacheController : ControllerBase
    {
        private readonly ITacheRepository _tacheRepository;
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;
        private readonly INotificationRepository _notificationRepository;

        private readonly IMapper _mapper;


        public TacheController(ITacheRepository tacheRepository  , IProjetRepository projetRepository, IAutorisationRepository autorisationRepository, INotificationRepository notificationRepository, IMapper mapper)
        {
            _tacheRepository = tacheRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
            _notificationRepository = notificationRepository;
            _mapper = mapper;

        }
        [HttpGet("getbyaction/{id}")]
        [Ref("Tache0")]

        public IActionResult GetByAction(Guid id)
        {
           
                var taches = _tacheRepository.GetTachesByAction(id);
                var tachesDTO = taches.Select(_mapper.Map<TacheDTO>);

                return new OkObjectResult(tachesDTO);
           
        }
        

        [HttpGet]
        [Ref("Tache1")]
        public IActionResult Get()
        {
           
                var taches = _tacheRepository.GetTaches();
                var tachesDTO = taches.Select(_mapper.Map<TacheDTO>);

                return new OkObjectResult(tachesDTO);
          
        }

        [HttpGet("{id}")]
        [Ref("Tache2")]
        public IActionResult Get(Guid id)
        {
            
                var tache = _tacheRepository.GetTacheByID(id);
                TacheDTO tacheDTO = _mapper.Map<TacheDTO>(tache);

                return new OkObjectResult(tacheDTO);
        

}

        internal bool Authorization(Tache tache, Guid projetId)
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
        [Ref("Tache3")]
        public IActionResult Post([FromBody] Tache tache)
        {

            using (var scope = new TransactionScope())
            {
                _tacheRepository.InsertTache(tache);
                scope.Complete();
            }
            //Notification
            Tache t = _tacheRepository.GetTacheByID(tache.Id);

            if (t.UserId != null)
                {
                    Notification notification = new Notification()
                    {
                        Nom = "Nom",
                        Description = $"{t.Utilisateur.Nom} {t.Utilisateur.Prenom}" +
                       $"vous a ajouté en tant que responsable sur la tache {tache.Nom}.",
                        DateCreation = DateTime.Now,
                        SourceId = t.Id,
                        UserId = t.UserId
                    };
                    _notificationRepository.InsertNotification(notification);
                }
                return CreatedAtAction(nameof(Get), new { id = tache.Id }, tache);
            
               
        }
        [Authorize(Roles = "Responsable,Chefdeprojet,Membre")]
        [HttpPut]
        [Ref("Tache4")]
        public IActionResult Put([FromBody] Tache tache)
        {
            
                    if (tache != null)
            {
                using (var scope = new TransactionScope())
                {
                    Tache Otache = _tacheRepository.GetTacheByID(tache.Id);

                    _tacheRepository.UpdateTache(tache);
                    scope.Complete();
                }

                //Notification
                Tache t = _tacheRepository.GetTacheByID(tache.Id);
                    if (t.UserId != null && t.UserId != tache.UserId)
                    {
                        Notification notification = new Notification()
                        {
                            Nom = "Nom",
                            Description = $"{t.Utilisateur.Nom} {t.Utilisateur.Prenom}" +
                           $"vous a ajouté en tant que responsable sur la tache {tache.Nom}.",
                            DateCreation = DateTime.Now,
                            SourceId = t.Id,
                            UserId = t.UserId
                        };
                        _notificationRepository.InsertNotification(notification);
                    }
                    return new OkResult();
                
            }
            return new NoContentResult();
               
        }

        [HttpDelete("{id}")]
        [Ref("Tache5")]
        public IActionResult Delete(Guid id)
        {
          
                _tacheRepository.DeleteTache(id);
            return new OkResult();
           
        }
    }
}
