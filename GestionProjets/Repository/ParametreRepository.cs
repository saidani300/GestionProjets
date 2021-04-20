using GestionProjets.DBContext;
using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class ParametreRepository : IParametreRepository
    {
        private readonly QualitasContext _dbContext;

        public ParametreRepository(QualitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteParametre(string ParametreId)
        {
            var Parametre = _dbContext.Parametres.Find(ParametreId);
            _dbContext.Parametres.Remove(Parametre);
            Save();
        }

        public Parametre GetParametreByID(string ParametreId)
        {
            return _dbContext.Parametres.Find(ParametreId);
        }

        public IEnumerable<Parametre> GetParametres()
        {
            return _dbContext.Parametres.ToList();
        }

        public void InsertParametre(Parametre Parametre)
        {
            _dbContext.Add(Parametre);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateParametre(Parametre Parametre)
        {
            _dbContext.Entry(Parametre).State = EntityState.Modified;
            Save();
        }
    }
}
