using Blogger.Enums;
using Blogger.Models;

namespace Blogger.Services
{
    public class PostService
    {
        public static List<Post> GetAllPost()
        {
            return new List<Post>()
            {
                new Post { Id = 1, Title = "Introduction to C#", Content = "Learn the basics of C# programming language.", Slug = "introduction-to-csharp", Status = Status.Published, CategoryId = 1, UserId = 101 },
                new Post { Id = 2, Title = "Getting Started with ASP.NET Core", Content = "Build web applications using ASP.NET Core framework.", Slug = "aspnet-core-guide", Status = Status.Published, CategoryId = 2, UserId = 102 },
                new Post { Id = 3, Title = "Blazor for Beginners", Content = "An introductory guide to Blazor for web development.", Slug = "blazor-for-beginners", Status = Status.Draft, CategoryId = 2, UserId = 103 },
                new Post { Id = 4, Title = "Entity Framework Core Basics", Content = "Learn how to work with databases using EF Core.", Slug = "ef-core-basics", Status = Status.Published, CategoryId = 3, UserId = 104 },
                new Post { Id = 5, Title = "Dependency Injection in ASP.NET Core", Content = "Understand dependency injection and its use cases.", Slug = "dependency-injection-guide", Status = Status.Draft, CategoryId = 2, UserId = 105 },
                new Post { Id = 6, Title = "Building APIs with ASP.NET Core", Content = "Create RESTful APIs using ASP.NET Core framework.", Slug = "building-apis-aspnetcore", Status = Status.Published, CategoryId = 4, UserId = 106 },
                new Post { Id = 7, Title = "Understanding Middleware in ASP.NET Core", Content = "Learn the role of middleware in request processing.", Slug = "middleware-aspnetcore", Status = Status.Draft, CategoryId = 2, UserId = 107 },
                new Post { Id = 8, Title = "Authentication and Authorization", Content = "Secure your applications using ASP.NET Core Identity.", Slug = "authentication-authorization", Status = Status.Published, CategoryId = 5, UserId = 108 },
                new Post { Id = 9, Title = "Routing in ASP.NET Core", Content = "Handle routing efficiently in ASP.NET Core applications.", Slug = "routing-aspnetcore", Status = Status.Published, CategoryId = 2, UserId = 109 },
                new Post { Id = 10, Title = "Asynchronous Programming in C#", Content = "Master async and await keywords for better performance.", Slug = "async-programming-csharp", Status = Status.Deleted, CategoryId = 1, UserId = 110 }
            };
          

        }
        public void AddPost(Post post)
        {
          
        }
    }
}
