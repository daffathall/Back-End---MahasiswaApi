using Mahas.Data.Dao;
using Mahas.Domain.FileService;
using Mahas.Domain.FileService.Models;
using Mahas.Domain.JurusanService;
using Mahas.Domain.JurusanService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Mahas.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] FileServiceCretaRequestDomainModel? fileDTO)
        {
            try
            {
                var res = await _fileService.Upload(fileDTO, "TestBelajar");
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Download([FromRoute] int id)
        {
            try
            {
                var res = await _fileService.Download(id);
                if(res.ContentType.StartsWith(@"image/") || res.ContentType.StartsWith(@"application/pdf"))
                    return File(res.FileContents, res.ContentType);

                return File(res.FileContents, res.ContentType, res.FileName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
