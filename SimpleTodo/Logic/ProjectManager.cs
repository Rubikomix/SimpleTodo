using SimpleTodo.Database;
using SimpleTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTodo.Logic
{
    public class ProjectManager : IProjectManager
    {
        private SimpleTodoContext _context;

        public ProjectManager(SimpleTodoContext context)
        {
            _context = context;
        }

        public IProjectManager AddProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return this;
        }

        public Project GetProject(int id)
        {
            var project = _context.Projects.Single(p => p.ID == id);
            _context.Entry(project)
                .Collection(p => p.Todos)
                .Load();
            return project;
        }

        public IList<Project> GetProjects()
        {
            return _context.Projects.ToList();
        }

        public IProjectManager RemoveProject(int id)
        {
            var project = _context.Projects.Single(p => p.ID == id);
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return this;
        }

        public IProjectManager UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
            return this;
        }
    }
}
