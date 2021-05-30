using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IPhaseRepository
    {
        IEnumerable<Phase> GetPhasesByProject(Guid ProjetId);
        void DeletePhase(Guid PhaseId);
        Phase GetPhaseByID(Guid PhaseId);
        IEnumerable<Phase> GetPhases();
        void InsertPhase(Phase Phase);
        void Save();
        void UpdatePhase(Phase Phase);
    }
}