using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotoCloud.Data.Migrations
{
    public partial class photosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoModel_AlbumModel_AlbumModelId",
                table: "PhotoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoModel_AspNetUsers_ApplicationUserId",
                table: "PhotoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhotoModel",
                table: "PhotoModel");

            migrationBuilder.RenameTable(
                name: "PhotoModel",
                newName: "Photos");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoModel_ApplicationUserId",
                table: "Photos",
                newName: "IX_Photos_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoModel_AlbumModelId",
                table: "Photos",
                newName: "IX_Photos_AlbumModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AlbumModel_AlbumModelId",
                table: "Photos",
                column: "AlbumModelId",
                principalTable: "AlbumModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_ApplicationUserId",
                table: "Photos",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AlbumModel_AlbumModelId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_ApplicationUserId",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "PhotoModel");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_ApplicationUserId",
                table: "PhotoModel",
                newName: "IX_PhotoModel_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_AlbumModelId",
                table: "PhotoModel",
                newName: "IX_PhotoModel_AlbumModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhotoModel",
                table: "PhotoModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoModel_AlbumModel_AlbumModelId",
                table: "PhotoModel",
                column: "AlbumModelId",
                principalTable: "AlbumModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoModel_AspNetUsers_ApplicationUserId",
                table: "PhotoModel",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
