using GestionProjets.Models;
using GestionProjets.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.AuthorizationAttributes
{
    public class UserAccessHandler : AuthorizationHandler<UserAccessRequirement>
    {

        private readonly IDocumentRepository _documentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserAccessHandler(IDocumentRepository documentRepository , IHttpContextAccessor httpContextAccessor)
        {
            _documentRepository = documentRepository;
            _httpContextAccessor = httpContextAccessor;

        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserAccessRequirement requirement)
        {

            // var Model = authContext.RouteData.Values["Model"];
            _httpContextAccessor.HttpContext.GetEndpoint().Metadata.OfType<IFilterMetadata>();
            var actionDescriptor = _httpContextAccessor.HttpContext.GetEndpoint().Metadata.OfType<ControllerActionDescriptor>().SingleOrDefault();
            var attributes = actionDescriptor?.MethodInfo.GetCustomAttributes(typeof(Document), true);

            var Model = _httpContextAccessor.HttpContext.GetEndpoint().Metadata;

                if (Model.GetType() == typeof(Document))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
           
           return Task.CompletedTask;
        }
    }
}
