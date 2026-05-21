using Blogger.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            var posts =PostService.GetAllPost();
            return View(posts);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
