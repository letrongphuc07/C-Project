using System.Collections.ObjectModel;

namespace OpenSource.Shared.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public virtual Collection<Exam>? Exams { get; set; }
        public virtual Collection<FavoriteItems>? FavoriteItems { get; set; }
    }
}
