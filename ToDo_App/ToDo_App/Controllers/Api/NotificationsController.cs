using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ToDo_App.Models;
using System.Data.Entity;
using ToDo_App.Dtos;

namespace ToDo_App.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNotifications()
        {
            var userId = User.Identity.GetUserId();
            var itemList = _context.Todos
                .Include(x=>x.Category)
                .Where(x => x.TodoUserId == userId && x.DateTime == DateTime.Today && !x.IsDone)
                .ToList();

            return itemList.Select(n=> new NotificationDto
            {
                CategoryId = n.CategoryId,
                Description = n.Description,
                Duration = n.Duration,
                DateTime = n.DateTime
            });
        }
    }
}
