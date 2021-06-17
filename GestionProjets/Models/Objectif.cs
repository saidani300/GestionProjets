using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionProjets.Models
{
    public enum Priorite
    {
        p1,
        p2,
        p3
    }
    public enum EtatO
    {
        Nouveau,
        En_cours,
        Terminé,
        vérifié
    }
    public class Objectif
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Nom { get; set; }
        public string Description { get; set; }
        public Priorite Priorite { get; set; }
        public EtatO Etat { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreation { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateModification { get; set; } = DateTime.Now;

        //Foreign keys
        [ForeignKey("Projet")]

        public Guid ProjetId { get; set; }
        public virtual Projet Projet { get; set; }
    }

    public class ObjectifDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Nom { get; set; }
        public string Description { get; set; }
        public Priorite Priorite { get; set; }
        public EtatO Etat { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreation { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateModification { get; set; } = DateTime.Now;
        public Guid ProjetId { get; set; }
    }
}
