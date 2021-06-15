using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IRisqueRepository
    {
        void DeleteRisque(Guid RisqueId);
        Risque GetRisqueByID(Guid RisqueId);
        IEnumerable<Risque> GetRisques();
        IEnumerable<Risque> GetRisquesByProjet(Guid ProjetId);
        void InsertRisque(Risque Risque);
        void Save();
        void UpdateRisque(Risque Risque);
    }
}