using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActiveBug.Migrations
{
    /// <inheritdoc />
    public partial class categPrior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Issue");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Issue");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Issue",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriorityID",
                table: "Issue",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Priority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issue_CategoryID",
                table: "Issue",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_PriorityID",
                table: "Issue",
                column: "PriorityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Category_CategoryID",
                table: "Issue",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Priority_PriorityID",
                table: "Issue",
                column: "PriorityID",
                principalTable: "Priority",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Category_CategoryID",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Priority_PriorityID",
                table: "Issue");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Priority");

            migrationBuilder.DropIndex(
                name: "IX_Issue_CategoryID",
                table: "Issue");

            migrationBuilder.DropIndex(
                name: "IX_Issue_PriorityID",
                table: "Issue");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Issue");

            migrationBuilder.DropColumn(
                name: "PriorityID",
                table: "Issue");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Issue",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Issue",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
