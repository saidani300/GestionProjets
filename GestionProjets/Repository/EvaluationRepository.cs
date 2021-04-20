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
        private readonly QualitasContext _dbContext;

        public EvaluationRepository(QualitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteEvaluation(string EvaluationId)
        {
            var Evaluation = _dbContext.Evaluations.Find(EvaluationId);
            _dbContext.Evaluations.Remove(Evaluation);
            Save();
        }

        public Evaluation GetEvaluationByID(string EvaluationId)
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

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateEvaluation(Evaluation Evaluation)
        {
            _dbContext.Entry(Evaluation).State = EntityState.Modified;
            Save();
        }
    }
}
