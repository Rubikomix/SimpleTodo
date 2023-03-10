using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTodo.Models
{
    public class Project
    {
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Todo> Todos { get; set; }
    }
}
