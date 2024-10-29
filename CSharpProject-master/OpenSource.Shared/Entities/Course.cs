
namespace OpenSource.Shared.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string? CourseName { get; set; }
        public float CoursePrice { get; set; }
        public string? CourseDescription { get; set; }
        public string? CourseImg { get; set; }
        public bool Status { get; set; }
        public int OwnerPeriod { get; set; }
    }
}
