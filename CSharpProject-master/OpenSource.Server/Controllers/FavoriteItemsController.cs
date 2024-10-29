using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenSource.Server.Data;
using OpenSource.Shared.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanKhoaHocTA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavoriteItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/FavoriteItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteItems>>> GetAll()
        {
            var favoriteItems = await _context.FavoriteItems.ToListAsync();
            return Ok(favoriteItems);
        }

        // GET: api/FavoriteItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteItems>> GetById(int id)
        {
            var favoriteItem = await _context.FavoriteItems.FindAsync(id);

            if (favoriteItem == null)
            {
                return NotFound();
            }

            return favoriteItem;
        }

        // POST: api/FavoriteItems
        [HttpPost]
        public async Task<ActionResult<Favoriteitems>> Create(  FavoriteItems favoriteItem)
        {
            _context.FavoriteItems.Add(favoriteItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = favoriteItem.FavoriteId }, favoriteItem);
        }

        // PUT: api/FavoriteItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,FavoriteItems favoriteItem)
        {
            if (id != favoriteItem.FavoriteId)
            {
                return BadRequest();
            }

            _context.Entry(favoriteItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/FavoriteItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var favoriteItem = await _context.FavoriteItems.FindAsync(id);

            if (favoriteItem == null)
            {
                return NotFound();
            }

            _context.FavoriteItems.Remove(favoriteItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteItemExists(int id)
        {
            return _context.FavoriteItems.Any(e => e.FavoriteId == id);
        }
    }
}
