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

        public IEnumerable<Evaluation> GetEvaluationsByProjet(Guid ProjetId)
        {
            return _dbContext.Projets.Where(A => A.Id == ProjetId).FirstOrDefault().Evaluations;
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
            _dbContext.Add(Evaluation);
            Save();
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
