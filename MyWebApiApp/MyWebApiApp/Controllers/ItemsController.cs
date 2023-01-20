using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public static List<Item> items = new List<Item>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var item = items.SingleOrDefault(i => i.Id == Guid.Parse(id));
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(ItemVM itemVM)
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                Name = itemVM.Name,
                UnitPrice = itemVM.UnitPrice,
            };
            items.Add(item);
            return Ok(new
            {
                Success = true, Data = item
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, Item itemToUpdate)
        {
            try
            {
                var item = items.SingleOrDefault(i => i.Id == Guid.Parse(id));
                if (item == null)
                {
                    return NotFound();
                }
                if (id != item.Id.ToString())
                {
                    return BadRequest();
                }
                item.Name = itemToUpdate.Name;
                item.UnitPrice = itemToUpdate.UnitPrice;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                var item = items.SingleOrDefault(i => i.Id == Guid.Parse(id));
                if (item == null)
                {
                    return NotFound();
                }
                items.Remove(item);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
