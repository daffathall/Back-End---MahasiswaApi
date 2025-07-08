using Mahas.Domain.JurusanService;
using Mahas.Domain.JurusanService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahas.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JurusanController : ControllerBase
    {
        private readonly IJurusanService _jurusanService;

        public JurusanController(IJurusanService jurusanService)
        {
            _jurusanService = jurusanService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JurusanCreateRequestDomainModel? jurusanDTO)
        {
            try
            {
                var res = await _jurusanService.Create(jurusanDTO);
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
                await _jurusanService.Delete(id);
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
                var res = await _jurusanService.Get(id);
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
                var res = await _jurusanService.GetAll();
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] JurusanCreateRequestDomainModel jurusanDTO)
        {
            try
            {
                await _jurusanService.Update(id, jurusanDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
