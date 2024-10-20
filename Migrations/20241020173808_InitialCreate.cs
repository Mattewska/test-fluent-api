using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_fluent_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    IdPerson = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<long>(type: "bigint", maxLength: 10, nullable: false),
                    NamePerson = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastNamePerson = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BirthdayPerson = table.Column<DateTime>(type: "date", nullable: false),
                    EmailPerson = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.IdPerson);
                    table.CheckConstraint("EmailPersonCheck", "[Person].[EmailPerson] LIKE '%@%'");
                    table.ForeignKey(
                        name: "FK_Person_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_IdRol",
                table: "Person",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
