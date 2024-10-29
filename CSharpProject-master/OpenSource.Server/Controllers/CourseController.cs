using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenSource.Server.Data;
using OpenSource.Shared.Entities;

namespace OpenSource.Server.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly AppDbContext context;

        public CourseController(AppDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAllCourse()
        {
            return await context.Courses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            var result = await context.Courses.FindAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> AddCourse(Course newCourse)
        {
            context.Courses.Add(newCourse);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllCourse), new { id = newCourse.Id }, newCourse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Course>> UpdateCourse(int id, Course course)
        {
            var result = await context.Courses.FindAsync(id);
            if (result == null) return NotFound();

            result.CourseName = course.CourseName;
            result.CoursePrice = course.CoursePrice;
            result.CourseDescription = course.CourseDescription;
            result.CourseImg = course.CourseImg;
            result.Status = course.Status;
            result.OwnerPeriod = course.OwnerPeriod;

            await context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await context.Courses.FindAsync(id);
            if (result == null) return NotFound();
            context.Courses.Remove(result);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
