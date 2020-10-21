using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDo_App.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        public string Description { get; set; }
        
        public bool IsActive { get; set; }

        public ICollection<Todo> Todos { get; set; }
    }
}