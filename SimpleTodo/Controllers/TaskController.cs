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
        public IActionResult Index()
        {
            List<Project> tasks = new () {
                new() { ID = 1, Name="Projekt 1", Todos = new List<Todo>() },
                new() { ID = 2, Name = "Projekt 2", Todos = new List<Todo>() },
                new() { ID = 3, Name = "Projekt 3", Todos = new List<Todo>() },
            };
            return View(new ProjectListViewmodel() { Projects = tasks});
        }
    }
}
