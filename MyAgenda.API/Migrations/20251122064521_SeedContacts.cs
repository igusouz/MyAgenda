using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyAgenda.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedContacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 22, 6, 45, 21, 549, DateTimeKind.Utc).AddTicks(156), "ana.silva@example.com", "Ana Silva", "(11) 98876-1234" },
                    { 2, new DateTime(2025, 11, 22, 6, 45, 21, 549, DateTimeKind.Utc).AddTicks(158), "bruno.santos@example.com", "Bruno Santos", "(21) 99745-6789" },
                    { 3, new DateTime(2025, 11, 22, 6, 45, 21, 549, DateTimeKind.Utc).AddTicks(159), "carla.almeida@example.com", "Carla Almeida", "(31) 98432-5566" },
                    { 4, new DateTime(2025, 11, 22, 6, 45, 21, 549, DateTimeKind.Utc).AddTicks(160), "diego.rodrigues@example.com", "Diego Rodrigues", "(41) 99123-7890" },
                    { 5, new DateTime(2025, 11, 22, 6, 45, 21, 549, DateTimeKind.Utc).AddTicks(161), "elaine.costa@example.com", "Elaine Costa", "(51) 98765-4321" },
                    { 6, new DateTime(2025, 11, 22, 6, 45, 21, 549, DateTimeKind.Utc).AddTicks(162), "fabio.mendes@example.com", "Fabio Mendes", "(71) 98123-4455" },
                    { 7, new DateTime(2025, 11, 22, 6, 45, 21, 549, DateTimeKind.Utc).AddTicks(163), "gabriela.torres@example.com", "Gabriela Torres", "(81) 98654-7788" },
                    { 8, new DateTime(2025, 11, 22, 6, 45, 21, 549, DateTimeKind.Utc).AddTicks(164), "henrique.lima@example.com", "Henrique Lima", "(91) 98321-0099" },
                    { 9, new DateTime(2025, 11, 22, 6, 45, 21, 549, DateTimeKind.Utc).AddTicks(165), "isabela.martins@example.com", "Isabela Martins", "(62) 99234-5678" },
                    { 10, new DateTime(2025, 11, 22, 6, 45, 21, 549, DateTimeKind.Utc).AddTicks(166), "joao.pereira@example.com", "João Pereira", "(85) 99543-2211" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
