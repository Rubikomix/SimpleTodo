using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTodo.Models
{
    public class TodoViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        [Range(0, 10)]
        public int Priority { get; set; }
        [Required]
        public bool Done { get; set; }
        [Required]
        public int ProjectID { get; set; }
        public string AccentName { get; set; }
    }
}
