﻿using GestionProjets.DBContext;
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
        private readonly QualitasContext _dbContext;

        public IndicateurRepository(QualitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteIndicateur(string IndicateurId)
        {
            var Indicateur = _dbContext.Indicateurs.Find(IndicateurId);
            _dbContext.Indicateurs.Remove(Indicateur);
            Save();
        }

        public Indicateur GetIndicateurByID(string IndicateurId)
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

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateIndicateur(Indicateur Indicateur)
        {
            _dbContext.Entry(Indicateur).State = EntityState.Modified;
            Save();
        }
    }
}