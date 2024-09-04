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

        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHero(int id)
        {
            var heroToUpdate = await _context.Heroes.FindAsync(id);
            if (heroToUpdate == null)
            {
                return NotFound("This hero doesn't exist!");
            }
            return Ok(heroToUpdate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Hero>>> UpdateHero(int id, Hero hero)
        {
            var heroToUpdate = await _context.Heroes.FindAsync(id);
            if(heroToUpdate == null) 
            {
                return NotFound("This hero doesn't exist!");
            }

            heroToUpdate.Name = hero.Name;

            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();

            return await GetAllHeroes();
        }

        [HttpPost]
        public async Task<ActionResult<List<Hero>>> CreateHero(Hero hero)
        {
            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();

            return await GetAllHeroes();
        }
    }
}
