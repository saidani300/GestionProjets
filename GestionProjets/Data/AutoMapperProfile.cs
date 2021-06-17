using AutoMapper;
using GestionProjets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Projet, ProjetDTO>();
            CreateMap<Phase, PhaseDTO>();
            CreateMap<Models.Action, Models.ActionDTO>();
            CreateMap<Tache, TacheDTO>();
            CreateMap<Evaluation, EvaluationDTO>();
            CreateMap<Mesure, MesureDTO>();
            CreateMap<Reunion, ReunionDTO>();
            CreateMap<Document, DocumentDTO>();
            CreateMap<Objectif, ObjectifDTO>();
            CreateMap<Opportunite, OpportuniteDTO>();
            CreateMap<Risque, RisqueDTO>();
            CreateMap<Utilisateur, UtilisateurDTO>();

        }
    }
}
