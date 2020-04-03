using System;

namespace GroceriesApi.Models
{
    public interface IGroceryModel
    {
        public string id { get; set; }
        public string section { get; set; }
        string brand { get; set; }
        string grocery { get; set; }
        decimal quantity { get; set; }
    }
}