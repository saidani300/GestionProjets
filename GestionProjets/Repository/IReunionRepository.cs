using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IReunionRepository
    {
        void DeleteReunion(Guid ReunionId);
        Reunion GetReunionByID(Guid ReunionId);
        IEnumerable<Reunion> GetReunions();
        IEnumerable<Reunion> GetReunionsByProjet(Guid ProjetId);
        void InsertReunion(Reunion Reunion);
        void Save();
        void UpdateReunion(Reunion Reunion);
    }
}