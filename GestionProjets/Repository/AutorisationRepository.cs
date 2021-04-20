﻿using GestionProjets.DBContext;
using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class AutorisationRepository : IAutorisationRepository
    {
        private readonly QualitasContext _dbContext;

        public AutorisationRepository(QualitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteAutorisation(string AutorisationId)
        {
            var Autorisation = _dbContext.Autorisations.Find(AutorisationId);
            _dbContext.Autorisations.Remove(Autorisation);
            Save();
        }

        public Autorisation GetAutorisationByID(string AutorisationId)
        {
            return _dbContext.Autorisations.Find(AutorisationId);
        }

        public IEnumerable<Autorisation> GetAutorisations()
        {
            return _dbContext.Autorisations.ToList();
        }

        public void InsertAutorisation(Autorisation Autorisation)
        {
            _dbContext.Add(Autorisation);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateAutorisation(Autorisation Autorisation)
        {
            _dbContext.Entry(Autorisation).State = EntityState.Modified;
            Save();
        }
    }
}
