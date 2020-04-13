using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceriesApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GroceriesApi.Models;

namespace GroceriesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryDueDateController : ControllerBase
    {
        private readonly GroceryDueDateService _groceryDueDateService;

        public GroceryDueDateController(GroceryDueDateService groceryDueDateService)
        {
            _groceryDueDateService = groceryDueDateService;
        }
        // GET: api/GroceryDueDate
        [HttpGet]
        public ActionResult<List<GroceryDueDateModel>> Get() =>
            _groceryDueDateService.Get();

        [HttpGet("{id:length(24)}", Name = "Get")]
        public ActionResult<GroceryDueDateModel> Get(string id)
        {
            var groceryLisDueDateItem = _groceryDueDateService.Get(id);

            if (groceryLisDueDateItem == null)
            {
                return NotFound();
            }
            return groceryLisDueDateItem;
        }

        // POST: api/GroceryDueDate
        [HttpPost]
        public ActionResult<GroceryDueDateModel> Create(GroceryDueDateModel groceryDueDateModel)
        {
            _groceryDueDateService.Create(groceryDueDateModel);

            return CreatedAtRoute("Get", new { id = groceryDueDateModel.id.ToString() }, groceryDueDateModel);
        }

        // PUT: api/GroceryDueDate/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, GroceryDueDateModel groceryDueDateModelIn)
        {
            var groceryDueDateModel = _groceryDueDateService.Get(id);

            if (groceryDueDateModel == null)
            {
                return NotFound();
            }

            _groceryDueDateService.Update(id, groceryDueDateModelIn);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var groceryDueDateModel = _groceryDueDateService.Get(id);

            if (groceryDueDateModel == null)
            {
                return NotFound();
            }

            _groceryDueDateService.Remove(groceryDueDateModel.id);

            return NoContent();
        }
    }
}
