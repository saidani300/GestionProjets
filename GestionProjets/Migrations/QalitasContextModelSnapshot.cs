﻿// <auto-generated />
using System;
using GestionProjets.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestionProjets.Migrations
{
    [DbContext(typeof(QalitasContext))]
    partial class QalitasContextModelSnapshot : ModelSnapshot
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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid?>("PhaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PreActionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProjetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Statut")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhaseId");

                    b.HasIndex("PreActionId");

                    b.HasIndex("ProjetId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("GestionProjets.Models.Autorisation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UtilisateurId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Autorisations");
                });

            modelBuilder.Entity("GestionProjets.Models.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProjetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjetId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("GestionProjets.Models.Evaluation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Note")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ParametreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProjetId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParametreId");

                    b.HasIndex("ProjetId");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("GestionProjets.Models.Indicateur", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IndicateurId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProjetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Valeur")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IndicateurId");

                    b.HasIndex("ProjetId");

                    b.ToTable("Mesures");
                });

            modelBuilder.Entity("GestionProjets.Models.Objectif", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Etat")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priorite")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProjetId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProjetId");

                    b.ToTable("Objectifs");
                });

            modelBuilder.Entity("GestionProjets.Models.Opportunite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Categorie")
                        .HasColumnType("int");

                    b.Property<string>("Cause")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Impact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Niveau")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProjetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetId");

                    b.ToTable("Opportunites");
                });

            modelBuilder.Entity("GestionProjets.Models.Parametre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Valeur")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Parametres");
                });

            modelBuilder.Entity("GestionProjets.Models.Phase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProjetId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProjetId");

                    b.ToTable("Phases");
                });

            modelBuilder.Entity("GestionProjets.Models.Projet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChefId")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TypeProjetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Utilisateur1Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Utilisateur2Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TypeProjetId");

                    b.HasIndex("Utilisateur1Id");

                    b.HasIndex("Utilisateur2Id");

                    b.ToTable("Projets");
                });

            modelBuilder.Entity("GestionProjets.Models.Reunion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Etat")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProjetId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProjetId");

                    b.ToTable("Reunions");
                });

            modelBuilder.Entity("GestionProjets.Models.Risque", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cause")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Impact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Niveau")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProjetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetId");

                    b.ToTable("Risques");
                });

            modelBuilder.Entity("GestionProjets.Models.Tache", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ActionId")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid?>("PreTacheId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PredTacheId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Statut")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UtilisateurId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("PreTacheId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Taches");
                });

            modelBuilder.Entity("GestionProjets.Models.TypeProjet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypesProjet");
                });

            modelBuilder.Entity("GestionProjets.Models.Utilisateur", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumCIN")
                        .HasColumnType("int");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ReunionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReunionId");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("GestionProjets.Models.Action", b =>
                {
                    b.HasOne("GestionProjets.Models.Phase", null)
                        .WithMany("Actions")
                        .HasForeignKey("PhaseId");

                    b.HasOne("GestionProjets.Models.Action", "PreAction")
                        .WithMany()
                        .HasForeignKey("PreActionId");

                    b.HasOne("GestionProjets.Models.Projet", null)
                        .WithMany("Actions")
                        .HasForeignKey("ProjetId");
                });

            modelBuilder.Entity("GestionProjets.Models.Autorisation", b =>
                {
                    b.HasOne("GestionProjets.Models.Utilisateur", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UtilisateurId");
                });

            modelBuilder.Entity("GestionProjets.Models.Document", b =>
                {
                    b.HasOne("GestionProjets.Models.Projet", null)
                        .WithMany("Documents")
                        .HasForeignKey("ProjetId");
                });

            modelBuilder.Entity("GestionProjets.Models.Evaluation", b =>
                {
                    b.HasOne("GestionProjets.Models.Parametre", "Parametre")
                        .WithMany()
                        .HasForeignKey("ParametreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionProjets.Models.Projet", null)
                        .WithMany("Evaluations")
                        .HasForeignKey("ProjetId");
                });

            modelBuilder.Entity("GestionProjets.Models.Mesure", b =>
                {
                    b.HasOne("GestionProjets.Models.Indicateur", "Indicateur")
                        .WithMany()
                        .HasForeignKey("IndicateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionProjets.Models.Projet", null)
                        .WithMany("Mesures")
                        .HasForeignKey("ProjetId");
                });

            modelBuilder.Entity("GestionProjets.Models.Objectif", b =>
                {
                    b.HasOne("GestionProjets.Models.Projet", null)
                        .WithMany("Objectifs")
                        .HasForeignKey("ProjetId");
                });

            modelBuilder.Entity("GestionProjets.Models.Opportunite", b =>
                {
                    b.HasOne("GestionProjets.Models.Projet", null)
                        .WithMany("Opportunites")
                        .HasForeignKey("ProjetId");
                });

            modelBuilder.Entity("GestionProjets.Models.Phase", b =>
                {
                    b.HasOne("GestionProjets.Models.Projet", null)
                        .WithMany("Phases")
                        .HasForeignKey("ProjetId");
                });

            modelBuilder.Entity("GestionProjets.Models.Projet", b =>
                {
                    b.HasOne("GestionProjets.Models.TypeProjet", "TypeProjet")
                        .WithMany()
                        .HasForeignKey("TypeProjetId");

                    b.HasOne("GestionProjets.Models.Utilisateur", "Utilisateur1")
                        .WithMany()
                        .HasForeignKey("Utilisateur1Id");

                    b.HasOne("GestionProjets.Models.Utilisateur", "Utilisateur2")
                        .WithMany()
                        .HasForeignKey("Utilisateur2Id");
                });

            modelBuilder.Entity("GestionProjets.Models.Reunion", b =>
                {
                    b.HasOne("GestionProjets.Models.Projet", null)
                        .WithMany("Reunions")
                        .HasForeignKey("ProjetId");
                });

            modelBuilder.Entity("GestionProjets.Models.Risque", b =>
                {
                    b.HasOne("GestionProjets.Models.Projet", null)
                        .WithMany("Risques")
                        .HasForeignKey("ProjetId");
                });

            modelBuilder.Entity("GestionProjets.Models.Tache", b =>
                {
                    b.HasOne("GestionProjets.Models.Action", null)
                        .WithMany("Taches")
                        .HasForeignKey("ActionId");

                    b.HasOne("GestionProjets.Models.Tache", "PreTache")
                        .WithMany()
                        .HasForeignKey("PreTacheId");

                    b.HasOne("GestionProjets.Models.Utilisateur", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UtilisateurId");
                });

            modelBuilder.Entity("GestionProjets.Models.Utilisateur", b =>
                {
                    b.HasOne("GestionProjets.Models.Reunion", null)
                        .WithMany("Utilisateurs")
                        .HasForeignKey("ReunionId");
                });
#pragma warning restore 612, 618
        }
    }
}