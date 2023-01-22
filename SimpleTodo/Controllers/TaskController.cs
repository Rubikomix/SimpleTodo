using Microsoft.AspNetCore.Mvc;
using SimpleTodo.Logic;
using SimpleTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTodo.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectManager _projectManager;

        public ProjectController(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }

        public IActionResult Index()
        {
            var projects = _projectManager.GetProjects();
            return View(new ProjectListViewmodel() { Projects = projects});
        }

        public IActionResult Details(int id)
        {
            var task = _projectManager.GetProject(id);
            if (task is null)
            {
                return NotFound();
            }
            return View(task.ToViewModel());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([Bind("Name")]Project project)
        {
            _projectManager.AddProject(project);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var project = _projectManager.GetProject(id);
            return View(project.ToViewModel());
        }

        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            _projectManager.RemoveProject(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
