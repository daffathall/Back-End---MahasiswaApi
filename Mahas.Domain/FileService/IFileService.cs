using Mahas.Data.Dao;
using Mahas.Domain.FileService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahas.Domain.FileService
{
    public interface IFileService
    {
        public Task<FileDao?> Upload(FileServiceCretaRequestDomainModel? fileDTO, string path); 
        public Task<FileServiceResponseDomainModel> Download(int id);
    }
}
