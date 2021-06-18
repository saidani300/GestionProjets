using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IActionRepository
    {
        void DeleteAction(Guid ActionId);
        Models.Action GetActionByID(Guid ActionId);
        IEnumerable<Models.Action> GetActionsByPhase(Guid PhaseId);
        IEnumerable<Models.Action> GetActionsByProject(Guid ProjetId);
        void InsertAction(Models.Action Action);
        void InsertActionPhase(Models.Action Action, Guid PhaseId);
        void Save();
        void UpdateAction(Models.Action Action);
    }
}