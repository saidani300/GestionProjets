using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionProjets.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parametres",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Valeur = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesProjet",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesProjet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taches",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    DateModification = table.Column<DateTime>(nullable: false),
                    DateD = table.Column<DateTime>(nullable: false),
                    DateF = table.Column<DateTime>(nullable: false),
                    Statut = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    PredTacheId = table.Column<Guid>(nullable: true),
                    ActionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taches_Taches_PredTacheId",
                        column: x => x.PredTacheId,
                        principalTable: "Taches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mesures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    DateDebut = table.Column<DateTime>(nullable: false),
                    DateFin = table.Column<DateTime>(nullable: false),
                    Valeur1 = table.Column<long>(nullable: false),
                    Valeur2 = table.Column<long>(nullable: false),
                    Resultat = table.Column<long>(nullable: false),
                    IndicateurId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Indicateurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Methode = table.Column<string>(nullable: false),
                    Unite = table.Column<string>(nullable: true),
                    ObjectifId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Note = table.Column<long>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    DateModification = table.Column<DateTime>(nullable: false),
                    ParametreId = table.Column<Guid>(nullable: false),
                    OpportuniteId = table.Column<Guid>(nullable: true),
                    RisqueId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluations_Parametres_ParametreId",
                        column: x => x.ParametreId,
                        principalTable: "Parametres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    DateModification = table.Column<DateTime>(nullable: false),
                    DateD = table.Column<DateTime>(nullable: false),
                    DateF = table.Column<DateTime>(nullable: false),
                    PreActionId = table.Column<Guid>(nullable: true),
                    Statut = table.Column<int>(nullable: false),
                    ProjetId = table.Column<Guid>(nullable: true),
                    PhaseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_Actions_PreActionId",
                        column: x => x.PreActionId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    ProjetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Objectifs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Priorite = table.Column<int>(nullable: false),
                    Etat = table.Column<int>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    DateModification = table.Column<DateTime>(nullable: false),
                    ProjetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectifs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Opportunites",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Niveau = table.Column<int>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Categorie = table.Column<int>(nullable: false),
                    Cause = table.Column<string>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    Impact = table.Column<string>(nullable: true),
                    ProjetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phases",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    DateModification = table.Column<DateTime>(nullable: false),
                    ProjetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reunions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    Etat = table.Column<int>(nullable: false),
                    ProjetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reunions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Prenom = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    NumCIN = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    DateModification = table.Column<DateTime>(nullable: false),
                    ReunionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Reunions_ReunionId",
                        column: x => x.ReunionId,
                        principalTable: "Reunions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Autorisations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Reference = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autorisations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autorisations_Utilisateurs_UserId",
                        column: x => x.UserId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    SourceId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    UtilisateurId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    DateModification = table.Column<DateTime>(nullable: false),
                    DateD = table.Column<DateTime>(nullable: false),
                    DateF = table.Column<DateTime>(nullable: false),
                    Statut = table.Column<int>(nullable: false),
                    TypeId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ChefId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projets_Utilisateurs_ChefId",
                        column: x => x.ChefId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projets_TypesProjet_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TypesProjet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projets_Utilisateurs_UserId",
                        column: x => x.UserId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Risques",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Niveau = table.Column<int>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Cause = table.Column<string>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    Impact = table.Column<string>(nullable: true),
                    ProjetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Risques_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_PhaseId",
                table: "Actions",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_PreActionId",
                table: "Actions",
                column: "PreActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_ProjetId",
                table: "Actions",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_Autorisations_UserId",
                table: "Autorisations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ProjetId",
                table: "Documents",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_OpportuniteId",
                table: "Evaluations",
                column: "OpportuniteId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_ParametreId",
                table: "Evaluations",
                column: "ParametreId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_RisqueId",
                table: "Evaluations",
                column: "RisqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicateurs_ObjectifId",
                table: "Indicateurs",
                column: "ObjectifId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_IndicateurId",
                table: "Mesures",
                column: "IndicateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UtilisateurId",
                table: "Notifications",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Objectifs_ProjetId",
                table: "Objectifs",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunites_ProjetId",
                table: "Opportunites",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_Phases_ProjetId",
                table: "Phases",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_Projets_ChefId",
                table: "Projets",
                column: "ChefId");

            migrationBuilder.CreateIndex(
                name: "IX_Projets_TypeId",
                table: "Projets",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projets_UserId",
                table: "Projets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reunions_ProjetId",
                table: "Reunions",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_Risques_ProjetId",
                table: "Risques",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_Taches_ActionId",
                table: "Taches",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Taches_PredTacheId",
                table: "Taches",
                column: "PredTacheId");

            migrationBuilder.CreateIndex(
                name: "IX_Taches_UserId",
                table: "Taches",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_ReunionId",
                table: "Utilisateurs",
                column: "ReunionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_Utilisateurs_UserId",
                table: "Taches",
                column: "UserId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_Actions_ActionId",
                table: "Taches",
                column: "ActionId",
                principalTable: "Actions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mesures_Indicateurs_IndicateurId",
                table: "Mesures",
                column: "IndicateurId",
                principalTable: "Indicateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Indicateurs_Objectifs_ObjectifId",
                table: "Indicateurs",
                column: "ObjectifId",
                principalTable: "Objectifs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Opportunites_OpportuniteId",
                table: "Evaluations",
                column: "OpportuniteId",
                principalTable: "Opportunites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Risques_RisqueId",
                table: "Evaluations",
                column: "RisqueId",
                principalTable: "Risques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Phases_PhaseId",
                table: "Actions",
                column: "PhaseId",
                principalTable: "Phases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Projets_ProjetId",
                table: "Actions",
                column: "ProjetId",
                principalTable: "Projets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Projets_ProjetId",
                table: "Documents",
                column: "ProjetId",
                principalTable: "Projets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Objectifs_Projets_ProjetId",
                table: "Objectifs",
                column: "ProjetId",
                principalTable: "Projets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunites_Projets_ProjetId",
                table: "Opportunites",
                column: "ProjetId",
                principalTable: "Projets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phases_Projets_ProjetId",
                table: "Phases",
                column: "ProjetId",
                principalTable: "Projets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reunions_Projets_ProjetId",
                table: "Reunions",
                column: "ProjetId",
                principalTable: "Projets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reunions_Projets_ProjetId",
                table: "Reunions");

            migrationBuilder.DropTable(
                name: "Autorisations");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Mesures");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Taches");

            migrationBuilder.DropTable(
                name: "Opportunites");

            migrationBuilder.DropTable(
                name: "Parametres");

            migrationBuilder.DropTable(
                name: "Risques");

            migrationBuilder.DropTable(
                name: "Indicateurs");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Objectifs");

            migrationBuilder.DropTable(
                name: "Phases");

            migrationBuilder.DropTable(
                name: "Projets");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "TypesProjet");

            migrationBuilder.DropTable(
                name: "Reunions");
        }
    }
}
