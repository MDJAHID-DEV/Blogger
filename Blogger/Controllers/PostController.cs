using Blogger.DATA;
using Blogger.Enums;
using Blogger.Models;
using Blogger.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Blogger.Controllers
{
    public class PostController : Controller
    {
        private readonly AppDbContext _context;
        private List<Post> Posts = new List<Post>();
        public PostController(AppDbContext context)
        {
            _context = context;
            Posts = PostService.Posts;
        }

        public IActionResult List([FromQuery] string searching, Status? status)
        {
        
            var allPosts = new List<Post>();
            allPosts.AddRange(_context.Posts.ToList()); 
            allPosts.AddRange(PostService.Posts);       

            var posts = new List<Post>();

            if (string.IsNullOrWhiteSpace(searching) && !status.HasValue)
            {
                posts = allPosts;
            }
            else if (!string.IsNullOrWhiteSpace(searching) && !status.HasValue)
            {
                var searchTerm = searching.ToLower();
                posts = allPosts.Where(x => (x.Content != null && x.Content.ToLower().Contains(searchTerm)) ||
                                            (x.Title != null && x.Title.ToLower().Contains(searchTerm))).ToList();
            }
            else if (string.IsNullOrWhiteSpace(searching) && status.HasValue)
            {
                posts = allPosts.Where(x => x.Status == status).ToList();
            }
            else
            {
                var searchTerm = searching.ToLower();
                posts = allPosts.Where(x => ((x.Content != null && x.Content.ToLower().Contains(searchTerm)) ||
                                             (x.Title != null && x.Title.ToLower().Contains(searchTerm))) &&
                                            x.Status == status).ToList();
            }

            return View(posts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {

            if (post == null)
                return BadRequest("Post data invalid");
            _context.Add(post);
            _context.SaveChanges();
            return RedirectToAction(nameof(List));
            }
            ModelState.AddModelError("", "Post data is invalid");
            return View(post);
        }
        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Post Id is Invalid");
            }

            var existingPost = _context.Posts.FirstOrDefault(x => x.Id == id);

            if (existingPost == null)
            {
                return NotFound("Post not found");
            }

            return View(existingPost);
        }
        [HttpPost]
        public IActionResult Edit(int id,Post post)
        {
           if(id<=0 || post==null) return BadRequest();
            if (ModelState.IsValid)
            {
                var existingPost = _context.Posts.FirstOrDefault(x => x.Id == id);

                if (existingPost == null) return NotFound("Post not found");
                existingPost.Title = post.Title;
                existingPost.Content = post.Content;
                existingPost.UpdatedAt = DateTime.UtcNow;
                existingPost.Slug = post.Slug;
                existingPost.Status = post.Status;

                _context.Posts.Update(existingPost);
                _context.SaveChanges();
                return RedirectToAction("List");
            
            }

            return View(post);
        }

    }
}
