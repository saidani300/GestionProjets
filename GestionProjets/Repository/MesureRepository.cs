﻿using GestionProjets.DBContext;
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
        private readonly QualitasContext _dbContext;

        public MesureRepository(QualitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteMesure(string MesureId)
        {
            var Mesure = _dbContext.Mesures.Find(MesureId);
            _dbContext.Mesures.Remove(Mesure);
            Save();
        }
        public IEnumerable<Mesure> GetMesuresByProject(Guid ProjetId)
        {
            return _dbContext.Mesures.Where(A => A.ProjetId == ProjetId);
        }

        public Mesure GetMesureByID(string MesureId)
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

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateMesure(Mesure Mesure)
        {
            _dbContext.Entry(Mesure).State = EntityState.Modified;
            Save();
        }
    }
}
