using Microsoft.EntityFrameworkCore;
using OpenSource.Shared.Entities;

namespace OpenSource.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<FavoriteItems> FavoriteItems { get; set; }
        public DbSet<Items> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
               .HasOne(q => q.Exam)
               .WithMany(e => e.Questions)
               .HasForeignKey(q => q.ExamId);

            modelBuilder.Entity<Exam>()
                .HasOne(e => e.User)
                .WithMany(u => u.Exams)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Video>()
                .HasOne(v => v.Topic)
                .WithMany(t => t.Videos)
                .HasForeignKey(v => v.TopicId);

            modelBuilder.Entity<Topic>().HasData(
                new Topic { TopicId = 1, TopicName = "Tiếng Anh cơ bản cho người mới bắt đầu" },
                new Topic { TopicId = 2, TopicName = "IELTS 5.0 cấp tốc" }
            );

            modelBuilder.Entity<FavoriteItems>().HasKey(fi => fi.FavoriteId); // Define primary key

            base.OnModelCreating(modelBuilder);
        }
    }
}
