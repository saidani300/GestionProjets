using GestionProjets.Models;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IParametreRepository
    {
        void DeleteParametre(string ParametreId);
        Parametre GetParametreByID(string ParametreId);
        IEnumerable<Parametre> GetParametres();
        void InsertParametre(Parametre Parametre);
        void Save();
        void UpdateParametre(Parametre Parametre);
    }
}