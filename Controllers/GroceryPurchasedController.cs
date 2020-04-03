using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GroceriesApi.Models;
using GroceriesApi.Services;

namespace GroceriesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryPurchasedController : ControllerBase
    {
        private readonly GroceryPurchasedService _groceryPurchasedService;

        public GroceryPurchasedController(GroceryPurchasedService groceryPurchasedService)
        {
            _groceryPurchasedService = groceryPurchasedService;
        }

        [HttpGet]
        public ActionResult<List<GroceryPurchasedModel>> Get() =>
            _groceryPurchasedService.Get();

        [HttpGet("{id:length(24)}", Name = "GetGroceryPurchasedItem")]
        public ActionResult<GroceryPurchasedModel> Get(string id)
        {
            var groceryPurchasedItem = _groceryPurchasedService.Get(id);

            if (groceryPurchasedItem == null)
            {
                return NotFound();
            }

            return groceryPurchasedItem;
        }

        [HttpPost]
        public ActionResult<GroceryPurchasedModel> Create(GroceryPurchasedModel groceryPurchasedModel)
        {
            _groceryPurchasedService.Create(groceryPurchasedModel);

            return CreatedAtRoute("GetGroceryPurchasedItem", new { id = groceryPurchasedModel.id.ToString() }, groceryPurchasedModel);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, GroceryPurchasedModel groceryPurchasedModelIn)
        {
            var groceryPurchasedModel = _groceryPurchasedService.Get(id);

            if (groceryPurchasedModel == null)
            {
                return NotFound();
            }

            _groceryPurchasedService.Update(id, groceryPurchasedModelIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var groceryPurchasedModel = _groceryPurchasedService.Get(id);

            if (groceryPurchasedModel == null)
            {
                return NotFound();
            }

            _groceryPurchasedService.Remove(groceryPurchasedModel.id);

            return NoContent();
        }
    }
}
