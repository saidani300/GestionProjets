using GestionProjets.Models;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IObjectifRepository
    {
        void DeleteObjectif(string ObjectifId);
        Objectif GetObjectifByID(string ObjectifId);
        IEnumerable<Objectif> GetObjectifs();
        void InsertObjectif(Objectif Objectif);
        void Save();
        void UpdateObjectif(Objectif Objectif);
    }
}