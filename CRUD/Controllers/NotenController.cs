using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotenController : ControllerBase
    {
        public static readonly NotenService _notensService = new NotenService();

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on notens!");
        }

        [HttpGet("noten")]
        public async Task<List<Noten>> GetAll()
        {
            return await _notensService.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Noten>> Get(string id)
        {
            var noten = await _notensService.GetAsync(id);
            if (noten is null)
                return NotFound();
            return noten;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(Nota nota)
        {
            Noten noten = new Noten();
            noten.frequencia = nota.frequencia;
            noten.nota = nota;
            await _notensService.CreateAsync(noten);
            return CreatedAtAction(nameof(Get), new { id = noten.Id }, nota);
        }

    }
}
