using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionProjets.Models
{
    public class Indicateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public string Description { get; set; }
        [Required]
        public string Methode { get; set; }
        public string Unite { get; set; }

        public virtual ICollection<Mesure> Mesures { get; set; }


        //Foreign keys
        [ForeignKey("Objectif")]

        public Guid ObjectifId { get; set; }
        public virtual Objectif Objectif { get; set; }

    }

    public class IndicateurDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public string Description { get; set; }
        [Required]
        public string Methode { get; set; }
        public string Unite { get; set; }
        public Guid ObjectifId { get; set; }

    }
}
