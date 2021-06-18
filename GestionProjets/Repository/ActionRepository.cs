using GestionProjets.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class ActionRepository : IActionRepository
    {
        private readonly QalitasContext _dbContext;

        public ActionRepository(QalitasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Models.Action GetActionByID(Guid ActionId)
        {
            return _dbContext.Actions.Find(ActionId);
        }

        public IEnumerable<Models.Action> GetActionsByProject(Guid ProjetId)
        {
            return _dbContext.Projets.Where(A => A.Id == ProjetId).FirstOrDefault().Actions;
        }

        public IEnumerable<Models.Action> GetActionsByPhase(Guid PhaseId)
        {
            return _dbContext.Phases.Where(A => A.Id == PhaseId).FirstOrDefault().Actions;
        }

        public void InsertAction(Models.Action Action)
        {
            if (Action.ProjetId != null)
            {
                _dbContext.Projets.Where(A => A.Id == Action.ProjetId).FirstOrDefault().Actions.Add(Action);
                Save();
            }
            else if (Action.PhaseId != null)
            {
                _dbContext.Phases.Where(A => A.Id == Action.PhaseId).FirstOrDefault().Actions.Add(Action);
                Save();
            }
        }

        public void InsertActionPhase(Models.Action Action, Guid PhaseId)
        {
            _dbContext.Phases.Where(A => A.Id == PhaseId).FirstOrDefault().Actions.Add(Action);
            Save();
        }

        public void UpdateAction(Models.Action Action)
        {
            _dbContext.Entry(Action).State = EntityState.Modified;
            Save();
        }

        public void DeleteAction(Guid ActionId)
        {
            var Action = _dbContext.Actions.Find(ActionId);
            _dbContext.Actions.Remove(Action);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
