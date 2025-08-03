using Mahas.Data;
using Mahas.Data.Dao;
using Mahas.Domain.FileService.Models;
using Mahas.Utilities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahas.Domain.FileService.Impl
{
    public class FileServiceImpl : IFileService
    {
        private readonly ApplicationDbContext _db;

        public FileServiceImpl(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<FileDao?> Upload(FileServiceCretaRequestDomainModel? fileDTO, string path)
        {
            path = path.SafePath();
            string filePath = Helper.CreateFullUploadPath(path);
            string filePathShort = Helper.CreateBaseUploadPath(path);
            string filename = fileDTO.File.FileName.ToLower();

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            FileDao result = new FileDao
            {
                Path = filePathShort,
                FileName = filename,
                ContentTyper = fileDTO.File.ContentType
            };

            await _db.Files.AddAsync(result);
            await _db.SaveChangesAsync();

            using (var stream = new FileStream(Path.Combine(filePath, result.FileName), FileMode.Create))
            {
                await fileDTO.File.CopyToAsync(stream);
                await stream.FlushAsync();
            }

            return result;

        }

        public async Task<FileServiceResponseDomainModel> Download(int id)
        {
            var res = await _db.Files.FirstOrDefaultAsync(b => b.Id == id);
            if (res == null)
            {
                throw new Exception("gaada");
            }

            string filePath = Path.Combine(Helper.BASE_PATH_DIRECTORY(), res.Path, res.FileName);
            byte[] byteArray = await File.ReadAllBytesAsync(filePath);

            return new FileServiceResponseDomainModel
            {
                FileName = res.FileName,
                ContentType = res.ContentTyper,
                FileContents = byteArray
            };
        }
    }
}
