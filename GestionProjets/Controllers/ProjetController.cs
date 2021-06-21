using AutoMapper;
using GestionProjets.AuthorizationAttributes;
using GestionProjets.ErrorHandling;
using GestionProjets.Models;
using GestionProjets.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;


namespace GestionProjets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Responsable")]
    public class ProjetController : ControllerBase
    {
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IAuthorizationService _authorizationService;

        private readonly IMapper _mapper;

        public ProjetController(IProjetRepository projetRepository, IAutorisationRepository autorisationRepository , INotificationRepository notificationRepository, IMapper mapper, IAuthorizationService authorizationService)
        {
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
            _notificationRepository = notificationRepository;
            _authorizationService = authorizationService;

            _mapper = mapper;
        }

        [HttpGet("getbyutilisateur/{id}")]
        [Ref("Projet0")]

        public IActionResult GetByUtilisateur(Guid id)
        {
           
                var projets = _projetRepository.GetProjetsByUtilisateur(id);
                //Mapping
                var projetsDTO = projets.Select(_mapper.Map<ProjetDTO>);

                return new OkObjectResult(projetsDTO);
           
        }

        [HttpGet]
        [Ref("Projet1")]

        public IActionResult Get()
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var projets = _projetRepository.GetProjets(new Guid(LoggedInuserId));
            var projetsDTO = projets.Select(_mapper.Map<ProjetDTO>);

            //throw new AppException("Message 1");

           return new OkObjectResult(projetsDTO);

        }

        [HttpGet("{id}")]
        [Ref("Projet2")]

        public IActionResult Get(Guid id)
        {
           
                var projet = _projetRepository.GetProjetByID(id);
                ProjetDTO projetDTO = _mapper.Map<ProjetDTO>(projet);

                return new OkObjectResult(projet);
        }

        internal bool Authorization(Projet projet)
        {

            Guid LoggedInuserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Guid projetChefId = (Guid)projet.ChefId;
            Guid projetUserId = projet.UserId;
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
        [Ref("Projet3")]

        public IActionResult Post([FromBody] Projet projet)
        {

            using (var scope = new TransactionScope())
            {
                projet.UserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                _projetRepository.InsertProjet(projet);
                scope.Complete();
            }
            Projet p = _projetRepository.GetProjetByID(projet.Id);
                //Notification
                if (p.ChefId != null)
                {
                    var notification = new Notification
                    {
                        Nom = "Notification",
                        Description = $"{p.Responsable.Nom} {p.Responsable.Prenom}" +
                        "vous a ajouté en tant que chef de projet.",
                        DateCreation = DateTime.Now,
                        SourceId = p.Id,
                        UserId = (Guid)p.ChefId
                };

                  //Error  _notificationRepository.InsertNotification(notification);
                _notificationRepository.Notification(notification.UserId, notification);
                }
                //return
                ProjetDTO projetDTO = _mapper.Map<ProjetDTO>(projet);
                return new OkObjectResult(projet);
            
               
          
        }

        [HttpPut]
        [Ref("Projet4")]

        public async Task<IActionResult> Put([FromBody] Projet Model)
        {
          
                if (Model != null)
            {
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, Model, "EditPolicy");
                if (authorizationResult.Succeeded)
                {
                    using (var scope = new TransactionScope())
                {
                    Projet Oprojet = _projetRepository.GetProjetByID(Model.Id);
                    Model.DateModification = DateTime.Now;
                    _projetRepository.UpdateProjet(Model);
                    scope.Complete();
                }
                    Projet p = _projetRepository.GetProjetByID(Model.Id);

                    //Notification
                    if (p.ChefId != null && p.ChefId != Model.ChefId)
                    {
                        Notification notification = new Notification()
                        {
                            Nom = "Nom",
                            Description = $"{p.Responsable.Nom} {p.Responsable.Prenom}" +
                           "vous a ajouté en tant que chef de projet.",
                            DateCreation = DateTime.Now,
                            SourceId = p.Id,
                            UserId = (Guid)p.ChefId
                        };
                        _notificationRepository.InsertNotification(notification);
                    }
                    return new OkResult();
                }
                return new UnauthorizedResult();
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        [Ref("Projet5")]

        public IActionResult Delete(Guid id)
        {
          
            _projetRepository.DeleteProjet(id);
            return new OkResult();          
        }


       
    }
}
