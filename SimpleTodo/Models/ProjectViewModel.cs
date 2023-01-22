using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTodo.Models
{
    public class ProjectViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        public ICollection<TodoViewModel> Todos { get; set; }
    }
}
