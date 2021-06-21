using GestionProjets.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GestionProjets.AuthorizationAttributes
{
    public class DocumentAuthorizationHandler :
        AuthorizationHandler<SameAuthorRequirement, Document>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       SameAuthorRequirement requirement,
                                                       Document resource)
        {
            if (new Guid(context.User.FindFirstValue(ClaimTypes.NameIdentifier)) == resource.Projet.UserId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    public class SameAuthorRequirement : IAuthorizationRequirement { }
}
