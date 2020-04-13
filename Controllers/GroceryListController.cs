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
    public class GroceryListController : ControllerBase
    {

        private readonly GroceryListService _groceryListService;

        public GroceryListController(GroceryListService groceryListService)
        {
            _groceryListService = groceryListService;
        }

        [HttpGet]
        public ActionResult<List<GroceryListModel>> Get() =>
            _groceryListService.Get();

        [HttpGet("{id:length(24)}", Name = "GetGroceryListItem")]
        public ActionResult<GroceryListModel> Get(string id)
        {
            var groceryListItem = _groceryListService.Get(id);

            if (groceryListItem == null)
            {
                return NotFound();
            }

            return groceryListItem;
        }

        [HttpPost]
        public ActionResult<GroceryListModel> Create(GroceryListModel groceryListModel)
        {
            List<GroceryListModel> currentList = _groceryListService.Get();

            foreach(GroceryListModel listItem in currentList)
            {
                // checking for duplicate grocery
                if (groceryListModel.grocery.ToUpper().Trim() == listItem.grocery.ToUpper().Trim())
                {
                    return Conflict();
                }
            }
            _groceryListService.Create(groceryListModel);

            return CreatedAtRoute("GetGroceryListItem", new { id = groceryListModel.id.ToString() }, groceryListModel);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, GroceryListModel groceryListModelIn)
        {
            var groceryListModel = _groceryListService.Get(id);

            if (groceryListModel == null)
            {
                return NotFound();
            }

            _groceryListService.Update(id, groceryListModelIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var groceryListModel = _groceryListService.Get(id);

            if (groceryListModel == null)
            {
                return NotFound();
            }

            _groceryListService.Remove(groceryListModel.id);

            return NoContent();
        }
    }
}
