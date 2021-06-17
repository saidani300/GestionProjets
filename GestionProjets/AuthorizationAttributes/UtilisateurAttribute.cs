using GestionProjets.Models;
using GestionProjets.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace GestionProjets.AuthorizationAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UtilisateurAttribute : TypeFilterAttribute
    {
        public UtilisateurAttribute()
           : base(typeof(UtilisateurFilter))
        {
          
        }
    }
    public class UtilisateurFilter : IAuthorizationFilter
    {


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var rv = context.HttpContext.Request.RouteValues;

            Projet projet = (Projet)rv["projet"];

            
            string LoggedInuserId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!projet.UserId.Equals(new Guid(LoggedInuserId)))

                context.Result = new UnauthorizedResult();

        }
    }
}
