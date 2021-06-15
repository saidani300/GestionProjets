using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IObjectifRepository
    {
        void DeleteObjectif(Guid ObjectifId);
        Objectif GetObjectifByID(Guid ObjectifId);
        IEnumerable<Objectif> GetObjectifs();
        IEnumerable<Objectif> GetobjectifsByProject(Guid ProjetId);
        void InsertObjectif(Objectif Objectif);
        void Save();
        void UpdateObjectif(Objectif Objectif);
    }
}