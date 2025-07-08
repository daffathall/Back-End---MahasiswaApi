using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mahas.Data.Migrations.MahasiswaDBMigration
{
    /// <inheritdoc />
    public partial class refactortablematakuliahdannilai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MataKuliahs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MataKuliahs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nilais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MahasiswaId = table.Column<int>(type: "int", nullable: false),
                    MatakuliahId = table.Column<int>(type: "int", nullable: false),
                    Angka = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nilais", x => x.Id);
                });

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

            migrationBuilder.DropTable(
                name: "MataKuliahs");

            migrationBuilder.DropTable(
                name: "Nilais");

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
    }
}
