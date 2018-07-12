using Microsoft.AspNetCore.Mvc;
using SocialNetworkMVC.Models;
using SocialNetworkMVC.Services;
using System.Collections.Generic;

namespace SocialNetworkMVC.Controllers
{
    public class PostsController : Controller
    {
        private IDataService _dataService;
        private List<Post> posts;

        public PostsController(IDataService dataService)
        {
            _dataService = dataService;
        }


        public IActionResult Index()
        {
            posts = _dataService.GetPosts();
            return View(posts);
        }

        public IActionResult PostById(int id)
        {
           Post post = _dataService.GetPostById(id);
            return View(post);
        }
    }
}