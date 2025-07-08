using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mahas.Data.Migrations.MahasiswaDBMigration
{
    /// <inheritdoc />
    public partial class NambahModelJurusan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jurusans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kode = table.Column<int>(type: "int", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jurusans", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jurusans");
        }
    }
}
