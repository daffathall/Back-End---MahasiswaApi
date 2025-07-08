using Mahas.Domain.MataKuliahService;
using Mahas.Domain.MataKuliahService.Models;
using Mahas.Domain.NilaiService;
using Mahas.Domain.NilaiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahas.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NilaiController : ControllerBase
    {
        private readonly INilaiService _nilaiService;

        public NilaiController(INilaiService nilaiService)
        {
            _nilaiService = nilaiService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NilaiCreateRequestDomainModel? nilaiDTO)
        {
            try
            {
                var res = await _nilaiService.Create(nilaiDTO);
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
                await _nilaiService.Delete(id);
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
                var res = await _nilaiService.Get(id);
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
                var res = await _nilaiService.GetAll();
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] NilaiCreateRequestDomainModel nilaiDTO)
        {
            try
            {
                await _nilaiService.Update(id, nilaiDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
