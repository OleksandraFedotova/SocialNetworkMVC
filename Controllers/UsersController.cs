using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructuresAndLINQ.DataStructures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkMVC.Services;

namespace SocialNetworkMVC.Controllers
{
    public class UsersController : Controller
    {
        private DataService dataService;
        private List<User> users;
        public UsersController()
        {
            dataService = new DataService();
        }

        // GET: Users
        public ActionResult Index()
        {
            users = dataService.GetUsers();
            
            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult UserById(int id)
        {
           User user = dataService.GetUserById(id);

            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}