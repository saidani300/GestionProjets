using System;
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

        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public Utilisateur utilisateur { get; set; }

        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateModification { get; set; } = DateTime.Now;
        public DateTime DateD { get; set; }
        public DateTime DateF { get; set; }

        public Guid? PredAction { get; set; }
        [ForeignKey("PredAction")]
        public Action action { get; set; }

        public Guid PhaseId { get; set; }
        [ForeignKey("PhaseId")]
        public Phase phase { get; set; }

        public Guid ProjetId { get; set; }
        [ForeignKey("ProjetId")]
        public Projet projet { get; set; }


        public StatutA Statut { get; set; }
    }
}