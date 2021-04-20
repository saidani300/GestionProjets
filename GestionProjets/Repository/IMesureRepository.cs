using GestionProjets.Models;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IMesureRepository
    {
        void DeleteMesure(string MesureId);
        Mesure GetMesureByID(string MesureId);
        IEnumerable<Mesure> GetMesures();
        void InsertMesure(Mesure Mesure);
        void Save();
        void UpdateMesure(Mesure Mesure);
    }
}