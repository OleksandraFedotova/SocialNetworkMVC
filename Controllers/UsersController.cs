using Microsoft.AspNetCore.Mvc;
using SocialNetworkMVC.Models;
using SocialNetworkMVC.Services;
using System.Collections.Generic;

namespace SocialNetworkMVC.Controllers
{
    public class UsersController : Controller
    {
        private IDataService _dataService;
        private List<User> users;
        public UsersController(IDataService dataService)
        {
            _dataService = dataService;
        }

        // GET: Users
        public ActionResult Index()
        {
            users = _dataService.GetUsers();

            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult UserById(int id)
        {
            User user = _dataService.GetUserById(id);

            return View(user);
        }

    }
}