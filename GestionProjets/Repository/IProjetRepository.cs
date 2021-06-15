using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IProjetRepository
    {
        void DeleteProjet(Guid ProjetId);
        Projet GetProjetByID(Guid ProjetId);
        IEnumerable<Projet> GetProjetsByUtilisateur(Guid UserId);
        IEnumerable<Projet> GetProjets(Guid Userid);
        void InsertProjet(Projet Projet);
        void Save();
        void UpdateProjet(Projet Projet);
    }
}