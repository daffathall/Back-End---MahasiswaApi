using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahas.Domain.NilaiService.Models
{
    public class NilaiCreateRequestDomainModel
    {
        public int MahasiswaId { get; set; }
        public int MatakuliahId { get; set; }
        public decimal Nilai { get; set; }
    }
}
