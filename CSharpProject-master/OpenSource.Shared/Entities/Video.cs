using System.Text.Json.Serialization;

namespace OpenSource.Shared.Entities
{
    public class Video
    {
        public int VideoId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int TopicId { get; set; }
        public string? DifficultyLevel { get; set; }
        public int Duration { get; set; }
        public string? Language { get; set; }
        public string? VideoUrl { get; set; }
        public string? ThumbnailUrl { get; set; }
        public double AverageRating { get; set; }
        public DateTime UploadDate { get; set; }
        [JsonIgnore]
        public virtual Topic? Topic { get; set; }
    }
}
