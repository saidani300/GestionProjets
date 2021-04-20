using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Models
{
    public enum NiveauRisque
    {
        N1,
        N2,
        N3
    }
    public enum TypeRisque
    {
        Type1,
        Type2,
        Type3,
        Type4
        
    }

    public class Risque
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public NiveauRisque Niveau { get; set; }
        public string Source { get; set; }
        public TypeRisque Type { get; set; }
        public string Cause { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public string Impact { get; set; }
        public string IdUser { get; set; }
        public string IdProjet { get; set; }
    }
}
