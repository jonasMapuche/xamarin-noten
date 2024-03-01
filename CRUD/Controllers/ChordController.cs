using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChordController : ControllerBase
    {
        public static readonly ChordService _chordsService = new ChordService();

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on chords!");
        }

        [HttpGet("noten")]
        public async Task<List<Chord>> GetAll()
        {
            return await _chordsService.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Chord>> Get(string id)
        {
            var chord = await _chordsService.GetAsync(id);
            if (chord is null)
                return NotFound();
            return chord;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(Interlude interlude)
        {
            Chord chord = new Chord();
            chord.sigla = interlude.sigla;
            chord.interlude = interlude;
            await _chordsService.CreateAsync(chord);
            return CreatedAtAction(nameof(Get), new { id = chord.Id }, interlude);
        }

    }
}
