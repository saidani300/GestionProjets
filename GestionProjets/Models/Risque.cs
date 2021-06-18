using System;
using System.Collections.Generic;
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
        [Required]
        public string Nom { get; set; }
        public string Description { get; set; }
        [Required]
        public NiveauRisque Niveau { get; set; }
        public string Source { get; set; }
        public TypeRisque Type { get; set; }
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

    public class RisqueDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public string Description { get; set; }
        [Required]
        public NiveauRisque Niveau { get; set; }
        public string Source { get; set; }
        public TypeRisque Type { get; set; }
        public string Cause { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public string Impact { get; set; }
     
        public Guid ProjetId { get; set; }

    }
}
