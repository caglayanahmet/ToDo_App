using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo_App.Models
{
    public class Todo
    {
        [Required]
        public ApplicationUser TodoUser { get; set; }

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
        public DateTime DateTime { get; set; }
        
        public bool IsDone { get; set; }

        [Required]
        public Category Category { get; set; }
    }
}