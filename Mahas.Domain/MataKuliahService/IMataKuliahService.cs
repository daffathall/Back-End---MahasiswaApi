using Mahas.Data.Dao;
using Mahas.Domain.MahasiswaService.Models;
using Mahas.Domain.MataKuliahService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahas.Domain.MataKuliahService
{
    public interface IMataKuliahService
    {
        public Task<MataKuliahDao?> Get(int id);
        public Task<List<MataKuliahDao?>> GetAll();
        public Task<MataKuliahDao> Create(MataKuliahCreateRequestDomainModel mahasiswaDTO);
        public Task<MataKuliahDao> Update(int id, MataKuliahCreateRequestDomainModel mahasiswaDTO);
        public Task Delete(int id);
    }
}