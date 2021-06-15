using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IOpportuniteRepository
    {
        void DeleteOpportunite(Guid OpportuniteId);
        Opportunite GetOpportuniteByID(Guid OpportuniteId);
        IEnumerable<Opportunite> GetOpportunites();
        IEnumerable<Opportunite> GetOpportunitesByProject(Guid ProjetId);
        void InsertOpportunite(Opportunite Opportunite);
        void Save();
        void UpdateOpportunite(Opportunite Opportunite);
    }
}