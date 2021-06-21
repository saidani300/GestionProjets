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
        private readonly IAuthorizationService _authorizationService;

        public DocumentController(IDocumentRepository documentRepository, IProjetRepository projetRepository, IAutorisationRepository autorisationRepository , IAuthorizationService authorizationService)
        {
            _documentRepository = documentRepository;
            _projetRepository = projetRepository;
            _autorisationRepository = autorisationRepository;
            _authorizationService = authorizationService;

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

       

        [HttpPost]
        [Ref("Document2")]

        public IActionResult Post([FromBody] Document Model)
        {
           
                    using (var scope = new TransactionScope())
                    {
                        _documentRepository.InsertDocument(Model);
                        scope.Complete();
                        return CreatedAtAction(nameof(Get), new { id = Model.Id }, Model);
                    }
              
        }

        [HttpPut]
        [Ref("Document3")]
       // [Authorize(Policy = "HasUserAccess")]
        //[AuthorizeUpdate]
        public async Task<IActionResult> Put([FromBody] Document Model)
        {
           
                    if (Model != null)
                    {
                if ((await _authorizationService
                .AuthorizeAsync(User, Model, "EditPolicy")).Succeeded)
                {
                    using (var scope = new TransactionScope())
                    {
                        _documentRepository.UpdateDocument(Model);
                        scope.Complete();
                        return new OkResult();
                    }
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
