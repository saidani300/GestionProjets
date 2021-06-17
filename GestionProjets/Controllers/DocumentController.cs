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

        [HttpGet("getbyprojet/{id}")]
        [Ref("Document0")]

        public IActionResult GetByProject(Guid id)
        {
           
                var documents = _documentRepository.GetDocumetsByProject(id);
                return new OkObjectResult(documents);
           
        }


        [HttpGet("{id}")]
        [Ref("Document1")]

        public IActionResult Get(Guid id)
        {
            
                var document = _documentRepository.GetDocumentByID(id);
                return new OkObjectResult(document);
           
        }

        internal bool Authorization(Document document , Guid projetId)
        {

            string LoggedInuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid projetChefId = (Guid)_projetRepository.GetProjetByID(projetId).ChefId;
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
        [Ref("Document2")]

        public IActionResult Post([FromBody] Document document)
        {
           
                    using (var scope = new TransactionScope())
                    {
                        _documentRepository.InsertDocument(document);
                        scope.Complete();
                        return CreatedAtAction(nameof(Get), new { id = document.Id }, document);
                    }
              
        }

        [HttpPut]
        [Ref("Document3")]

        public IActionResult Put([FromBody] Document document)
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

        [HttpDelete("{id}")]
        [Ref("Document4")]

        public IActionResult Delete(Guid id)
        {
           
                Document document = _documentRepository.GetDocumentByID(id);
                
                    _documentRepository.DeleteDocument(id);
                    return new OkResult();
               
        }
    }
}
