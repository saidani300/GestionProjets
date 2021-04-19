﻿using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.DBContext
{
    public class QualitasContext : DbContext
    {
        public QualitasContext(DbContextOptions<QualitasContext> options) : base(options)
        {
        }
        public DbSet<Projet> Projets { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<Models.Action> Actions { get; set; }
        public DbSet<Tache> Taches { get; set; }
        public DbSet<TypeProjet> TypesProjet { get; set; }
    }
}
