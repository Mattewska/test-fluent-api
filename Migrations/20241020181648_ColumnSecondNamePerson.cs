using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_fluent_api.Migrations
{
    /// <inheritdoc />
    public partial class ColumnSecondNamePerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecondNamePerson",
                table: "Person",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondNamePerson",
                table: "Person");
        }
    }
}
