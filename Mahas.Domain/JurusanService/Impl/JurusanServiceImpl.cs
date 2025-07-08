using Mahas.Data;
using Mahas.Data.Dao;
using Mahas.Domain.JurusanService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahas.Domain.JurusanService.Impl
{
    public class JurusanServiceImpl : IJurusanService
    {
        private readonly ApplicationDbContext _db;

        public JurusanServiceImpl(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<JurusanDao> Create(JurusanCreateRequestDomainModel JurusanDTO)
        {
            if (JurusanDTO == null)
            {
                throw new Exception("Isinya yang bener");
            }

            JurusanDao res = new JurusanDao
            {
                Kode = JurusanDTO.Kode,
                Nama = JurusanDTO.Nama,
            };

            await _db.Jurusans.AddAsync(res);
            await _db.SaveChangesAsync();
            return res;
        }

        public async Task Delete(int id)
        {
            var res = await _db.Jurusans.FirstOrDefaultAsync(b => b.Id == id);
            if (res == null)
            {
                return;
            }
            res.IsDeleted = true;
            _db.Jurusans.Update(res);
            await _db.SaveChangesAsync();
        }

        public async Task<JurusanDao?> Get(int id)
        {
            return await _db.Jurusans.FirstOrDefaultAsync(b => b.Id == id && b.IsDeleted != true);
        }

        public async Task<List<JurusanDao>> GetAll()
        {
            return await _db.Jurusans.Where(b => b.IsDeleted != true).ToListAsync();
        }

        public async Task<JurusanDao> Update(int id, JurusanCreateRequestDomainModel JurusanDTO)
        {
            var res = await _db.Jurusans.FirstOrDefaultAsync(b => b.Id == id);
            if (res == null)
            {
                throw new Exception("Gaada Id itu");
            }
            res.Kode = JurusanDTO.Kode;
            res.Nama = JurusanDTO.Nama;
            
            _db.Jurusans.Update(res);
            await _db.SaveChangesAsync();
            return res;
        }
    }
}
