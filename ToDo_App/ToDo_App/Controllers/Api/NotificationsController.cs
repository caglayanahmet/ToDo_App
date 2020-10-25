using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ToDo_App.Models;

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

        public IEnumerable<Todo> GetNotifications()
        {
            var userId = User.Identity.GetUserId();
            var itemList = _context.Todos
                .Where(x => x.TodoUserId == userId && x.DateTime == DateTime.Today && !x.IsDone)
                .ToList();

            return itemList;
        }
    }
}
