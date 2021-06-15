using GestionProjets.DBContext;
using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class AutorisationRepository : IAutorisationRepository
    {
        private readonly QalitasContext _dbContext;

        public AutorisationRepository(QalitasContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Autorisation GetAutorisationByID(Guid AutorisationId)
        {
            return _dbContext.Autorisations.Find(AutorisationId);
        }

        public IEnumerable<Autorisation> GetAutorisations()
        {
            return _dbContext.Autorisations.ToList();
        }

        public bool Autorisation(Guid id, string reference)
        {
            if (_dbContext.Autorisations.Count(A => A.UserId == id && A.Reference == reference) != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void InsertAutorisation(Autorisation Autorisation)
        {
            _dbContext.Add(Autorisation);
            Save();
        }



        public void UpdateAutorisation(Autorisation Autorisation)
        {
            _dbContext.Entry(Autorisation).State = EntityState.Modified;
            Save();
        }

        public void DeleteAutorisation(Guid AutorisationId)
        {
            var Autorisation = _dbContext.Autorisations.Find(AutorisationId);
            _dbContext.Autorisations.Remove(Autorisation);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
