using Mahas.Data.Dao;
using Mahas.Domain.JurusanService.Models;
using Mahas.Domain.MahasiswaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahas.Domain.JurusanService
{
    public interface IJurusanService
    {
        public Task<JurusanDao?> Get(int id);
        public Task<List<JurusanDao>> GetAll();
        public Task<JurusanDao> Create(JurusanCreateRequestDomainModel JurusanDTO);
        public Task<JurusanDao> Update(int id, JurusanCreateRequestDomainModel JurusanDTO);
        public Task Delete(int id);
    }
}
