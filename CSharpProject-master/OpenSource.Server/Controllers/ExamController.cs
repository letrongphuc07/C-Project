using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenSource.Server.Data;
using OpenSource.Shared.Entities;

namespace WebBanKhoaHocTA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ExamController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> GetAllExam()
        {
            var exams = await _dbContext.Exams.ToListAsync();
            return Ok(exams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExamById(int id)
        {
            var exam = await _dbContext.Exams.FindAsync(id);

            if (exam == null)
                return NotFound();

            return Ok(exam);
        }

        [HttpPost]
        public async Task<ActionResult<Exam>> CreateExam(Exam exam)
        {
            _dbContext.Exams.Add(exam);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExamById), new { id = exam.ExamId }, exam);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExam(int id, Exam exam)
        {
            if (id != exam.ExamId)
                return BadRequest();

            _dbContext.Entry(exam).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Exams.Any(e => e.ExamId == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var exam = await _dbContext.Exams.FindAsync(id);

            if (exam == null)
                return NotFound();

            _dbContext.Exams.Remove(exam);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
