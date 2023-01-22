using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleTodo.Models;

namespace SimpleTodo.Logic
{
    public interface ITodoManager
    {
        ITodoManager CheckTodo(int id);
        ITodoManager AddTodo(Todo todo);
        ITodoManager DeleteTodo(int id);
        Todo GetTodo(int id);
    }
}
