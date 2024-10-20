using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_fluent_api.Migrations
{
    /// <inheritdoc />
    public partial class TableCredential : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "EmailPersonCheck",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "EmailPerson",
                table: "Person");

            migrationBuilder.AddColumn<long>(
                name: "IdCredencial",
                table: "Person",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Credential",
                columns: table => new
                {
                    IdCredentials = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credential", x => x.IdCredentials);
                    table.CheckConstraint("CK_Email_IsValid", "Email LIKE '%@%'");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_IdCredencial",
                table: "Person",
                column: "IdCredencial");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Credential_IdCredencial",
                table: "Person",
                column: "IdCredencial",
                principalTable: "Credential",
                principalColumn: "IdCredentials",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Credential_IdCredencial",
                table: "Person");

            migrationBuilder.DropTable(
                name: "Credential");

            migrationBuilder.DropIndex(
                name: "IX_Person_IdCredencial",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "IdCredencial",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "EmailPerson",
                table: "Person",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddCheckConstraint(
                name: "EmailPersonCheck",
                table: "Person",
                sql: "[Person].[EmailPerson] LIKE '%@%'");
        }
    }
}
