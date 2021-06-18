using GestionProjets.DBContext;
using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class EvaluationRepository : IEvaluationRepository
    {
        private readonly QalitasContext _dbContext;

        public EvaluationRepository(QalitasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Evaluation> GetEvaluationsByOpportunite(Guid Id)
        {
            return _dbContext.Opportunites.Where(A => A.Id == Id).FirstOrDefault().Evaluations;
        }

        public IEnumerable<Evaluation> GetEvaluationsByRisque(Guid Id)
        {
            return _dbContext.Risques.Where(A => A.Id == Id).FirstOrDefault().Evaluations;
        }

        public Evaluation GetEvaluationByID(Guid EvaluationId)
        {
            return _dbContext.Evaluations.Find(EvaluationId);
        }

        public IEnumerable<Evaluation> GetEvaluations()
        {
            return _dbContext.Evaluations.ToList();
        }

        public void InsertEvaluation(Evaluation Evaluation)
        {
            if (Evaluation != null)
            {
                if (Evaluation.OpportuniteId != null)
                {
                    Opportunite opportunite = _dbContext.Opportunites.Where(A => A.Id == Evaluation.OpportuniteId).FirstOrDefault();
                    opportunite.Evaluations.Add(Evaluation);
                    Save();
                }
                else if (Evaluation.RisqueId != null)
                {
                    Risque risque = _dbContext.Risques.Where(A => A.Id == Evaluation.RisqueId).FirstOrDefault();
                    risque.Evaluations.Add(Evaluation);
                    Save();
                }
            }
        }


        public void UpdateEvaluation(Evaluation Evaluation)
        {
            _dbContext.Entry(Evaluation).State = EntityState.Modified;
            Save();
        }

        public void DeleteEvaluation(Guid EvaluationId)
        {
            var Evaluation = _dbContext.Evaluations.Find(EvaluationId);
            _dbContext.Evaluations.Remove(Evaluation);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
