using GestionProjets.DBContext;
using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class PhaseRepository : IPhaseRepository
    {
        private readonly QualitasContext _dbContext;


        public PhaseRepository(QualitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Phase> GetPhasesByProject(Guid ProjetId)
        {
            return _dbContext.Phases.Where(A => A.ProjetId == ProjetId);
        }
        public void DeletePhase(string PhaseId)
        {
            var Phase = _dbContext.Phases.Find(PhaseId);
            _dbContext.Phases.Remove(Phase);
            Save();
        }

        public Phase GetPhaseByID(string PhaseId)
        {
            return _dbContext.Phases.Find(PhaseId);
        }

        public IEnumerable<Phase> GetPhases()
        {
            return _dbContext.Phases.ToList();
        }

        public void InsertPhase(Phase Phase)
        {
            _dbContext.Add(Phase);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdatePhase(Phase Phase)
        {
            _dbContext.Entry(Phase).State = EntityState.Modified;
            Save();
        }
    }
}
