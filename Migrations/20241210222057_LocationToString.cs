using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Migrations
{
    /// <inheritdoc />
    public partial class LocationToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location_Latitude",
                table: "ToDoItems");

            migrationBuilder.RenameColumn(
                name: "Location_Longitude",
                table: "ToDoItems",
                newName: "Location");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "ToDoItems",
                newName: "Location_Longitude");

            migrationBuilder.AddColumn<string>(
                name: "Location_Latitude",
                table: "ToDoItems",
                type: "TEXT",
                nullable: true);
        }
    }
}
