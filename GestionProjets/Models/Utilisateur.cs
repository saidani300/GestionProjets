using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Models
{
    public class Utilisateur
    {
        [Key]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public int NumCIN { get; set; }
        public string Email { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateModification { get; set; } = DateTime.Now;
        
    }
    public class UtilisateurDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }

    }

    public class Role
    {
        public string UserId { get; set; }
        public string Nom { get; set; }
    }
}
