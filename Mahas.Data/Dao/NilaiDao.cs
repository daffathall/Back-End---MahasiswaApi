namespace Mahas.Data.Dao
{
    public class NilaiDao
    {
        public int Id { get; set; }
        public int MahasiswaId { get; set; }
        public int MatakuliahId { get; set; }
        public string? Grade { get; set; }
        public decimal Nilai { get; set; }
    }
}
