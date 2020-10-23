using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using ToDo_App.Dtos;
using ToDo_App.Models;

namespace ToDo_App.Controllers.Api
{
    [Authorize]
    public partial class IsDoneController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public IsDoneController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult IsDone(IsDoneDto dto)
        {
            var userId = User.Identity.GetUserId();
            var todoItem = _context.Todos.Where(x => x.TodoUserId == userId).FirstOrDefault(x => x.Id == dto.TodoId);

            if (todoItem.TodoUserId==userId && todoItem.IsDone==true)
                return BadRequest("Task is done already");

            todoItem.IsDone = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}