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
    public class GroceryStoreController : ControllerBase
    {

        private readonly GroceryStoreService _groceryStoreService;

        public GroceryStoreController(GroceryStoreService groceryStoreService)
        {
            _groceryStoreService = groceryStoreService;
        }

        [HttpGet]
        public ActionResult<List<GroceryStoreModel>> Get() =>
            _groceryStoreService.Get();

        [HttpGet("{id:length(24)}", Name = "GetGroceryStore")]
        public ActionResult<GroceryStoreModel> Get(string id)
        {
            var groceryStoreItem = _groceryStoreService.Get(id);

            if (groceryStoreItem == null)
            {
                return NotFound();
            }

            return groceryStoreItem;
        }

        [HttpPost]
        public ActionResult<GroceryStoreModel> Create(GroceryStoreModel groceryStoreModel)
        {
            List<GroceryStoreModel> currentList = _groceryStoreService.Get();

            foreach(GroceryStoreModel listItem in currentList)
            {
                // checking for duplicate grocery
                if (groceryStoreModel.storename.ToUpper().Trim() == listItem.storename.ToUpper().Trim())
                {
                    return Conflict();
                }
            }
            _groceryStoreService.Create(groceryStoreModel);

            return CreatedAtRoute("GetGroceryStore", new { id = groceryStoreModel.id.ToString() }, groceryStoreModel);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, GroceryStoreModel groceryStoreModelIn)
        {
            var groceryStoreModel = _groceryStoreService.Get(id);

            if (groceryStoreModel == null)
            {
                return NotFound();
            }

            _groceryStoreService.Update(id, groceryStoreModelIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var groceryStoreModel = _groceryStoreService.Get(id);

            if (groceryStoreModel == null)
            {
                return NotFound();
            }

            _groceryStoreService.Remove(groceryStoreModel.id);

            return NoContent();
        }
    }
}
