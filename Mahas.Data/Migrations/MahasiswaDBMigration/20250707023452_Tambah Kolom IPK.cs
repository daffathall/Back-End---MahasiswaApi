using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mahas.Data.Migrations.MahasiswaDBMigration
{
    /// <inheritdoc />
    public partial class TambahKolomIPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "IPK",
                table: "Mahasiswas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IPK",
                table: "Mahasiswas");
        }
    }
}
