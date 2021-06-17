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
    public class RefAttribute : TypeFilterAttribute
    {
        public RefAttribute(string Ref)
            : base(typeof(RefFilter))
        {
            Arguments = new object[] { Ref };
        }
    }
    public class RefFilter : IAuthorizationFilter
    {
        public string Ref { get; set; }

        private readonly IAutorisationRepository _autorisationRepository;

        public RefFilter(string _ref, IAutorisationRepository autorisationRepository)
        {
            Ref = _ref;
            _autorisationRepository = autorisationRepository;

        }

    


        public void OnAuthorization(AuthorizationFilterContext context)
        {

            string LoggedInuserId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!_autorisationRepository.Autorisation(new Guid(LoggedInuserId), Ref))

                context.Result = new UnauthorizedResult();
    
        }
    }
}
