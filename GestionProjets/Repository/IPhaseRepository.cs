using GestionProjets.Models;
using System.Collections.Generic;

namespace GestionPhases.Repository
{
    public interface IPhaseRepository
    {
        void DeletePhase(string PhaseId);
        Phase GetPhaseByID(string PhaseId);
        IEnumerable<Phase> GetPhases();
        void InsertPhase(Phase Phase);
        void Save();
        void UpdatePhase(Phase Phase);
    }
}