using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionProjets.Models
{
    public class Autorisation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Reference { get; set; }

        public Guid UserId { get; set; }
        public Utilisateur Utilisateur { get; set; }

       // public bool Etat { get; set; } = false;
    }
}
