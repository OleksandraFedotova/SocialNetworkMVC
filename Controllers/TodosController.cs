using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructuresAndLINQ;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkMVC.Services;

namespace SocialNetworkMVC.Controllers
{
    public class TodosController : Controller
    {
        private DataService dataService;
        private List<Todo> todos;

        public TodosController()
        {
            dataService = new DataService();
        }


        public IActionResult Index()
        {
            todos = dataService.GetTodos();
            return View(todos);
        }

        public IActionResult TodoById(int id)
        {
           Todo todo = dataService.GetTodoById(id);
            return View(todo);
        }
    }
}