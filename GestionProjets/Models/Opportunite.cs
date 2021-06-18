using System;
using System.Collections.Generic;
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public string Impact { get; set; }

        public virtual ICollection<Evaluation> Evaluations { get; set; }

        //Foreign keys
        [ForeignKey("Projet")]

        public Guid ProjetId { get; set; }
        public virtual Projet Projet { get; set; }

    }

    public class OpportuniteDTO
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public string Impact { get; set; }
        public Guid ProjetId { get; set; }

    }
}
