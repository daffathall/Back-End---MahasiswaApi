namespace Mahas.Data.Dao
{
    public class MahasiswaDao
    {
        public int Id { get; set; }
        public int Nim { get; set; } // Nomor Induk Mahasiswa
        public string? Nama { get; set; }
        public int? JurusanId { get; set; }
        public virtual JurusanDao? Jurusan { get; set; }
        public decimal IPK { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
