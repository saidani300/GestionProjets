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
        private readonly QalitasContext _dbContext;

        public DocumentRepository(QalitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Document> GetDocumetsByProject(Guid ProjetId)
        {
            return _dbContext.Projets.Where(A => A.Id == ProjetId).FirstOrDefault().Documents;
        }

        public Document GetDocumentByID(Guid DocumentId)
        {
            return _dbContext.Documents.Find(DocumentId);
        }

        public IEnumerable<Document> GetDocuments()
        {
            return _dbContext.Documents.ToList();
        }

        public void InsertDocument(Document Document)
        {
            if (Document != null)
            {
                Projet p = _dbContext.Projets.Where(A => A.Id == Document.Id).FirstOrDefault();
                p.Documents.Add(Document);
                Save();
            }
        }


        public void UpdateDocument(Document Document)
        {
            _dbContext.Entry(Document).State = EntityState.Modified;
            Save();
        }

        public void DeleteDocument(Guid DocumentId)
        {
            var Document = _dbContext.Documents.Find(DocumentId);
            _dbContext.Documents.Remove(Document);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
