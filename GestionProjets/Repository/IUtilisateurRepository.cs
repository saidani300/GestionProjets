using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IUtilisateurRepository
    {
        void DeleteUtilisateur(Guid UtilisateurId);
        Utilisateur GetUtilisateurByID(Guid UtilisateurId);
        IEnumerable<Utilisateur> GetUtilisateurs();
        void InsertUtilisateur(Utilisateur Utilisateur);
        void Save();
        void UpdateUtilisateur(Utilisateur Utilisateur);
    }
}