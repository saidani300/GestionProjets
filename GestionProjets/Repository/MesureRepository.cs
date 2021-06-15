using GestionProjets.DBContext;
using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class MesureRepository : IMesureRepository
    {
        private readonly QalitasContext _dbContext;

        public MesureRepository(QalitasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Mesure> GetMesuresByProject(Guid ProjetId)
        {
            return _dbContext.Projets.Where(A => A.Id == ProjetId).FirstOrDefault().Mesures;
        }

        public Mesure GetMesureByID(Guid MesureId)
        {
            return _dbContext.Mesures.Find(MesureId);
        }

        public IEnumerable<Mesure> GetMesures()
        {
            return _dbContext.Mesures.ToList();
        }

        public void InsertMesure(Mesure Mesure)
        {
            _dbContext.Add(Mesure);
            Save();
        }



        public void UpdateMesure(Mesure Mesure)
        {
            _dbContext.Entry(Mesure).State = EntityState.Modified;
            Save();
        }

        public void DeleteMesure(Guid MesureId)
        {
            var Mesure = _dbContext.Mesures.Find(MesureId);
            _dbContext.Mesures.Remove(Mesure);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
