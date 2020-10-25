using System;
using System.Collections.Generic;
using ToDo_App.Models;

namespace ToDo_App.ViewModels
{
    public class TodosFormViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public int Duration { get; set; }
        public int CategoryId { get; set; }
        public bool IsDone { get; set; }
        public bool IsCanceled { get; set; }
        public string TodoUserId { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}