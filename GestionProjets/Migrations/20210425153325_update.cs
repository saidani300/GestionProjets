using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionProjets.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projets_TypesProjet_TypeId",
                table: "Projets");

            migrationBuilder.DropIndex(
                name: "IX_Projets_TypeId",
                table: "Projets");

            migrationBuilder.AlterColumn<Guid>(
                name: "TypeId",
                table: "Projets",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "TypeId",
                table: "Projets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Projets_TypeId",
                table: "Projets",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projets_TypesProjet_TypeId",
                table: "Projets",
                column: "TypeId",
                principalTable: "TypesProjet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
