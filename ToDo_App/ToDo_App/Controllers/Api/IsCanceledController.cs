using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using ToDo_App.Models;

namespace ToDo_App.Controllers.Api
{
    [Authorize]
    public class IsCanceledController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public IsCanceledController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var todo = _context.Todos.FirstOrDefault(x => x.Id == id && x.TodoUserId == userId);

            todo.IsCanceled = true;

            _context.SaveChanges();

            return Ok();
        }
    }
}
