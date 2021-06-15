using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IEvaluationRepository
    {
        void DeleteEvaluation(Guid EvaluationId);
        Evaluation GetEvaluationByID(Guid EvaluationId);
        IEnumerable<Evaluation> GetEvaluations();
        IEnumerable<Evaluation> GetEvaluationsByProjet(Guid ProjetId);
        void InsertEvaluation(Evaluation Evaluation);
        void Save();
        void UpdateEvaluation(Evaluation Evaluation);
    }
}