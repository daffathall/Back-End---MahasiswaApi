using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mahas.Data.Migrations.MahasiswaDBMigration
{
    /// <inheritdoc />
    public partial class refactortablematakuliahdannilai2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Angka",
                table: "Nilais");

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "Nilais",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Nilai",
                table: "Nilais",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Nilais");

            migrationBuilder.DropColumn(
                name: "Nilai",
                table: "Nilais");

            migrationBuilder.AddColumn<double>(
                name: "Angka",
                table: "Nilais",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
