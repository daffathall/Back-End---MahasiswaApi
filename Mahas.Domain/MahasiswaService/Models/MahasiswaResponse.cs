using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahas.Domain.MahasiswaService.Models
{
    public class MahasiswaResponse
    {
        public int Nim { get; set; } // Nomor Induk Mahasiswa
        public string? Nama { get; set; }
        public string? Jurusan { get; set; }
    }
}
