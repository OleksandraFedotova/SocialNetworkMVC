using Microsoft.AspNetCore.Mvc;
using SocialNetworkMVC.Models;
using SocialNetworkMVC.Services;
using System.Collections.Generic;

namespace SocialNetworkMVC.Controllers
{
    public class TodosController : Controller
    {
        private IDataService _dataService;
        private List<Todo> todos;

        public TodosController(IDataService dataService)
        {
            _dataService = dataService;
        }


        public IActionResult Index()
        {
            todos = _dataService.GetTodos();
            return View(todos);
        }

        public IActionResult TodoById(int id)
        {
           Todo todo = _dataService.GetTodoById(id);
            return View(todo);
        }
    }
}