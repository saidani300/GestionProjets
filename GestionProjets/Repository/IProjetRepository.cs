using GestionProjets.Models;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IProjetRepository
    {
        void DeleteProjet(string ProjetId);
        Projet GetProjetByID(string ProjetId);
        IEnumerable<Projet> GetProjets();
        void InsertProjet(Projet Projet);
        void Save();
        void UpdateProjet(Projet Projet);
    }
}