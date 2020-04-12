using System;

namespace GroceriesApi.Models
{
    public interface IGroceryModel
    {
        string id { get; set; }
        string grocery { get; set; }
    }
}