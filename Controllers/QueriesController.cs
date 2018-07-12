using Microsoft.AspNetCore.Mvc;
using SocialNetworkMVC.Models;
using SocialNetworkMVC.Services;
using System.Collections.Generic;

namespace SocialNetworkMVC.Controllers
{
    public class QueriesController : Controller
    {
        private IDataService _dataService;
        private List<User> users;

        public QueriesController(IDataService dataService)
        {
            _dataService = dataService;
        }
       
        [Route("Queries")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Queries/1")]
        public IActionResult Query1()
        {
            return View();
        }

        // POST:  Queries/Query1
        [HttpPost]
        [Route("Queries/1")]
        public ActionResult Query1(int userId)
        {
            var count = _dataService.GetPostsCount(userId);
            ViewBag.Count = "User posts count = " + count;
            return View(count);

        }


        [HttpGet]
        [Route("Queries/2")]
        public IActionResult Query2()
        {
            return View();
        }

        // POST: Queries/Query2
        [HttpPost]
        [Route("Queries/2")]
        public ActionResult Query2(int userId)
        {
            var comments = _dataService.GetPostComentsLessThenFiFtyLength(userId);
            ViewBag.Count = comments;
            return View(comments);

        }


        [HttpGet]
        [Route("Queries/3")]
        public IActionResult Query3()
        {
            return View();
        }

        // POST: Queries/Query2
        [HttpPost]
        [Route("Queries/3")]
        public ActionResult Query3(int userId)
        {
            var doneTodos = _dataService.GetDoneTodos(userId);

            ViewBag.DoneTodos = doneTodos;
            return View(doneTodos);

        }


        [HttpGet]
        [Route("Queries/4")]
        public IActionResult Query4()
        {
            var users = _dataService.GetSortedUserAndToDos();
            return View(users);
        }

        [HttpGet]
        [Route("Queries/5")]
        public IActionResult Query5()
        {
            return View();
        }

        // POST: Queries/Query5
        [HttpPost]
        [Route("Queries/5")]
        public ActionResult Query5(int postId)
        {
            var postResponse = _dataService.GetPostResponse(postId);
            return View(postResponse);

        }

        [HttpGet]
        [Route("Queries/6")]
        public IActionResult Query6()
        {
            return View();
        }

        // POST: Queries/Query2
        [HttpPost]
        [Route("Queries/6")]
        public ActionResult Query6(int userId)
        {
            var userResponse = _dataService.GetUserResponse(userId);
            return View(userResponse);

        }
    }
}