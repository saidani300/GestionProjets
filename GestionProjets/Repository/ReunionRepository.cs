using GestionProjets.DBContext;
using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class ReunionRepository : IReunionRepository
    {
        private readonly QalitasContext _dbContext;

        public ReunionRepository(QalitasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Reunion> GetReunionsByProjet(Guid ProjetId)
        {
            return _dbContext.Projets.Where(A => A.Id == ProjetId).FirstOrDefault().Reunions;
        }

        public Reunion GetReunionByID(Guid ReunionId)
        {
            return _dbContext.Reunions.Find(ReunionId);
        }

        public IEnumerable<Reunion> GetReunions()
        {
            return _dbContext.Reunions.ToList();
        }

        public void InsertReunion(Reunion Reunion)
        {
            if (Reunion != null)
            {
                Projet p = _dbContext.Projets.Where(A => A.Id == Reunion.Id).FirstOrDefault();
                p.Reunions.Add(Reunion);
                Save();
            }
        }


        public void UpdateReunion(Reunion Reunion)
        {
            _dbContext.Entry(Reunion).State = EntityState.Modified;
            Save();
        }

        public void DeleteReunion(Guid ReunionId)
        {
            var Reunion = _dbContext.Reunions.Find(ReunionId);
            _dbContext.Reunions.Remove(Reunion);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
