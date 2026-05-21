using Blogger.Enums;

namespace Blogger.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public string Media { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public Status Status { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public Post()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            PublishedAt = DateTime.Now;
            Media = "~/images/post/default-post.jpg";
            CategoryId = 1;
            UserId = 1;
        }
    }
}
