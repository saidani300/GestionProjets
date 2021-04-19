using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IActionRepository
    {
        void DeleteAction(string ActionId);
        Models.Action GetActionByID(string ActionId);
        IEnumerable<Models.Action> GetActions();
        void InsertAction(Models.Action Action);
        void Save();
        void UpdateAction(Models.Action Action);
    }
}