using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionProjets.Models
{
    public class Indicateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Methode { get; set; }
        public long Val1 { get; set; }
        public long Val2 { get; set; }
        public string Unite { get; set; }

        public Guid ProjetId { get; set; }
        [ForeignKey("ProjetId")]
        public Projet projet { get; set; }

    }
}
