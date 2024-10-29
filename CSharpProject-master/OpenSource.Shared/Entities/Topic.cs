using System.Collections.ObjectModel;

namespace OpenSource.Shared.Entities
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string? TopicName { get; set; }
        public virtual Collection<Video>? Videos { get; set; }
    }
}
