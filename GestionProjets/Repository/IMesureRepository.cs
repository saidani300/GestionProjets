using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IMesureRepository
    {
        void DeleteMesure(Guid MesureId);
        Mesure GetMesureByID(Guid MesureId);
        IEnumerable<Mesure> GetMesures();
        IEnumerable<Mesure> GetMesuresByIndicateur(Guid IndicateurId);
        void InsertMesure(Mesure Mesure);
        void Save();
        void UpdateMesure(Mesure Mesure);
    }
}