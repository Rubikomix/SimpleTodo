using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTodo.Models
{
    public class ProjectAddViewModel
    {
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
    }
}
