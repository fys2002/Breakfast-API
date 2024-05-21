public class BreakfastItem  
{  
    public int Id { get; set; }  
    public string Name { get; set; }  
public decimal Price { get; set; }
}  


using Microsoft.AspNetCore.Mvc;  
using System.Collections.Generic;  
// Если используется база данных, необходимо ввести соответствующее пространство имен уровня доступа к данным.
  
namespace BreakfastApi.Controllers  
{  
    [ApiController]  
    [Route("[controller]")]  
    public class BreakfastController : ControllerBase  
    {  
        // Имитировать хранение данных
        private static List<BreakfastItem> _breakfastItems = new List<BreakfastItem>  
        {  
            new BreakfastItem { Id = 1, Name = " fried egg ", Price = 10.5m },  
            new BreakfastItem { Id = 2, Name = " toast ", Price = 5.0m },  
        };  
  
        // GET api/breakfast  
        [HttpGet]  
        public IActionResult Get()  
        {  
            return Ok(_breakfastItems);  
        }  
  
        // GET api/breakfast/5  
        [HttpGet("{id}")]  
        public IActionResult Get(int id)  
        {  
            var item = _breakfastItems.Find(x => x.Id == id);  
            if (item == null)  
            {  
                return NotFound();  
            }  
            return Ok(item);  
        }  
  
        // POST api/breakfast  
        [HttpPost]  
        public IActionResult Post([FromBody] BreakfastItem item)  
        {  
            _breakfastItems.Add(item);  
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);  
        }  
  
        // PUT api/breakfast/5  
        [HttpPut("{id}")]  
        public IActionResult Put(int id, [FromBody] BreakfastItem item)  
        {  
            var existingItem = _breakfastItems.Find(x => x.Id == id);  
            if (existingItem == null)  
            {  
                return NotFound();  
            }  
            existingItem.Name = item.Name;  
            existingItem.Price = item.Price;  
            return NoContent();  
        }  
  
        // DELETE api/breakfast/5  
        [HttpDelete("{id}")]  
        public IActionResult Delete(int id)  
        {  
            var item = _breakfastItems.Find(x => x.Id == id);  
            if (item == null)  
            {  
                return NotFound();  
            }  
            _breakfastItems.Remove(item);  
            return NoContent();  
        }  
    }  
}
