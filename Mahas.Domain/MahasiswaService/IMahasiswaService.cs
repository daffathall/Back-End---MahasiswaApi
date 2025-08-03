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
        public Task<MahasiswaResponse?> Get(int id);
        public Task<MahasiswaResponse?> GetViaNim(int nim);
        public Task<List<MahasiswaResponse>> GetAll();
        public Task<MahasiswaResponse> Create(MahasiswaCreateRequestDomainModel mahasiswaDTO);
        public Task<MahasiswaDao> Update(int id, MahasiswaCreateRequestDomainModel mahasiswaDTO);
        public Task<MahasiswaDao> UpdateViaNim(int nim, MahasiswaCreateRequestDomainModel mahasiswaDTO);
        public Task Delete(int id);
        public Task SetJurusan(int mahaid, MahasiswaCreateRequestDomainModel mahasiswaDTO);
    }
}
