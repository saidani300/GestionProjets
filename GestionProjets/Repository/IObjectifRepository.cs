using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IObjectifRepository
    {
        IEnumerable<Objectif> GetobjectifsByProject(Guid ProjetId);
        void DeleteObjectif(string ObjectifId);
        Objectif GetObjectifByID(string ObjectifId);
        IEnumerable<Objectif> GetObjectifs();
        void InsertObjectif(Objectif Objectif);
        void Save();
        void UpdateObjectif(Objectif Objectif);
    }
}