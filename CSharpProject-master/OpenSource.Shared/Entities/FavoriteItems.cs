namespace OpenSource.Shared.Entities
{
    public class FavoriteItems
    {
        public int FavoriteId { get; set; }
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
