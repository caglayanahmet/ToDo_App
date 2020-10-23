using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ToDo_App.Models;

namespace ToDo_App.ViewModels
{
    public class TodosViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public int Id { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [FutureDateTime]
        public DateTime DateTime { get; set; }

        [Required]
        public bool IsDone { get; set; }

        [Required]
        public int CategoryId { get; set; }

        
    }
}