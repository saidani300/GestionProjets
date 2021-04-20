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
        private readonly QualitasContext _dbContext;

        public ReunionRepository(QualitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteReunion(string ReunionId)
        {
            var Reunion = _dbContext.Reunions.Find(ReunionId);
            _dbContext.Reunions.Remove(Reunion);
            Save();
        }

        public Reunion GetReunionByID(string ReunionId)
        {
            return _dbContext.Reunions.Find(ReunionId);
        }

        public IEnumerable<Reunion> GetReunions()
        {
            return _dbContext.Reunions.ToList();
        }

        public void InsertReunion(Reunion Reunion)
        {
            _dbContext.Add(Reunion);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateReunion(Reunion Reunion)
        {
            _dbContext.Entry(Reunion).State = EntityState.Modified;
            Save();
        }
    }
}
