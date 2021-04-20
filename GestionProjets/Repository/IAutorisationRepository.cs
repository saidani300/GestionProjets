using GestionProjets.Models;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IAutorisationRepository
    {
        void DeleteAutorisation(string AutorisationId);
        Autorisation GetAutorisationByID(string AutorisationId);
        IEnumerable<Autorisation> GetAutorisations();
        void InsertAutorisation(Autorisation Autorisation);
        void Save();
        void UpdateAutorisation(Autorisation Autorisation);
    }
}