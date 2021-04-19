using GestionProjets.Models;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface ITypeProjetRepository
    {
        void DeleteTypeProjet(string TypeProjetId);
        TypeProjet GetTypeProjetByID(string TypeProjetId);
        IEnumerable<TypeProjet> GetTypeProjets();
        void InsertTypeProjet(TypeProjet TypeProjet);
        void Save();
        void UpdateTypeProjet(TypeProjet TypeProjet);
    }
}