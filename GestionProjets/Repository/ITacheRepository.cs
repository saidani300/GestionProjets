using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface ITacheRepository
    {
        void DeleteTache(Guid TacheId);
        Tache GetTacheByID(Guid TacheId);
        IEnumerable<Tache> GetTaches();
        IEnumerable<Tache> GetTachesByAction(Guid ActionId);
        void InsertTache(Tache Tache);
        void Save();
        void UpdateTache(Tache Tache);
    }
}