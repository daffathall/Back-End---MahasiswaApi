using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mahas.Data.Migrations.MahasiswaDBMigration
{
    /// <inheritdoc />
    public partial class Nambahobjectis_deleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Mahasiswas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Mahasiswas");
        }
    }
}
