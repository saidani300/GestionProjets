using GestionProjets.Models;
using GestionProjets.Repository;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GestionProjets.AuthorizationAttributes
{
    public class UpdateAuthorizationHandler :
        AuthorizationHandler<SameUserRequirement, object>

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

        public UpdateAuthorizationHandler(IActionRepository actionRepository, IDocumentRepository documentRepository,
                                 IEvaluationRepository evaluationRepository, IIndicateurRepository indicateurRepository,
                                 IMesureRepository mesureRepository, IObjectifRepository objectifRepository,
                                 IOpportuniteRepository opportuniteRepository, IPhaseRepository phaseRepository,
                                 IProjetRepository projetRepository, IReunionRepository reunionRepository,
                                 IRisqueRepository risqueRepository, ITacheRepository tacheRepository)
        {
            _actionRepository = actionRepository;
            _documentRepository = documentRepository;
            _evaluationRepository = evaluationRepository;
            _indicateurRepository = indicateurRepository;
            _mesureRepository = mesureRepository;
            _objectifRepository = objectifRepository;
            _opportuniteRepository = opportuniteRepository;
            _phaseRepository = phaseRepository;
            _projetRepository = projetRepository;
            _reunionRepository = reunionRepository;
            _risqueRepository = risqueRepository;
            _tacheRepository = tacheRepository;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       SameUserRequirement requirement,
                                                       object resource)
        {
            if (resource.GetType() == typeof(Projet))
            {
                Projet model = (Projet)resource;
                Projet Projet = _projetRepository.GetProjetByID(model.Id);
                if (new Guid(context.User.FindFirstValue(ClaimTypes.NameIdentifier)) == Projet.UserId)
                {
                    context.Succeed(requirement);
                }
            }
            else if (resource.GetType() == typeof(Document))
            {
                Document d = (Document)resource;
                Document document = _documentRepository.GetDocumentByID(d.Id);
                if (new Guid(context.User.FindFirstValue(ClaimTypes.NameIdentifier)) == document.Projet.UserId)
                {
                    context.Succeed(requirement);
                }
            }
            else if (resource.GetType() == typeof(Phase))
            {
                Phase model = (Phase)resource;
                Phase Phase = _phaseRepository.GetPhaseByID(model.Id);
                if (new Guid(context.User.FindFirstValue(ClaimTypes.NameIdentifier)) == Phase.Projet.UserId)
                {
                    context.Succeed(requirement);
                }
            }
            else if (resource.GetType() == typeof(Models.Action))
            {
                Models.Action model = (Models.Action)resource;
                Models.Action Action = _actionRepository.GetActionByID(model.Id);
                if (Action.ProjetId != null)
                {
                    if (new Guid(context.User.FindFirstValue(ClaimTypes.NameIdentifier)) == Action.Projet.UserId)
                    {
                        context.Succeed(requirement);
                    }
                }
                else
                {
                    if (new Guid(context.User.FindFirstValue(ClaimTypes.NameIdentifier)) == Action.Phase.Projet.UserId)
                    {
                        context.Succeed(requirement);
                    }
                }
            }
            else if (resource.GetType() == typeof(Tache))
            {
                Tache model = (Tache)resource;
                Tache Tache = _tacheRepository.GetTacheByID(model.Id);
                if (new Guid(context.User.FindFirstValue(ClaimTypes.NameIdentifier)) == Tache.Action.Projet.UserId)
                {
                    context.Succeed(requirement);
                }
            }
            else if (resource.GetType() == typeof(Reunion))
            {
                Reunion model = (Reunion)resource;
                Reunion Reunion = _reunionRepository.GetReunionByID(model.Id);
                if (new Guid(context.User.FindFirstValue(ClaimTypes.NameIdentifier)) == Reunion.Projet.UserId)
                {
                    context.Succeed(requirement);
                }
            }
            else if (resource.GetType() == typeof(Objectif))
            {
                Objectif model = (Objectif)resource;
                Objectif Objectif = _objectifRepository.GetObjectifByID(model.Id);
                if (new Guid(context.User.FindFirstValue(ClaimTypes.NameIdentifier)) == Objectif.Projet.UserId)
                {
                    context.Succeed(requirement);
                }
            }
            else if (resource.GetType() == typeof(Risque))
            {
                Risque model = (Risque)resource;
                Risque Risque = _risqueRepository.GetRisqueByID(model.Id);
                if (new Guid(context.User.FindFirstValue(ClaimTypes.NameIdentifier)) == Risque.Projet.UserId)
                {
                    context.Succeed(requirement);
                }
            }
            else if (resource.GetType() == typeof(Opportunite))
            {
                Opportunite model = (Opportunite)resource;
                Opportunite Opportunite = _opportuniteRepository.GetOpportuniteByID(model.Id);
                if (new Guid(context.User.FindFirstValue(ClaimTypes.NameIdentifier)) == Opportunite.Projet.UserId)
                {
                    context.Succeed(requirement);
                }
            }
            else if (resource.GetType() == typeof(Indicateur))
            {
                Indicateur model = (Indicateur)resource;
                Indicateur Indicateur = _indicateurRepository.GetIndicateurByID(model.Id);
                if (new Guid(context.User.FindFirstValue(ClaimTypes.NameIdentifier)) == Indicateur.Objectif.Projet.UserId)
                {
                    context.Succeed(requirement);
                }
            }
            else if (resource.GetType() == typeof(Mesure))
            {
                Mesure model = (Mesure)resource;
                Mesure Mesure = _mesureRepository.GetMesureByID(model.Id);
                if (new Guid(context.User.FindFirstValue(ClaimTypes.NameIdentifier)) == Mesure.Indicateur.Objectif.Projet.UserId)
                {
                    context.Succeed(requirement);
                }
            }
            else if (resource.GetType() == typeof(Evaluation))
            {
                Evaluation model = (Evaluation)resource;
                Evaluation Evaluation = _evaluationRepository.GetEvaluationByID(model.Id);
                if (Evaluation.OpportuniteId != null)
                {
                    if (new Guid(context.User.FindFirstValue(ClaimTypes.NameIdentifier)) == Evaluation.Opportunite.Projet.UserId)
                    {
                        context.Succeed(requirement);
                    }
                }
                else
                {
                    if (new Guid(context.User.FindFirstValue(ClaimTypes.NameIdentifier)) == Evaluation.Risque.Projet.UserId)
                    {
                        context.Succeed(requirement);
                    }
                }
            }
            return Task.CompletedTask;
        }
    }

    public class SameUserRequirement : IAuthorizationRequirement { }
}
