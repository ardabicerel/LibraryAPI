using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutuphaneAPI.Migrations
{
    /// <inheritdoc />
    public partial class YazarlarTablosuOlustur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitaplar_Yazar_YazarId",
                table: "Kitaplar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Yazar",
                table: "Yazar");

            migrationBuilder.RenameTable(
                name: "Yazar",
                newName: "Yazarlar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Yazarlar",
                table: "Yazarlar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitaplar_Yazarlar_YazarId",
                table: "Kitaplar",
                column: "YazarId",
                principalTable: "Yazarlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitaplar_Yazarlar_YazarId",
                table: "Kitaplar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Yazarlar",
                table: "Yazarlar");

            migrationBuilder.RenameTable(
                name: "Yazarlar",
                newName: "Yazar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Yazar",
                table: "Yazar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitaplar_Yazar_YazarId",
                table: "Kitaplar",
                column: "YazarId",
                principalTable: "Yazar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
