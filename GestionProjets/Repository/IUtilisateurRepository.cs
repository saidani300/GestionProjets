using GestionProjets.Models;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IUtilisateurRepository
    {
        void DeleteUtilisateur(string UtilisateurId);
        Utilisateur GetUtilisateurByID(string UtilisateurId);
        IEnumerable<Utilisateur> GetUtilisateurs();
        void InsertUtilisateur(Utilisateur Utilisateur);
        void Save();
        void UpdateUtilisateur(Utilisateur Utilisateur);
    }
}