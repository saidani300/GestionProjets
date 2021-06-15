using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionProjets.Models
{
    public enum StatutT
    {
        Nouveau,
        En_cours,
        Terminé,
        vérifié
    }
    public class Tache
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public Utilisateur Utilisateur { get; set; }

        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateModification { get; set; } = DateTime.Now;
        public DateTime DateD { get; set; }
        public DateTime DateF { get; set; }

        public Guid PredTacheId { get; set; }
        public Tache PreTache { get; set; }

        public StatutT Statut { get; set; }
    }

    public class TacheDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime DateD { get; set; }
        public DateTime DateF { get; set; }
        public Guid PredTacheId { get; set; }
        public StatutT Statut { get; set; }
    }

    }