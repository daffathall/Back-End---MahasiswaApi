using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mahas.Data.Migrations.MahasiswaDBMigration
{
    /// <inheritdoc />
    public partial class addtablematakuliahdannilai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mahasiswas_Jurusans_JurusanId",
                table: "Mahasiswas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jurusans",
                table: "Jurusans");

            migrationBuilder.RenameTable(
                name: "Jurusans",
                newName: "JurusanDao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JurusanDao",
                table: "JurusanDao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mahasiswas_JurusanDao_JurusanId",
                table: "Mahasiswas",
                column: "JurusanId",
                principalTable: "JurusanDao",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mahasiswas_JurusanDao_JurusanId",
                table: "Mahasiswas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JurusanDao",
                table: "JurusanDao");

            migrationBuilder.RenameTable(
                name: "JurusanDao",
                newName: "Jurusans");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jurusans",
                table: "Jurusans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mahasiswas_Jurusans_JurusanId",
                table: "Mahasiswas",
                column: "JurusanId",
                principalTable: "Jurusans",
                principalColumn: "Id");
        }
    }
}
