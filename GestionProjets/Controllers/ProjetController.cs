﻿using AutoMapper;
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

        public IActionResult GetByUtilisateur(Guid id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Projet0"))
            {
                var projets = _projetRepository.GetProjetsByUtilisateur(id);
                var projetsDTO = projets.Select(_mapper.Map<ProjetDTO>);

                return new OkObjectResult(projetsDTO);
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
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Projet1"))
            {
            var projets = _projetRepository.GetProjets(new Guid(LoggedInuserId));
            var projetsDTO = projets.Select(_mapper.Map<ProjetDTO>);
            return new OkObjectResult(projets);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Projet2"))
            {
                var projet = _projetRepository.GetProjetByID(id);
                ProjetDTO projetDTO = _mapper.Map<ProjetDTO>(projet);

                return new OkObjectResult(projetDTO);
            }
            else
            {
                return BadRequest();
            }
        }

        internal bool Authorization(Projet projet)
        {

            Guid LoggedInuserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Guid projetChefId = projet.ChefId;
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
        public IActionResult Post([FromBody] Projet projet)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Projet3"))
            {
               /* if (Authorization(projet))
                {*/
                    using (var scope = new TransactionScope())
            {
                _projetRepository.InsertProjet(projet);
                scope.Complete();
                ProjetDTO projetDTO = _mapper.Map<ProjetDTO>(projet);

                return CreatedAtAction(nameof(Get), new { id = projet.Id }, projetDTO);
            }
                }
                else
                {
                    return BadRequest();
                }
           /* }
            else
            {
                return BadRequest();
            }*/
        }

        [HttpPut]
        public IActionResult Put([FromBody] Projet projet)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Projet4"))
            {
                //if (Authorization(projet))
                //{
                    if (projet != null)
            {
                using (var scope = new TransactionScope())
                {
                    _projetRepository.UpdateProjet(projet);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
                //}
                //else
                //{
                //    return BadRequest();
                //}
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Projet5"))
            {
                _projetRepository.DeleteProjet(id);
            return new OkResult();
            }
            else
            {
                return BadRequest();
            }
        }


       
    }
}
