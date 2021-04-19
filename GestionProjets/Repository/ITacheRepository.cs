using GestionProjets.Models;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface ITacheRepository
    {
        void DeleteTache(string TacheId);
        Tache GetTacheByID(string TacheId);
        IEnumerable<Tache> GetTaches();
        void InsertTache(Tache Tache);
        void Save();
        void UpdateTache(Tache Tache);
    }
}