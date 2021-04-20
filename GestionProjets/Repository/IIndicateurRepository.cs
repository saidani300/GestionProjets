using GestionProjets.Models;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IIndicateurRepository
    {
        void DeleteIndicateur(string IndicateurId);
        Indicateur GetIndicateurByID(string IndicateurId);
        IEnumerable<Indicateur> GetIndicateurs();
        void InsertIndicateur(Indicateur Indicateur);
        void Save();
        void UpdateIndicateur(Indicateur Indicateur);
    }
}