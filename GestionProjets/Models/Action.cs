using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionProjets.Models
{
    public enum StatutA
    {
        Nouveau,
        En_cours,
        Terminé,
        vérifié
    }
    public class Action
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreation { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateModification { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DateD { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DateF { get; set; }

        public Guid? PreActionId { get; set; }
        public virtual Action PreAction { get; set; }

        public virtual ICollection<Tache> Taches { get; set; }


        public StatutA Statut { get; set; }

        //Foreign keys

        [ForeignKey("Projet")]

        public Guid? ProjetId { get; set; }
        public virtual Projet Projet { get; set; }

        [ForeignKey("Phase")]

        public Guid? PhaseId { get; set; }
        public virtual Phase Phase { get; set; }
    }

    public class ActionDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime DateD { get; set; }
        public DateTime DateF { get; set; }
        public Guid? PreActionId { get; set; }
        public StatutA Statut { get; set; }


        //Foreign keys

        public Guid? ProjetId { get; set; }
        public Guid? PhaseId { get; set; }
    }

}