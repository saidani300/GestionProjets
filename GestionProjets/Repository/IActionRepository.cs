using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IActionRepository
    {
        Models.Action GetActionByID(Guid ActionId);
        IEnumerable<Models.Action> GetActionsByProject(Guid ProjetId);
        IEnumerable<Models.Action> GetActionsByPhase(Guid PhaseId);
        void InsertAction(Models.Action Action);
        void Save();
        void UpdateAction(Models.Action Action);
        void DeleteAction(Guid ActionId);

    }
}