using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface ITypeProjetRepository
    {
        void DeleteTypeProjet(Guid TypeProjetId);
        TypeProjet GetTypeProjetByID(Guid TypeProjetId);
        IEnumerable<TypeProjet> GetTypeProjets();
        void InsertTypeProjet(TypeProjet TypeProjet);
        void Save();
        void UpdateTypeProjet(TypeProjet TypeProjet);
    }
}