using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionProjets.Models
{
    public enum NiveauOpportunite
    {
        N1,
        N2,
        N3
    }
    public enum TypeOpportunite
    {
        Type1,
        Type2,
        Type3,
        Type4

    }

    public enum CategorieOpportunite
    {
        Categorie1,
        Categorie2,
        Categorie3
    }
    public class Opportunite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public NiveauOpportunite Niveau { get; set; }
        public string Source { get; set; }
        public TypeOpportunite Type { get; set; }
        public CategorieOpportunite Categorie { get; set; }
        public string Cause { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public string Impact { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdProjet { get; set; }
    }
}
