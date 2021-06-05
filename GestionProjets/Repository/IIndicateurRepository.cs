using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IIndicateurRepository
    {
        void DeleteIndicateur(Guid IndicateurId);
        Indicateur GetIndicateurByID(Guid IndicateurId);
        IEnumerable<Indicateur> GetIndicateurs();
        void InsertIndicateur(Indicateur Indicateur);
        void Save();
        void UpdateIndicateur(Indicateur Indicateur);
    }
}