using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorController : BaseApiController
    {
        private readonly DataContext _context;

        public ErrorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("not-found")]
        public ActionResult<Campground> GetNotFound()
        {
            var entity = _context.Campgrounds.Find(-1);

            if(entity == null)  return NotFound();

            return Ok(entity);
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var entity = _context.Campgrounds.Find(-1).ToString();

            return entity;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("Not a good request");
        }
    }
}
