using Mahas.Data;
using Mahas.Data.Dao;
using Mahas.Domain.MahasiswaService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahas.Domain.MahasiswaService.Impl
{
    public class MahasiswaServiceImpl : IMahasiswaService
    {
        private readonly ApplicationDbContext _db;

        public MahasiswaServiceImpl(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<MahasiswaResponse> Create(MahasiswaCreateRequestDomainModel mahasiswaDTO)
        {
            if(mahasiswaDTO == null)
            {
                throw new Exception("Isinya yang bener");
            }

            var jur = await _db.Jurusans.FirstOrDefaultAsync(b => b.Id == mahasiswaDTO.JurusanID);

            if (jur == null)
            {
                throw new Exception($"Jurusan tidak ditemukan dengan id {mahasiswaDTO.JurusanID}");
            }

            MahasiswaDao res = new MahasiswaDao
            {
                Nim = mahasiswaDTO.Nim,
                Nama = mahasiswaDTO.Nama,
                JurusanId = mahasiswaDTO.JurusanID
            };
            
            await _db.Mahasiswas.AddAsync(res);
            await _db.SaveChangesAsync();
            return new MahasiswaResponse
            {
                Nim = mahasiswaDTO.Nim,
                Nama = mahasiswaDTO.Nama,
                Jurusan = jur.Nama
            };
        }

        public async Task Delete(int id)
        {
            var res = await _db.Mahasiswas.FirstOrDefaultAsync(b=>b.Id == id);
            if(res == null)
            {
                return;
            }
            res.IsDeleted = true;
            _db.Mahasiswas.Update(res);
            await _db.SaveChangesAsync();
        }

        public async Task<MahasiswaResponse?> Get(int id)
        {
            return await _db.Mahasiswas.Include(b=>b.Jurusan).Where(b => b.Id == id && b.IsDeleted != true).Select(b=>new MahasiswaResponse {Jurusan = b.Jurusan.Nama, Nama = b.Nama, Nim = b.Nim}).FirstOrDefaultAsync();            
        }

        public async Task<MahasiswaResponse?> GetViaNim(int nim)
        {
            return await _db.Mahasiswas.Include(b=>b.Jurusan).Where(b => b.Nim == nim && b.IsDeleted != true).Select(b => new MahasiswaResponse { Jurusan = b.Jurusan.Nama, Nama = b.Nama, Nim = b.Nim }).FirstOrDefaultAsync();
        }

        public async Task<List<MahasiswaResponse>> GetAll()
        {
             return await _db.Mahasiswas.Include(b=>b.Jurusan).Where(b => b.IsDeleted != true).Select(b=>new MahasiswaResponse {Jurusan = b.Jurusan.Nama, Nama = b.Nama, Nim = b.Nim}).ToListAsync();            
        
        }

        public async Task<MahasiswaDao> Update(int id, MahasiswaCreateRequestDomainModel mahasiswaDTO)
        {
            if (!(await _db.Jurusans.AnyAsync(b => b.Id == mahasiswaDTO.JurusanID)))
            {
                throw new Exception($"Jurusan tidak ditemukan dengan id {mahasiswaDTO.JurusanID}");
            }

            var res = await _db.Mahasiswas.FirstOrDefaultAsync(b => b.Id == id);
            if (res == null)
            {
                throw new Exception("Gaada Id itu");
            }
            res.Nim = mahasiswaDTO.Nim;
            res.Nama = mahasiswaDTO.Nama;
            res.JurusanId = mahasiswaDTO.JurusanID;
            _db.Mahasiswas.Update(res);
            await _db.SaveChangesAsync();
            return res;
        }

        public async Task<MahasiswaDao> UpdateViaNim(int nim, MahasiswaCreateRequestDomainModel mahasiswaDTO)
        {
            if (!(await _db.Jurusans.AnyAsync(b => b.Id == mahasiswaDTO.JurusanID)))
            {
                throw new Exception($"Jurusan tidak ditemukan dengan id {mahasiswaDTO.JurusanID}");
            }

            var res = await _db.Mahasiswas.FirstOrDefaultAsync(b => b.Nim == nim);
            if (res == null)
            {
                throw new Exception("Gaada mahasiswa dengan NIM itu");
            }
            res.Nim = mahasiswaDTO.Nim;
            res.Nama = mahasiswaDTO.Nama;
            res.JurusanId = mahasiswaDTO.JurusanID;
            _db.Mahasiswas.Update(res);
            await _db.SaveChangesAsync();
            return res;
        }

        public async Task SetJurusan(int mahaid, MahasiswaCreateRequestDomainModel mahasiswaDTO)
        {
            if (!(await _db.Mahasiswas.AnyAsync(b => b.Id == mahaid && b.IsDeleted == false)))
            {
                throw new Exception($"Mahasiswa tidak ditemukan dengan id {mahaid}");
            }

            if (!(await _db.Jurusans.AnyAsync(b => b.Id == mahasiswaDTO.JurusanID && b.IsDeleted == false)))
            {
                throw new Exception($"Jurusan tidak ditemukan dengan id {mahasiswaDTO.JurusanID}");
            }

            var res = await _db.Mahasiswas.FirstOrDefaultAsync(b => b.Id == mahaid);
            res.JurusanId = mahasiswaDTO.JurusanID;
            _db.Mahasiswas.Update(res);
            await _db.SaveChangesAsync();
        }
    }
}
