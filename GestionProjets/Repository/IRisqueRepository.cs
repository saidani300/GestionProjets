using GestionProjets.Models;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IRisqueRepository
    {
        void DeleteRisque(string RisqueId);
        Risque GetRisqueByID(string RisqueId);
        IEnumerable<Risque> GetRisques();
        void InsertRisque(Risque Risque);
        void Save();
        void UpdateRisque(Risque Risque);
    }
}