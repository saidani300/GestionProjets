using GestionProjets.DBContext;
using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class TypeProjetRepository : ITypeProjetRepository
    {
        private readonly QualitasContext _dbContext;

        public TypeProjetRepository(QualitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteTypeProjet(int TypeProjetId)
        {
            var TypeProjet = _dbContext.TypesProjet.Find(TypeProjetId);
            _dbContext.TypesProjet.Remove(TypeProjet);
            Save();
        }

        public TypeProjet GetTypeProjetByID(int TypeProjetId)
        {
            return _dbContext.TypesProjet.Find(TypeProjetId);
        }

        public IEnumerable<TypeProjet> GetTypeProjets()
        {
            return _dbContext.TypesProjet.ToList();
        }

        public void InsertTypeProjet(TypeProjet TypeProjet)
        {
            _dbContext.Add(TypeProjet);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateTypeProjet(TypeProjet TypeProjet)
        {
            _dbContext.Entry(TypeProjet).State = EntityState.Modified;
            Save();
        }
    }
}
