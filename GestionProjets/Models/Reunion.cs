﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionProjets.Models
{
    public enum EtatReunion
    {
        Nouveau,
        En_cours,
        Terminé,
    }
    public class Reunion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public EtatReunion Etat { get; set; }

        public ICollection<Utilisateur> Utilisateurs { get; set; }

    }

    public class ReunionDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public EtatReunion Etat { get; set; }

    }

}
