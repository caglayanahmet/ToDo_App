using System;

namespace ToDo_App.Dtos
{
    public class NotificationDto
    {
       
        public int CategoryId { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public DateTime DateTime { get; set; }

    }
}