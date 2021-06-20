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
    public class AuthorizeUpdateAttribute : TypeFilterAttribute
    {
        public AuthorizeUpdateAttribute()
           : base(typeof(AuthorizeUpdateFilter))
        {
        }
    }
    public class AuthorizeUpdateFilter :  IAuthorizationFilter
    {

        private readonly IActionRepository _actionRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IIndicateurRepository _indicateurRepository;
        private readonly IMesureRepository _mesureRepository;
        private readonly IObjectifRepository _objectifRepository;
        private readonly IOpportuniteRepository _opportuniteRepository;
        private readonly IPhaseRepository _phaseRepository;
        private readonly IProjetRepository _projetRepository;
        private readonly IReunionRepository _reunionRepository;
        private readonly IRisqueRepository _risqueRepository;
        private readonly ITacheRepository _tacheRepository;

        public AuthorizeUpdateFilter(IActionRepository actionRepository,IDocumentRepository documentRepository,
                                 IEvaluationRepository evaluationRepository,IIndicateurRepository indicateurRepository,
                                 IMesureRepository mesureRepository,IObjectifRepository objectifRepository,
                                 IOpportuniteRepository opportuniteRepository,IPhaseRepository phaseRepository,
                                 IProjetRepository projetRepository,IReunionRepository reunionRepository,
                                 IRisqueRepository risqueRepository,ITacheRepository tacheRepository)
        {
        _actionRepository = actionRepository;
        _documentRepository = documentRepository;
        _evaluationRepository = evaluationRepository;
        _indicateurRepository = indicateurRepository;
        _mesureRepository= mesureRepository;
        _objectifRepository = objectifRepository;
        _opportuniteRepository = opportuniteRepository;
        _phaseRepository = phaseRepository;
        _projetRepository = projetRepository;
        _reunionRepository = reunionRepository;
        _risqueRepository =risqueRepository;
        _tacheRepository = tacheRepository;

    }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var rf = context.HttpContext.Request;
            var rv = context.HttpContext.Request.RouteValues["Model"] as Document;
            var citems = context.HttpContext.Request.Headers;
            string LoggedInuserId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

           /* var Model = rv;
            //Projet [Responsable]
            if (Model.GetType() == typeof(Projet))
            {
                Projet p = Model;
                Projet model = _projetRepository.GetProjetByID(p.Id);

                if (!model.UserId.Equals(new Guid(LoggedInuserId)))

                    context.Result = new UnauthorizedResult();
            }
            //Phase [Responsable , ChefdeProjet]
            else if (Model.GetType() == typeof(Phase))
            {
                Phase p = (Phase)Model;
                Phase model = _phaseRepository.GetPhaseByID(p.Id);

                if (!model.Projet.UserId.Equals(new Guid(LoggedInuserId)) || !model.Projet.ChefId.Equals(new Guid(LoggedInuserId)))

                    context.Result = new UnauthorizedResult();
            }
            //Action  [Responsable , ChefdeProjet]
            else if (Model.GetType() == typeof(Models.Action))
            {
                Models.Action a = (Models.Action)Model;
                Models.Action model = _actionRepository.GetActionByID(a.Id);

                if (!model.Projet.UserId.Equals(new Guid(LoggedInuserId))
                 || !model.Projet.ChefId.Equals(new Guid(LoggedInuserId)))

                    context.Result = new UnauthorizedResult();
            }

            //Tache [Responsable , ChefdeProjet , Membre]
            else if (Model.GetType() == typeof(Tache))
            {
                Tache t = (Tache)Model;
                Tache model = _tacheRepository.GetTacheByID(t.Id);

                if (!model.Action.Projet.UserId.Equals(new Guid(LoggedInuserId)) 
                 || !model.Action.Projet.ChefId.Equals(new Guid(LoggedInuserId))
                 || !model.UserId.Equals(new Guid(LoggedInuserId)))

                    context.Result = new UnauthorizedResult();
            }
            //Objectif [Responsable]
            else if (Model.GetType() == typeof(Objectif))
            {
                Objectif o = (Objectif)Model;
                Objectif model = _objectifRepository.GetObjectifByID(o.Id);

                if (!model.Projet.UserId.Equals(new Guid(LoggedInuserId)))

                    context.Result = new UnauthorizedResult();
            }
            //Indicateur [Responsable]
            else if (Model.GetType() == typeof(Indicateur))
            {
                Indicateur i = (Indicateur)Model;
                Indicateur model = _indicateurRepository.GetIndicateurByID(i.Id);

                if (!model.Objectif.Projet.UserId.Equals(new Guid(LoggedInuserId)))

                    context.Result = new UnauthorizedResult();
            }
            //Mesure [Responsable]
            else if (Model.GetType() == typeof(Mesure))
            {
                Mesure m = (Mesure)Model;
                Mesure model = _mesureRepository.GetMesureByID(m.Id);

                if (!model.Indicateur.Objectif.Projet.UserId.Equals(new Guid(LoggedInuserId)))

                    context.Result = new UnauthorizedResult();
            }
            //Document [Responsable]
            else if (Model.GetType() == typeof(Document))
            {
                Document d = (Document)Model;
                Document model = _documentRepository.GetDocumentByID(d.Id);

                if (!model.Projet.UserId.Equals(new Guid(LoggedInuserId)))

                    context.Result = new UnauthorizedResult();
            }

            //Reunion [Responsable]
            else if (Model.GetType() == typeof(Reunion))
            {
                Reunion r = (Reunion)Model;
                Reunion model = _reunionRepository.GetReunionByID(r.Id);

                if (!model.Projet.UserId.Equals(new Guid(LoggedInuserId)))

                    context.Result = new UnauthorizedResult();
            }

            //Risque [Responsable]
            else if (Model.GetType() == typeof(Risque))
            {
                Risque r = (Risque)Model;
                Risque model = _risqueRepository.GetRisqueByID(r.Id);

                if (!model.Projet.UserId.Equals(new Guid(LoggedInuserId)))

                    context.Result = new UnauthorizedResult();
            }

            //Opportunite [Responsable]
            else if (Model.GetType() == typeof(Opportunite))
            {
                Opportunite o = (Opportunite)Model;
                Opportunite model = _opportuniteRepository.GetOpportuniteByID(o.Id);

                if (!model.Projet.UserId.Equals(new Guid(LoggedInuserId)))

                    context.Result = new UnauthorizedResult();
            }

            //Evaluation [Responsable]
            else if (Model.GetType() == typeof(Evaluation))
            {
                Evaluation e = (Evaluation)Model;
                Evaluation model = _evaluationRepository.GetEvaluationByID(e.Id);

                if (model.OpportuniteId != null)
                {
                    if (!model.Opportunite.Projet.UserId.Equals(new Guid(LoggedInuserId)))

                        context.Result = new UnauthorizedResult();
                }
                else if (model.RisqueId != null)
                {
                    if (!model.Risque.Projet.UserId.Equals(new Guid(LoggedInuserId)))

                        context.Result = new UnauthorizedResult();
                }
            }*/
        }
    }
}
