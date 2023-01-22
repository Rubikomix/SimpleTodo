using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTodo.Models
{
    public static class MappingHelpers
    {
        public static ProjectViewModel ToViewModel(this Project project)
        {
            return new()
            {
                ID = project.ID,
                Name = project.Name,
                Todos = project.Todos.Select(t => t.ToViewModel()).ToList(),
            };
        }

        public static TodoViewModel ToViewModel(this Todo todo)
        {
            return new() 
            {
                ID = todo.ID,
                Done = todo.Done,
                Priority = todo.Priority,
                ProjectID = todo.ProjectID,
                Text = todo.Text,
                AccentName = mapPriorityBootstrapColor(todo),
            };
        }

        private static string mapPriorityBootstrapColor(Todo todo)
        {
            if (todo.Done)
            {
                return "light";
            }
            return todo.Priority switch
            {
                < 5 => "success",
                < 10 => "warning",
                _ => "danger",
            };
        }
    }
}
