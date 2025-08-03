using Mahas.Utilities.Base;

namespace Mahas.Data.Dao
{
    public class FileDao : BaseDao
    {
        public string? Path { get; set; }
        public string? FileName { get; set; }
        public string? ContentTyper { get; set; }
    }
}
