using GestionProjets.Models;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IReunionRepository
    {
        void DeleteReunion(string ReunionId);
        Reunion GetReunionByID(string ReunionId);
        IEnumerable<Reunion> GetReunions();
        void InsertReunion(Reunion Reunion);
        void Save();
        void UpdateReunion(Reunion Reunion);
    }
}