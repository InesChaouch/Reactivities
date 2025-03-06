using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace persistence.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsMost",
                table: "ActivityAttendees",
                newName: "IsHost");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsHost",
                table: "ActivityAttendees",
                newName: "IsMost");
        }
    }
}
