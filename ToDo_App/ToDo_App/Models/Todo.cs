using System;
using System.ComponentModel.DataAnnotations;
using ToDo_App.ViewModels;

namespace ToDo_App.Models
{
    public class Todo
    {
        
        public ApplicationUser TodoUser { get; set; }

        [Required]
        public string TodoUserId { get; set; }

        public int Id { get; set; }

        [Display(Name = "Category Name")]
        [Required]
        public int CategoryId { get; set; }

        [Display(Name = "What To Do")]
        [Required]
        public string Description { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        [FutureDateTime]
        public DateTime DateTime { get; set; }
        
        public bool IsDone { get; set; }

        public bool IsCanceled { get; set; }

        
        public Category Category { get; set; }
    }
}