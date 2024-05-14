using kodutoo.Data;
using kodutoo.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kodutoo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Auto> GetAutod()
        {
            var autod = _context.Autod.ToList();
            return autod;
        }
        [HttpPost]
        public ActionResult<List<Auto>> PostAutod([FromBody] Auto auto)
        {
            _context.Autod.Add(auto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAutod),new {id = auto.Id}, auto);
        }
        [HttpDelete("{id}")]
        public List<Auto> DeleteAutod(int id)
        {
            var auto = _context.Autod.Find(id);

            if (auto == null)
            {
                return _context.Autod.ToList();
            }

            _context.Autod.Remove(auto);
            _context.SaveChanges();
            return _context.Autod.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Auto> GetAutod(int id)
        {
            var auto = _context.Autod.Find(id);

            if (auto == null)
            {
                return NotFound();
            }

            return auto;
        }
        [HttpPut("{id}")]
        public ActionResult<List<Auto>> PutAuto(int id, [FromBody] Auto updatedAuto)
        {
            var Auto = _context.Autod.Find(id);

            if (Auto == null)
            {
                return NotFound();
            }

            Auto.Mark = updatedAuto.Mark;
            Auto.Mudel = updatedAuto.Mudel;

            _context.Autod.Update(Auto);
            _context.SaveChanges();

            return Ok(_context.Autod);
        }
    }
}
