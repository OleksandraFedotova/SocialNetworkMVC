using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructuresAndLINQ;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkMVC.Services;

namespace SocialNetworkMVC.Controllers
{
    public class PostsController : Controller
    {
        private DataService dataService;
        private List<Post> posts;

        public PostsController()
        {
            dataService = new DataService();
        }


        public IActionResult Index()
        {
            posts = dataService.GetPosts();
            return View(posts);
        }

        public IActionResult PostById(int id)
        {
           Post post = dataService.GetPostById(id);
            return View(post);
        }
    }
}