using SimpleTodo.Database;
using SimpleTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTodo.Logic
{
    public class TodoManager : ITodoManager
    {
        private readonly SimpleTodoContext _context;

        public TodoManager(SimpleTodoContext context)
        {
            _context = context;
        }

        public ITodoManager CheckTodo(int id)
        {
            var todo = _context.Todos.Single(t => t.ID == id);
            todo.Done = true;
            _context.SaveChanges();
            return this;
        }

        public ITodoManager AddTodo(Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return this;
        }

        public ITodoManager DeleteTodo(int id)
        {
            throw new NotImplementedException();
        }

        public Todo GetTodo(int id)
        {
            var todo = _context.Todos.Single(t => t.ID == id);
            _context.Entry(todo).Reference(t => t.Project).Load();
            return todo;
        }
    }
}
