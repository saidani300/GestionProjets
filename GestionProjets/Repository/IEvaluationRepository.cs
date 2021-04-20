using GestionProjets.Models;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IEvaluationRepository
    {
        void DeleteEvaluation(string EvaluationId);
        Evaluation GetEvaluationByID(string EvaluationId);
        IEnumerable<Evaluation> GetEvaluations();
        void InsertEvaluation(Evaluation Evaluation);
        void Save();
        void UpdateEvaluation(Evaluation Evaluation);
    }
}