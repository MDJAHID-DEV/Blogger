using Blogger.DATA;
using Blogger.Models;
using Blogger.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Controllers
{
    public class PostController : Controller
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }
       
        public IActionResult List([FromQuery] string searching)
        {
            var posts = new List<Post>();
            posts.AddRange(PostService.Posts);
            if (string.IsNullOrWhiteSpace(searching))
            {
                posts = _context.Posts.ToList();
                posts.AddRange(PostService.Posts);
            }
            else {
                posts = posts.Where(x => x.Content.Contains(searching.ToLower())).ToList();
            }
            return View(posts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm]Post post)
        {

            if (post == null)
                return BadRequest("Post data invalid");
            if (!ModelState.IsValid)
            {
                return View(post);
            }

            _context.Add(post);
            _context.SaveChanges();

            return RedirectToAction("List");
        }
        public IActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Post Id is Invalid");
            }
                var existingPost = _context.Posts.FirstOrDefault(x => x.Id == id);

            if (existingPost == null)
                return NotFound("Post not found");

            return View(existingPost);
        }
        [HttpPost]
        public IActionResult Edit(int id,Post updatedPost)
        {
            if (id <= 0)
            {
                return BadRequest("Post Id is invalid");
            }
            if (!ModelState.IsValid)
            {
                return View(updatedPost);
            }

            _context.Posts.Update(updatedPost);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

    }
}
