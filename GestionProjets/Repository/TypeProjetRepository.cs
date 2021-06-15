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
        private readonly QalitasContext _dbContext;

        public TypeProjetRepository(QalitasContext dbContext)
        {
            _dbContext = dbContext;
        }


        public TypeProjet GetTypeProjetByID(Guid TypeProjetId)
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



        public void UpdateTypeProjet(TypeProjet TypeProjet)
        {
            _dbContext.Entry(TypeProjet).State = EntityState.Modified;
            Save();
        }

        public void DeleteTypeProjet(Guid TypeProjetId)
        {
            var TypeProjet = _dbContext.TypesProjet.Find(TypeProjetId);
            _dbContext.TypesProjet.Remove(TypeProjet);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
