using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionProjets.Models
{
    public enum StatutP
    {
        Nouveau,
        En_cours,
        Terminé,
        vérifié
    }   
    public class Projet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public string Description { get; set; }
        [Required]
        

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreation { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateModification { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateD { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateF { get; set; }
        

        public virtual ICollection<Objectif> Objectifs { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Reunion> Reunions { get; set; }

        public virtual ICollection<Phase> Phases { get; set; }
        public virtual ICollection<Action> Actions { get; set; }

        public virtual ICollection<Opportunite> Opportunites { get; set; }
        public virtual ICollection<Risque> Risques { get; set; }

        public virtual ICollection<Mesure> Mesures { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }

        [Required]
        public StatutP Statut { get; set; }

        //FKs
        [ForeignKey("TypeProjet")]

        public Guid TypeId { get; set; }
        public virtual TypeProjet TypeProjet { get; set; }

        [Required]
        [ForeignKey("Responsable")]

        public Guid UserId { get; set; }
        public virtual Utilisateur Responsable { get; set; }

        [ForeignKey("ChefdeProjet")]

        public Guid? ChefId { get; set; }
        public virtual Utilisateur ChefdeProjet { get; set; }
    }

    public class ProjetDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Nom { get; set; }
        public string Description { get; set; }
        public Guid TypeId { get; set; }

        public DateTime DateD { get; set; }
        public DateTime DateF { get; set; }

        public Guid UserId { get; set; }
        public Guid? ChefId { get; set; }

        public StatutP Statut { get; set; }

    }
}