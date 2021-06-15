using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IAutorisationRepository
    {
        bool Autorisation(Guid id, string reference);
        void DeleteAutorisation(Guid AutorisationId);
        Autorisation GetAutorisationByID(Guid AutorisationId);
        IEnumerable<Autorisation> GetAutorisations();
        void InsertAutorisation(Autorisation Autorisation);
        void Save();
        void UpdateAutorisation(Autorisation Autorisation);
    }
}