using SimpleTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTodo.Logic
{
    public interface IProjectManager
    {
        IProjectManager AddProject(Project project);
        IList<Project> GetProjects();
        Project GetProject(int id);
        IProjectManager RemoveProject(int id);
        IProjectManager UpdateProject(Project project);
    }
}
