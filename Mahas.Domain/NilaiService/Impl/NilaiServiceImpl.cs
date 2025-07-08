using Mahas.Data;
using Mahas.Data.Dao;
using Mahas.Domain.JurusanService.Models;
using Mahas.Domain.NilaiService.Models;
using Mahas.Utilities.Base;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahas.Domain.NilaiService.Impl
{
    public class NilaiServiceImpl : INilaiService
    {
        private readonly ApplicationDbContext _db;

        public NilaiServiceImpl(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<NilaiDao> Create(NilaiCreateRequestDomainModel nilaiDTO)
        {
            if (nilaiDTO == null)
            {
                throw new Exception("Isinya yang bener");
            }

            if (!(await _db.Mahasiswas.AnyAsync(b => b.Id == nilaiDTO.MahasiswaId)))
            {
                throw new Exception($"Mahasiswa tidak ditemukan dengan id {nilaiDTO.MahasiswaId}");
            }

            if (!(await _db.MataKuliahs.AnyAsync(b => b.Id == nilaiDTO.MatakuliahId)))
            {
                throw new Exception($"MataKuliah tidak ditemukan dengan id {nilaiDTO.MatakuliahId}");
            }

            if (await _db.Nilais.AnyAsync(b => b.MahasiswaId == nilaiDTO.MahasiswaId && b.MatakuliahId == nilaiDTO.MatakuliahId))
            {
                throw new Exception($"Mahasiswa dengan id {nilaiDTO.MahasiswaId} sudah memiliki nilai di mata kuliah dengan id{nilaiDTO.MatakuliahId}");
            }

            NilaiDao res = new NilaiDao
            {
                MahasiswaId = nilaiDTO.MahasiswaId,
                MatakuliahId = nilaiDTO.MatakuliahId,
                Nilai = nilaiDTO.Nilai,
                Grade =  Helper.FromAngka(nilaiDTO.Nilai)
            };

            await _db.Nilais.AddAsync(res);
            await _db.SaveChangesAsync();
            return res;
        }

        public async Task Delete(int id)
        {
            var res = await _db.Nilais.FirstOrDefaultAsync(b => b.Id == id);
            if (res == null)
            {
                return;
            }
            _db.Nilais.Remove(res);
            await _db.SaveChangesAsync();
        }

        public async Task<NilaiDao?> Get(int id)
        {
            return await _db.Nilais.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<NilaiDao>> GetAll()
        {
            return await _db.Nilais.ToListAsync();
        }

        public async Task<NilaiDao> Update(int id, NilaiCreateRequestDomainModel nilaiDTO)
        {
            if (!(await _db.Nilais.AnyAsync(b => b.MahasiswaId == nilaiDTO.MahasiswaId)))
            {
                throw new Exception($"Mahasiswa tidak ditemukan dengan id {nilaiDTO.MahasiswaId}");
            }

            if (!(await _db.Nilais.AnyAsync(b => b.MatakuliahId == nilaiDTO.MatakuliahId)))
            {
                throw new Exception($"MataKuliah tidak ditemukan dengan id {nilaiDTO.MatakuliahId}");
            }

            var res = await _db.Nilais.FirstOrDefaultAsync(b => b.Id == id);
            if (res == null)
            {
                throw new Exception("Gaada Id itu");
            }
            res.MahasiswaId = nilaiDTO.MahasiswaId;
            res.MatakuliahId = nilaiDTO.MatakuliahId;
            res.Nilai = nilaiDTO.Nilai;
            res.Grade = Helper.FromAngka(nilaiDTO.Nilai);

            _db.Nilais.Update(res);
            await _db.SaveChangesAsync();
            return res;
        }
    }
}
