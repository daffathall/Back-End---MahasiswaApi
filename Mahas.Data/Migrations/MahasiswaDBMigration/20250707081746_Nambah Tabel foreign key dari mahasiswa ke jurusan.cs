using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mahas.Data.Migrations.MahasiswaDBMigration
{
    /// <inheritdoc />
    public partial class NambahTabelforeignkeydarimahasiswakejurusan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jurusan",
                table: "Mahasiswas");

            migrationBuilder.AddColumn<int>(
                name: "JurusanId",
                table: "Mahasiswas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mahasiswas_JurusanId",
                table: "Mahasiswas",
                column: "JurusanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mahasiswas_Jurusans_JurusanId",
                table: "Mahasiswas",
                column: "JurusanId",
                principalTable: "Jurusans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mahasiswas_Jurusans_JurusanId",
                table: "Mahasiswas");

            migrationBuilder.DropIndex(
                name: "IX_Mahasiswas_JurusanId",
                table: "Mahasiswas");

            migrationBuilder.DropColumn(
                name: "JurusanId",
                table: "Mahasiswas");

            migrationBuilder.AddColumn<string>(
                name: "Jurusan",
                table: "Mahasiswas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
