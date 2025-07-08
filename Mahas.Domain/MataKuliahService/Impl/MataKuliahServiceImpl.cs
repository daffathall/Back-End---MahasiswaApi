using Mahas.Data;
using Mahas.Data.Dao;
using Mahas.Domain.MahasiswaService.Models;
using Mahas.Domain.MataKuliahService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahas.Domain.MataKuliahService.Impl
{
    public class MataKuliahServiceImpl : IMataKuliahService
    {
        private readonly ApplicationDbContext _db;

        public MataKuliahServiceImpl(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<MataKuliahDao> Create(MataKuliahCreateRequestDomainModel matkulDTO)
        {
            if (matkulDTO == null)
            {
                throw new Exception("Isinya yang bener");
            }

            MataKuliahDao res = new MataKuliahDao
            {
                Nama = matkulDTO.Nama,
                SKS = matkulDTO.SKS
            };

            await _db.MataKuliahs.AddAsync(res);
            await _db.SaveChangesAsync();
            return res;
        }

        public async Task Delete(int id)
        {
            var res = await _db.MataKuliahs.FirstOrDefaultAsync(b => b.Id == id);
            if (res == null)
            {
                return;
            }
            _db.MataKuliahs.Remove(res);
            await _db.SaveChangesAsync();
        }

        public async Task<MataKuliahDao?> Get(int id)
        {
            return await _db.MataKuliahs.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<MataKuliahDao>> GetAll()
        {
            return await _db.MataKuliahs.ToListAsync();
        }

        public async Task<MataKuliahDao> Update(int id, MataKuliahCreateRequestDomainModel matkulDTO)
        {
            var res = await _db.MataKuliahs.FirstOrDefaultAsync(b => b.Id == id);
            if (res == null)
            {
                throw new Exception("Gaada Mata Kuliah dengan ID itu");
            }
            res.Nama = matkulDTO.Nama;
            res.SKS = matkulDTO.SKS;

            _db.MataKuliahs.Update(res);
            await _db.SaveChangesAsync();
            return res;
        }
    }
}
