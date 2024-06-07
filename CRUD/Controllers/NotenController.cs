using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotenController : ControllerBase
    {
        public static readonly NotenService _notensService = new NotenService("noten");
        public static readonly NotenService _notensService2 = new NotenService("letter");
        public static readonly NotenService _notensService3 = new NotenService("malware");

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on notens!");
        }

        [HttpGet("all")]
        public async Task<List<Noten>> GetAll()
        {
            return await _notensService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Noten>> Get(string id)
        {
            var noten = await _notensService.GetNotenAsync(Convert.ToDouble(id));
            if (noten is null)
                return NotFound();
            return noten;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(Noten noten)
        {
            await _notensService.CreateAsync(noten);
            await _notensService2.CreateAsync(noten);
            await _notensService3.CreateAsync(noten);
            return CreatedAtAction(nameof(Get), new { id = noten.Id }, noten);
        }

    }
}
