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
    public class ProjetController : ControllerBase
    {
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;
        private readonly IMapper _mapper;

        public ProjetController(IProjetRepository projetRepository, IAutorisationRepository autorisationRepository , IMapper mapper)
        {
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
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
                projet.ChefId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                _projetRepository.InsertProjet(projet);
                scope.Complete();
                ProjetDTO projetDTO = _mapper.Map<ProjetDTO>(projet);

                return CreatedAtAction(nameof(Get), new { id = projet.Id }, projetDTO);
            }
               
          
        }

        [HttpPut]
        [Ref("Projet4")]
        [Utilisateur]

        public IActionResult Put([FromBody] Projet projet)
        {
           
                    if (projet != null)
            {
                using (var scope = new TransactionScope())
                {
                    projet.DateModification = DateTime.Now;
                    _projetRepository.UpdateProjet(projet);
                    scope.Complete();
                    return new OkResult();
                }
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
