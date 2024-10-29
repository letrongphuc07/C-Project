using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenSource.Server.Data;
using OpenSource.Shared.Entities;

namespace WebBanKhoaHocTA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(u => u.UserId == id);
        }
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(LoginModel loginModel)
        {
            // Fetch user by username
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginModel.Username && u.Password == loginModel.Password);

            // User not found (invalid username)
            if (user == null)
            {
                return Unauthorized();
            }

   
            return Ok(new User
            {
                UserId = user.UserId,
                Username = user.Username
      
            });
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<User>>> SearchUsersAsync(string searchItem)
        {
            try
            {
                var users = await _context.Users.Where(u => u.Username.ToLower().Contains(searchItem.ToLower())).ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi một cách thích hợp (ví dụ: trả về lỗi HTTP 500)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Lỗi khi tìm kiếm người dùng: {ex.Message}");
            }
        }



    }
}
