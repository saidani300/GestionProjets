using GestionProjets.DBContext;
using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly QualitasContext _dbContext;

        public DocumentRepository(QualitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Document> GetDocumetsByProject(Guid ProjetId)
        {
            return _dbContext.Documents.Where(A => A.IdProjet == ProjetId);
        }
        public void DeleteDocument(string DocumentId)
        {
            var Document = _dbContext.Documents.Find(DocumentId);
            _dbContext.Documents.Remove(Document);
            Save();
        }

        public Document GetDocumentByID(string DocumentId)
        {
            return _dbContext.Documents.Find(DocumentId);
        }

        public IEnumerable<Document> GetDocuments()
        {
            return _dbContext.Documents.ToList();
        }

        public void InsertDocument(Document Document)
        {
            _dbContext.Add(Document);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateDocument(Document Document)
        {
            _dbContext.Entry(Document).State = EntityState.Modified;
            Save();
        }
    }
}
