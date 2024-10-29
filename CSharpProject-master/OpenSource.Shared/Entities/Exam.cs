using System.Collections.ObjectModel;

namespace OpenSource.Shared.Entities
{
    public class Exam
    {
        public int ExamId { get; set; }
        public string? ExamName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual User? User { get; set; }
        public virtual Collection<Question>? Questions { get; set; }
    }
}
