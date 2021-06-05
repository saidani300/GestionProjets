using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IParametreRepository
    {
        void DeleteParametre(Guid ParametreId);
        Parametre GetParametreByID(Guid ParametreId);
        IEnumerable<Parametre> GetParametres();
        void InsertParametre(Parametre Parametre);
        void Save();
        void UpdateParametre(Parametre Parametre);
    }
}