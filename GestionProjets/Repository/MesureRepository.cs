using GestionProjets.DBContext;
using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GestionProjets.Repository
{
    public class MesureRepository : IMesureRepository
    {
        private readonly QalitasContext _dbContext;

        public MesureRepository(QalitasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Mesure> GetMesuresByIndicateur(Guid IndicateurId)
        {
            return _dbContext.Indicateurs.Where(A => A.Id == IndicateurId).FirstOrDefault().Mesures;
        }

        public Mesure GetMesureByID(Guid MesureId)
        {
            return _dbContext.Mesures.Find(MesureId);
        }

        public IEnumerable<Mesure> GetMesures()
        {
            return _dbContext.Mesures.ToList();
        }

        public void InsertMesure(Mesure Mesure)
        {
            if (Mesure != null)
            {
                Indicateur indicateur = _dbContext.Indicateurs.Where(A => A.Id == Mesure.IndicateurId).FirstOrDefault();
                //Calcul de valeur de mesure par l'indictateur.
                string expression = indicateur.Methode;
                string exp = expression.Replace("A", Mesure.Valeur1.ToString()).Replace("B", Mesure.Valeur2.ToString());
                DataTable dt = new DataTable();
                long v = (long)Convert.ToInt64(dt.Compute(exp, string.Empty));
                Mesure.Resultat = v;

                indicateur.Mesures.Add(Mesure);
                Save();
            }
        }



        public void UpdateMesure(Mesure Mesure)
        {
            _dbContext.Entry(Mesure).State = EntityState.Modified;
            Save();
        }

        public void DeleteMesure(Guid MesureId)
        {
            var Mesure = _dbContext.Mesures.Find(MesureId);
            _dbContext.Mesures.Remove(Mesure);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
