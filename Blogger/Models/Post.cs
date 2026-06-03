using Blogger.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blogger.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The blog Title is  required")]
        [StringLength(200,ErrorMessage ="Title input Character maximum size is 200 and minimum is 10 minm",MinimumLength =10)]
        [Display(Name ="Enter your title")]
        public string Title { get; set; }
        [Required(ErrorMessage ="The blog content must be fulfilled")]
        [StringLength(5000)]
        [DisplayName("Write your content....")]
        public string Content { get; set; }
        [Required]
        [MaxLength(250)]
        public string Slug { get; set; }
        public string Media { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        [Required(ErrorMessage="Blog Status is required")]
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
