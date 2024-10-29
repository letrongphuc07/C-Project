using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenSource.Server.Data;
using OpenSource.Shared.Entities;

namespace WebBanKhoaHocTA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VideoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Video
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Video>>> GetAll()
        {
            return await _context.Videos.ToListAsync();
        }

        // GET: api/Video/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetById(int id)
        {
            var video = await _context.Videos.FindAsync(id);

            if (video == null)
            {
                return NotFound();
            }

            return video;
        }

        // POST: api/Video
        [HttpPost]
        public async Task<ActionResult<Video>> Create(Video video)
        {
            _context.Videos.Add(video);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = video.VideoId }, video);
        }

        // PUT: api/Video/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Video video)
        {
            if (id != video.VideoId)
            {
                return BadRequest();
            }

            _context.Entry(video).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoExists(id))
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

        // DELETE: api/Video/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var video = await _context.Videos.FindAsync(id);

            if (video == null)
            {
                return NotFound();
            }

            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideoExists(int id)
        {
            return _context.Videos.Any(v => v.VideoId == id);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Video>>> SearchUsersAsync(string searchItem)
        {
            try
            {
                var title = await _context.Videos.Where(u => u.Title.ToLower().Contains(searchItem.ToLower())).ToListAsync();
                return title;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi một cách thích hợp (ví dụ: trả về lỗi HTTP 500)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Lỗi khi tìm kiếm người dùng: {ex.Message}");
            }
        }
    }
}
