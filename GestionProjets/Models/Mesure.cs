using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionProjets.Models
{
    public class Mesure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public long Valeur { get; set; }

        public Guid IdIndicateur { get; set; }
        [ForeignKey("IdIndicateur")]
        public Indicateur indicateur { get; set; }

        public Guid ObjectifId { get; set; }
        [ForeignKey("ObjectifId")]
        public Objectif objectif { get; set; }

        public Guid ProjetId { get; set; }
        [ForeignKey("ProjetId")]
        public Projet projet { get; set; }
    }
}
