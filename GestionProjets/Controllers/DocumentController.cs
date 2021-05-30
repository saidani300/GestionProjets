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
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IProjetRepository _projetRepository;
        private readonly IAutorisationRepository _autorisationRepository;

        public DocumentController(IDocumentRepository documentRepository, IProjetRepository projetRepository, IAutorisationRepository autorisationRepository)
        {
            _documentRepository = documentRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
        }
        [HttpGet("~/getbyprojet/{id}")]

        public IActionResult GetByProject(Guid id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Document0"))
            {
                var documents = _documentRepository.GetDocumetsByProject(id);
                return new OkObjectResult(documents);
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
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Document1"))
            {
                var document = _documentRepository.GetDocumentByID(id);
                return new OkObjectResult(document);
            }
            else
            {
                return BadRequest();
            }
        }

        internal bool Authorization(Document document)
        {

            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid projetId = document.IdProjet;
            Guid projetChefId = _projetRepository.GetProjetByID(projetId).ChefId;
            Guid projetUserId = _projetRepository.GetProjetByID(projetId).UserId;
            if (projetUserId.ToString() == LoggedInuserId || projetChefId.ToString() == LoggedInuserId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Document document)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Document2"))
            {
                if (Authorization(document))
                {
                    using (var scope = new TransactionScope())
                    {
                        _documentRepository.InsertDocument(document);
                        scope.Complete();
                        return CreatedAtAction(nameof(Get), new { id = document.Id }, document);
                    }
                }
                else
                { return BadRequest(); }
            }
            else
            { return BadRequest(); }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Document document)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Document3"))
            {
                if (Authorization(document))
                {
                    if (document != null)
                    {
                        using (var scope = new TransactionScope())
                        {
                            _documentRepository.UpdateDocument(document);
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
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_autorisationRepository.Autorisation(new Guid(LoggedInuserId), "Document4"))
            {
                Document document = _documentRepository.GetDocumentByID(id);
                if (Authorization(document))
                {
                    _documentRepository.DeleteDocument(id);
                    return new OkResult();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
