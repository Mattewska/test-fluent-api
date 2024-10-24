using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_fluent_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataWithData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Credential",
                columns: new[] { "IdCredentials", "Email", "Password" },
                values: new object[] { 1L, "adminTest@LoginTest.com", "123456" });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "IdRol", "NameRol" },
                values: new object[] { 1, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Credential",
                keyColumn: "IdCredentials",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "IdRol",
                keyValue: 1);
        }
    }
}
