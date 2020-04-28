using System;

namespace GroceriesApi.Models
{
    public interface IGroceryModel
    {
        public string id { get; set; }
        public string grocery { get; set; }
    }
}