using Mahas.Data.Dao;
using Mahas.Domain.MataKuliahService.Models;
using Mahas.Domain.NilaiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahas.Domain.NilaiService
{
    public interface INilaiService
    {
        public Task<NilaiDao?> Get(int id);
        public Task<List<NilaiDao?>> GetAll();
        public Task<NilaiDao> Create(NilaiCreateRequestDomainModel nilaiDTO);
        public Task<NilaiDao> Update(int id, NilaiCreateRequestDomainModel nilaiDTO);
        public Task Delete(int id);
    }
}
