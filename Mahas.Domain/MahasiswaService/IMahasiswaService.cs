using Mahas.Data.Dao;
using Mahas.Domain.MahasiswaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahas.Domain.MahasiswaService
{
    public interface IMahasiswaService
    {
        public Task<MahasiswaDao?> Get(int id);
        public Task<List<MahasiswaDao>> GetAll();
        public Task<MahasiswaDao> Create(MahasiswaCreateRequestDomainModel mahasiswaDTO);
        public Task<MahasiswaDao> Update(int id, MahasiswaCreateRequestDomainModel mahasiswaDTO);
        public Task Delete(int id);
        public Task SetJurusan(int mahaid, MahasiswaCreateRequestDomainModel mahasiswaDTO);
    }
}
