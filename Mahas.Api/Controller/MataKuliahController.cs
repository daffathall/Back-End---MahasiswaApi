using Mahas.Domain.JurusanService;
using Mahas.Domain.JurusanService.Models;
using Mahas.Domain.MataKuliahService;
using Mahas.Domain.MataKuliahService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahas.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MataKuliahController : ControllerBase
    {
        private readonly IMataKuliahService _matkulService;

        public MataKuliahController(IMataKuliahService matkulService)
        {
            _matkulService = matkulService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MataKuliahCreateRequestDomainModel? matkulDTO)
        {
            try
            {
                var res = await _matkulService.Create(matkulDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _matkulService.Delete(id);
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
                var res = await _matkulService.Get(id);
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
                var res = await _matkulService.GetAll();
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] MataKuliahCreateRequestDomainModel matkulDTO)
        {
            try
            {
                await _matkulService.Update(id, matkulDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
