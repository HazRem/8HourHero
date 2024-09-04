using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _8HourHero.Shared;
using _8HourHero.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace _8HourHero.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly DataContext _context;

        public HeroesController(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Hero>>> GetAllHeroes()
        {
            var list = await _context.Heroes.ToListAsync();

            return Ok(list);
        }
    }
}
