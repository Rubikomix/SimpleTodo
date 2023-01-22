using Microsoft.AspNetCore.Mvc;
using SimpleTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTodo.Controllers
{
    public class ProjectController : Controller
    {
        static Random radom = new();
        static List<Project> tasks = new()
        {
            new() { ID = 1, Name = "Projekt 1", Todos = new List<Todo>() {
                new() {ID = 1, Text = "Zadanie1", Priority = 10, Done = false} }
            },
            new() { ID = 2, Name = "Projekt 2", Todos = new List<Todo>() },
            new() { ID = 3, Name = "Projekt 3", Todos = new List<Todo>() },
        };

        public IActionResult Index()
        {
            return View(new ProjectListViewmodel() { Projects = tasks});
        }

        public IActionResult Details(int id)
        {
            var task = tasks.Where(t => t.ID == id).FirstOrDefault();
            if (task is null)
            {
                return NotFound();
            }
            return View(task);
        }

        public IActionResult Add(Project project)
        {
            tasks.Add(new() { ID = radom.Next(), Name = project.Name });
            return RedirectToAction(nameof(Index));
        }
    }
}
