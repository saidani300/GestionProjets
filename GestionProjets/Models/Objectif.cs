using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Models
{
    public enum Priorite
    {
        p1,
        p2,
        p3
    }
    public enum EtatO
    {
        Nouveau,
        En_cours,
        Terminé,
        vérifié
    }
    public class Objectif
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public Priorite Priorite { get; set; }
        public EtatO Etat { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateModification { get; set; } = DateTime.Now;
        public string IdProjet { get; set; }
    }
}
