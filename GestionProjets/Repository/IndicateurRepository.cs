using GestionProjets.DBContext;
using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class IndicateurRepository : IIndicateurRepository
    {
        private readonly QalitasContext _dbContext;

        public IndicateurRepository(QalitasContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Indicateur GetIndicateurByID(Guid IndicateurId)
        {
            return _dbContext.Indicateurs.Find(IndicateurId);
        }

        public IEnumerable<Indicateur> GetIndicateurs()
        {
            return _dbContext.Indicateurs.ToList();
        }

        public void InsertIndicateur(Indicateur Indicateur)
        {
            _dbContext.Add(Indicateur);
            Save();
        }


        public void UpdateIndicateur(Indicateur Indicateur)
        {
            _dbContext.Entry(Indicateur).State = EntityState.Modified;
            Save();
        }

        public void DeleteIndicateur(Guid IndicateurId)
        {
            var Indicateur = _dbContext.Indicateurs.Find(IndicateurId);
            _dbContext.Indicateurs.Remove(Indicateur);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
