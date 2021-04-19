﻿using GestionProjets.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class ActionRepository : IActionRepository
    {
        private readonly QualitasContext _dbContext;

        public ActionRepository(QualitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteAction(string ActionId)
        {
            var Action = _dbContext.Actions.Find(ActionId);
            _dbContext.Actions.Remove(Action);
            Save();
        }

        public Models.Action GetActionByID(string ActionId)
        {
            return _dbContext.Actions.Find(ActionId);
        }

        public IEnumerable<Models.Action> GetActions()
        {
            return _dbContext.Actions.ToList();
        }

        public void InsertAction(Models.Action Action)
        {
            _dbContext.Add(Action);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateAction(Models.Action Action)
        {
            _dbContext.Entry(Action).State = EntityState.Modified;
            Save();
        }
    }
}