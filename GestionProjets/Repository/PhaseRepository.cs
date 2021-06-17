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
        private readonly QalitasContext _dbContext;


        public PhaseRepository(QalitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Phase> GetPhasesByProject(Guid ProjetId)
        {
            return _dbContext.Projets.Where(A => A.Id == ProjetId).FirstOrDefault().Phases;
        }

        public Phase GetPhaseByID(Guid PhaseId)
        {
            return _dbContext.Phases.Find(PhaseId);
        }

        public IEnumerable<Phase> GetPhases()
        {
            return _dbContext.Phases.ToList();
        }

        public void InsertPhase(Phase Phase)
        {
            if (Phase != null)
            {
                Projet p = _dbContext.Projets.Where(A => A.Id == Phase.ProjetId).FirstOrDefault();
                p.Phases.Add(Phase);
            }
            Save();
        }


        public void UpdatePhase(Phase Phase)
        {
            _dbContext.Entry(Phase).State = EntityState.Modified;
            Save();
        }

        public void DeletePhase(Guid PhaseId)
        {
            var Phase = _dbContext.Phases.Find(PhaseId);
            _dbContext.Phases.Remove(Phase);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
