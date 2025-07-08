using Mahas.Domain.MahasiswaService;
using Mahas.Domain.MahasiswaService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mahas.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private readonly IMahasiswaService _mahasiswaService;

        public MahasiswaController(IMahasiswaService mahasiswaService)
        {
            _mahasiswaService = mahasiswaService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MahasiswaCreateRequestDomainModel? mahasiswaDTO)
        {
            try
            {
                var res = await _mahasiswaService.Create(mahasiswaDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                await _mahasiswaService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var res=await _mahasiswaService.Get(id);
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var res = await _mahasiswaService.GetAll();
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] MahasiswaCreateRequestDomainModel mahasiswaDTO)
        {
            try
            {
                await _mahasiswaService.Update(id, mahasiswaDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:int}/jurusan")]
        public async Task<IActionResult> SetJurusan([FromRoute] int id, [FromBody] MahasiswaCreateRequestDomainModel mahasiswaDTO)
        {
            try
            {
                await _mahasiswaService.SetJurusan(id, mahasiswaDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
