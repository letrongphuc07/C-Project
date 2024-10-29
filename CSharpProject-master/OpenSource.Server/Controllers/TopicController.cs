using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenSource.Server.Data;
using OpenSource.Shared.Entities;

namespace WebBanKhoaHocTA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TopicController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Topic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topic>>> GetAll()
        {
            var topics = await _context.Topics.Include(t => t.Videos).ToListAsync();
            return Ok(topics);
        }
    }
}
