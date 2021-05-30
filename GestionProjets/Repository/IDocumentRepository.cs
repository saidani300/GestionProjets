using GestionProjets.Models;
using System;
using System.Collections.Generic;

namespace GestionProjets.Repository
{
    public interface IDocumentRepository
    {
        void DeleteDocument(string DocumentId);
        Document GetDocumentByID(string DocumentId);
        IEnumerable<Document> GetDocuments();
        IEnumerable<Document> GetDocumetsByProject(Guid ProjetId);
        void InsertDocument(Document Document);
        void Save();
        void UpdateDocument(Document Document);
    }
}