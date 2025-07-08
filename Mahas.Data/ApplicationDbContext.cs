using Mahas.Data.Dao;
using Microsoft.EntityFrameworkCore;

namespace Mahas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<MahasiswaDao> Mahasiswas { get; set; }
        public DbSet<JurusanDao> Jurusans { get; set; }
        public DbSet<MataKuliahDao> MataKuliahs { get; set; }
        public DbSet<NilaiDao> Nilais { get; set; }
    }
}
