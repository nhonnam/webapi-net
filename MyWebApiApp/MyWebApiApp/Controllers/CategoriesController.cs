using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CategoriesController(MyDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var cateList = _context.Categories.ToList();
            return Ok(cateList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category != null) return Ok(category);
            else return NotFound();
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateNew(CateModel model)
        {
            try
            {
                var category = new Category { Name = model.Name };
                _context.Add(category);
                _context.SaveChanges();
                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCateById(int id, CateModel model)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category != null)
            {
                category.Name = model.Name;
                _context.SaveChanges();
                return NoContent();
            }
            else return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category != null) {
                _context.Remove(category);
                _context.SaveChanges();
                return Ok();
            }
            else return NotFound();
        }
    }
}
