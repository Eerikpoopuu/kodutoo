using kodutoo.Data;
using kodutoo.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kodutoo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RentijaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RentijaController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Rentija> GetRentijad()
        {
            var rentijad = _context.Rentijad.ToList();
            return rentijad;
        }

        [HttpPost]
        public ActionResult<List<Rentija>> PostRentija([FromBody] Rentija rentija)
        {
            rentija.dateTime = DateTime.Now;
            _context.Rentijad.Add(rentija);
            _context.SaveChanges();
            var auto = _context.Autod.Include(a => a.Rentijad).SingleOrDefault(a => a.Id == rentija.AutoId);

            if (auto == null)
            {
                return NotFound();
            }
            return Ok(auto.Rentijad);
        }

        [HttpDelete("{id}")]
        public List<Rentija> DeleteRentija(int id)
        {
            var comment = _context.Rentijad.Find(id);

            if (comment == null)
            {
                return _context.Rentijad.ToList();
            }

            _context.Rentijad.Remove(comment);
            _context.SaveChanges();
            return _context.Rentijad.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Rentija> GetRentija(int id)
        {
            var comment = _context.Rentijad.Find(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        [HttpPut("{id}")]
        public ActionResult<List<Rentija>> PutRentija(int id, [FromBody] Rentija updatedRentija)
        {
            var rentija = _context.Rentijad.Find(id);

            if (rentija == null)
            {
                return NotFound();
            }

            rentija.nimi = updatedRentija.nimi;

            _context.Rentijad.Update(rentija);
            _context.SaveChanges();

            return Ok(_context.Rentijad);
        }
    }
}
