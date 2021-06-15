using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IPhaseRepository
    {
        void DeletePhase(Guid PhaseId);
        Phase GetPhaseByID(Guid PhaseId);
        IEnumerable<Phase> GetPhases();
        IEnumerable<Phase> GetPhasesByProject(Guid ProjetId);
        void InsertPhase(Phase Phase);
        void Save();
        void UpdatePhase(Phase Phase);
    }
}