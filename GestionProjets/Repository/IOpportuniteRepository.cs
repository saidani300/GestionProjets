using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IOpportuniteRepository
    {
        IEnumerable<Opportunite> GetOpportunitesByProject(Guid ProjetId);
        void DeleteOpportunite(Guid OpportuniteId);
        Opportunite GetOpportuniteByID(Guid OpportuniteId);
        IEnumerable<Opportunite> GetOpportunites();
        void InsertOpportunite(Opportunite Opportunite);
        void Save();
        void UpdateOpportunite(Opportunite Opportunite);
    }
}