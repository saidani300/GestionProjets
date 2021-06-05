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
        public void DeleteAction(Guid ActionId)
        {
            var Action = _dbContext.Actions.Find(ActionId);
            _dbContext.Actions.Remove(Action);
            Save();
        }

        public Models.Action GetActionByID(Guid ActionId)
        {
            return _dbContext.Actions.Find(ActionId);
        }

        public IEnumerable<Models.Action> GetActionsByProject(Guid ProjetId)
        {
            return _dbContext.Actions.Where(A => A.ProjetId  == ProjetId);
        }

        public IEnumerable<Models.Action> GetActionsByPhase(Guid PhaseId)
        {
            return _dbContext.Actions.Where(A => A.PhaseId == PhaseId);
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
