﻿// <auto-generated />
using System;
using GestionProjets.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestionProjets.Migrations
{
    [DbContext(typeof(QualitasContext))]
    partial class QualitasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GestionProjets.Models.Action", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateF")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhaseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PredAction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjetId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReunionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Statut")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PhaseId");

                    b.HasIndex("ProjetId");

                    b.HasIndex("ReunionId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("GestionProjets.Models.Autorisation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Etat")
                        .HasColumnType("bit");

                    b.Property<string>("IdUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Autorisations");
                });

            modelBuilder.Entity("GestionProjets.Models.Evaluation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Note")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("GestionProjets.Models.Indicateur", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Methode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Val1")
                        .HasColumnType("bigint");

                    b.Property<long>("Val2")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Indicateurs");
                });

            modelBuilder.Entity("GestionProjets.Models.Mesure", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdIndicateur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Valeur")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Mesures");
                });

            modelBuilder.Entity("GestionProjets.Models.Objectif", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Etat")
                        .HasColumnType("int");

                    b.Property<string>("IdProjet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priorite")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Objectifs");
                });

            modelBuilder.Entity("GestionProjets.Models.Opportunite", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Categorie")
                        .HasColumnType("int");

                    b.Property<string>("Cause")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdProjet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Impact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Niveau")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Opportunites");
                });

            modelBuilder.Entity("GestionProjets.Models.Parametre", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Valeur")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Parametres");
                });

            modelBuilder.Entity("GestionProjets.Models.Phase", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjetId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProjetId");

                    b.ToTable("Phases");
                });

            modelBuilder.Entity("GestionProjets.Models.Projet", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateF")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Statut")
                        .HasColumnType("int");

                    b.Property<string>("TypeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Projets");
                });

            modelBuilder.Entity("GestionProjets.Models.Reunion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Etat")
                        .HasColumnType("int");

                    b.Property<string>("IdProjet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reunions");
                });

            modelBuilder.Entity("GestionProjets.Models.Risque", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cause")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdProjet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Impact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Niveau")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Risques");
                });

            modelBuilder.Entity("GestionProjets.Models.Tache", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateF")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PredTache")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Statut")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.ToTable("Taches");
                });

            modelBuilder.Entity("GestionProjets.Models.TypeProjet", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypesProjet");
                });

            modelBuilder.Entity("GestionProjets.Models.Action", b =>
                {
                    b.HasOne("GestionProjets.Models.Phase", null)
                        .WithMany("Actions")
                        .HasForeignKey("PhaseId");

                    b.HasOne("GestionProjets.Models.Projet", null)
                        .WithMany("Actions")
                        .HasForeignKey("ProjetId");

                    b.HasOne("GestionProjets.Models.Reunion", null)
                        .WithMany("Actions")
                        .HasForeignKey("ReunionId");
                });

            modelBuilder.Entity("GestionProjets.Models.Phase", b =>
                {
                    b.HasOne("GestionProjets.Models.Projet", null)
                        .WithMany("Phases")
                        .HasForeignKey("ProjetId");
                });

            modelBuilder.Entity("GestionProjets.Models.Projet", b =>
                {
                    b.HasOne("GestionProjets.Models.TypeProjet", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("GestionProjets.Models.Tache", b =>
                {
                    b.HasOne("GestionProjets.Models.Action", null)
                        .WithMany("Taches")
                        .HasForeignKey("ActionId");
                });
#pragma warning restore 612, 618
        }
    }
}
