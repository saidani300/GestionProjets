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
                .HasAnnotation("ProductVersion", "3.1.16")
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
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Note")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("OpportuniteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ParametreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RisqueId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OpportuniteId");

                    b.HasIndex("ParametreId");

                    b.HasIndex("RisqueId");

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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ObjectifId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Unite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ObjectifId");

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

                    b.Property<long>("Resultat")
                        .HasColumnType("bigint");

                    b.Property<long>("Valeur1")
                        .HasColumnType("bigint");

                    b.Property<long>("Valeur2")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IndicateurId");

                    b.ToTable("Mesures");
                });

            modelBuilder.Entity("GestionProjets.Models.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UtilisateurId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Notifications");
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

                    b.Property<Guid>("ProjetId")
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

                    b.Property<Guid>("ProjetId")
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
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjetId")
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

                    b.Property<Guid?>("ChefId")
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Statut")
                        .HasColumnType("int");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ChefId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

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

                    b.Property<Guid>("ProjetId")
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjetId")
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

                    b.Property<Guid>("ActionId")
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PredTacheId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Statut")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("PredTacheId");

                    b.HasIndex("UserId");

                    b.ToTable("Taches");
                });

            modelBuilder.Entity("GestionProjets.Models.TypeProjet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nom")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumCIN")
                        .HasColumnType("int");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ReunionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReunionId");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("GestionProjets.Models.Action", b =>
                {
                    b.HasOne("GestionProjets.Models.Phase", "Phase")
                        .WithMany("Actions")
                        .HasForeignKey("PhaseId");

                    b.HasOne("GestionProjets.Models.Action", "PreAction")
                        .WithMany()
                        .HasForeignKey("PreActionId");

                    b.HasOne("GestionProjets.Models.Projet", "Projet")
                        .WithMany("Actions")
                        .HasForeignKey("ProjetId");
                });

            modelBuilder.Entity("GestionProjets.Models.Autorisation", b =>
                {
                    b.HasOne("GestionProjets.Models.Utilisateur", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionProjets.Models.Document", b =>
                {
                    b.HasOne("GestionProjets.Models.Projet", "Projet")
                        .WithMany("Documents")
                        .HasForeignKey("ProjetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionProjets.Models.Evaluation", b =>
                {
                    b.HasOne("GestionProjets.Models.Opportunite", "Opportunite")
                        .WithMany("Evaluations")
                        .HasForeignKey("OpportuniteId");

                    b.HasOne("GestionProjets.Models.Parametre", "Parametre")
                        .WithMany()
                        .HasForeignKey("ParametreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionProjets.Models.Risque", "Risque")
                        .WithMany("Evaluations")
                        .HasForeignKey("RisqueId");
                });

            modelBuilder.Entity("GestionProjets.Models.Indicateur", b =>
                {
                    b.HasOne("GestionProjets.Models.Objectif", "Objectif")
                        .WithMany("Indicateurs")
                        .HasForeignKey("ObjectifId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionProjets.Models.Mesure", b =>
                {
                    b.HasOne("GestionProjets.Models.Indicateur", "Indicateur")
                        .WithMany("Mesures")
                        .HasForeignKey("IndicateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionProjets.Models.Notification", b =>
                {
                    b.HasOne("GestionProjets.Models.Utilisateur", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UtilisateurId");
                });

            modelBuilder.Entity("GestionProjets.Models.Objectif", b =>
                {
                    b.HasOne("GestionProjets.Models.Projet", "Projet")
                        .WithMany("Objectifs")
                        .HasForeignKey("ProjetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionProjets.Models.Opportunite", b =>
                {
                    b.HasOne("GestionProjets.Models.Projet", "Projet")
                        .WithMany("Opportunites")
                        .HasForeignKey("ProjetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionProjets.Models.Phase", b =>
                {
                    b.HasOne("GestionProjets.Models.Projet", "Projet")
                        .WithMany("Phases")
                        .HasForeignKey("ProjetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionProjets.Models.Projet", b =>
                {
                    b.HasOne("GestionProjets.Models.Utilisateur", "ChefdeProjet")
                        .WithMany()
                        .HasForeignKey("ChefId");

                    b.HasOne("GestionProjets.Models.TypeProjet", "TypeProjet")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionProjets.Models.Utilisateur", "Responsable")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionProjets.Models.Reunion", b =>
                {
                    b.HasOne("GestionProjets.Models.Projet", "Projet")
                        .WithMany("Reunions")
                        .HasForeignKey("ProjetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionProjets.Models.Risque", b =>
                {
                    b.HasOne("GestionProjets.Models.Projet", "Projet")
                        .WithMany("Risques")
                        .HasForeignKey("ProjetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionProjets.Models.Tache", b =>
                {
                    b.HasOne("GestionProjets.Models.Action", "Action")
                        .WithMany("Taches")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionProjets.Models.Tache", "PreTache")
                        .WithMany()
                        .HasForeignKey("PredTacheId");

                    b.HasOne("GestionProjets.Models.Utilisateur", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
