using Blogger.DATA;
using Blogger.Enums;
using Blogger.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Services
{
    public class PostService
    {
        private AppDbContext _dbContext;
   

        public PostService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        //public static List<Post> posts;
        public  List<Post> GetAllPost()
        {
            return _dbContext.Posts.ToList();

        }
        public void AddPost(Post post)
        {
            if (post != null)
                _dbContext.Posts.Add(post);
          
        }
    }
}
