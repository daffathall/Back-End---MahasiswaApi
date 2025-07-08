namespace Mahas.Data.Dao
{
    public class JurusanDao
    {
        public int Id {  get; set; }
        public int Kode { get; set; }
        public string? Nama {  get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}