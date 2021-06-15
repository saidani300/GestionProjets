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
        void InsertActionPhase(Models.Action Action, Guid PhaseId);
        void InsertActionProjet(Models.Action Action, Guid ProjetId);
        void Save();
        void UpdateAction(Models.Action Action);
    }
}