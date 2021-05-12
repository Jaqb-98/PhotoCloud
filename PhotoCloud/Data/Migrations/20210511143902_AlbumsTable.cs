using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotoCloud.Data.Migrations
{
    public partial class AlbumsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlbumModelId",
                table: "PhotoModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AlbumModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbumModel_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoModel_AlbumModelId",
                table: "PhotoModel",
                column: "AlbumModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumModel_ApplicationUserId",
                table: "AlbumModel",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoModel_AlbumModel_AlbumModelId",
                table: "PhotoModel",
                column: "AlbumModelId",
                principalTable: "AlbumModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoModel_AlbumModel_AlbumModelId",
                table: "PhotoModel");

            migrationBuilder.DropTable(
                name: "AlbumModel");

            migrationBuilder.DropIndex(
                name: "IX_PhotoModel_AlbumModelId",
                table: "PhotoModel");

            migrationBuilder.DropColumn(
                name: "AlbumModelId",
                table: "PhotoModel");
        }
    }
}
