using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahas.Domain.FileService.Models
{
    public class FileServiceResponseDomainModel
    {
        public required byte[] FileContents { get; set; }
        public required string ContentType { get; set; }
        public string? FileName { get; set; }
    }
}
