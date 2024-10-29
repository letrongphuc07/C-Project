using System.Text.Json.Serialization;

namespace OpenSource.Shared.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int ExamId { get; set; }
        public string? QuestionText { get; set; }
        public string? QuestionType { get; set; }
        [JsonIgnore]
        public virtual Exam? Exam { get; set; }
    }
}
