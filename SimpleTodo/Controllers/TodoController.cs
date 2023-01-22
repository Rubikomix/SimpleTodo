using Microsoft.AspNetCore.Mvc;
using SimpleTodo.Logic;
using SimpleTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTodo.Controllers
{
    public class TodoController : Controller
    {
        private ITodoManager _todoManager;

        public TodoController(ITodoManager todoManager)
        {
            _todoManager = todoManager;
        }
        public IActionResult CheckTodo(int id)
        {
            var todo = _todoManager.GetTodo(id);
            _todoManager.CheckTodo(id);
            return redirectToProject(todo.ProjectID);
        }

        public IActionResult Add([Bind("Text", "Priority", "ProjectID")]Todo todo)
        {
            _todoManager.AddTodo(todo);
            return redirectToProject(todo.ProjectID);
        }

        private IActionResult redirectToProject(int projectId)
        {
            return RedirectToAction(nameof(ProjectController.Details), "Project", new { id = projectId });
        }
    }
}
