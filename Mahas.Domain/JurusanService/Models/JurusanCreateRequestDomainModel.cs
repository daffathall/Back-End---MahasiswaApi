using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahas.Domain.JurusanService.Models
{
    public class JurusanCreateRequestDomainModel
    {
        public int Kode { get; set; } 
        public string? Nama { get; set; }
    }
}
