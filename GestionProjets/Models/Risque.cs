using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GestionProjets.Models
{
    public enum NiveauRisque
    {
        N1,
        N2,
        N3
    }
    public enum TypeRisque
    {
        Type1,
        Type2,
        Type3,
        Type4
        
    }

    public class Risque
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public NiveauRisque Niveau { get; set; }
        public string Source { get; set; }
        public TypeRisque Type { get; set; }
        public string Cause { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public string Impact { get; set; }

        public Guid IdUser { get; set; }
        [ForeignKey("IdUser")]
        public Utilisateur utilisateur { get; set; }

        public Guid ProjetId { get; set; }
        [ForeignKey("ProjetId")]
        public Projet projet { get; set; }
    }
}
