using GestionProjets.Models;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IOpportuniteRepository
    {
        void DeleteOpportunite(string OpportuniteId);
        Opportunite GetOpportuniteByID(string OpportuniteId);
        IEnumerable<Opportunite> GetOpportunites();
        void InsertOpportunite(Opportunite Opportunite);
        void Save();
        void UpdateOpportunite(Opportunite Opportunite);
    }
}