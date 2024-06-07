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
        public static readonly ChordService _chordsService = new ChordService("chord");
        public static readonly ChordService _chordsService2 = new ChordService("artless");
        public static readonly ChordService _chordsService3 = new ChordService("recipe");

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on chords!");
        }

        [HttpGet("all")]
        public async Task<List<Chord>> GetAll()
        {
            return await _chordsService.GetAsync();
        }

        [HttpGet("noten/{id}")]
        public async Task<ActionResult<Chord>> Get(string id)
        {
            var chord = await _chordsService.GetChordAsync(id);
            if (chord is null)
                return NotFound();
            return chord;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(Chord chord)
        {
            await _chordsService.CreateAsync(chord);
            await _chordsService2.CreateAsync(chord);
            await _chordsService3.CreateAsync(chord);
            return CreatedAtAction(nameof(Get), new { id = chord.Id }, chord);
        }

    }
}
