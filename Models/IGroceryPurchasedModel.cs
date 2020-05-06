using System;
using System.Collections.Generic;
using System.Text;

namespace GroceriesApi.Models
{
    public interface IGroceryPurchasedModel : IGroceryModel
    {
        public string id { get; set; }       
        public string groceryid { get; set; }
        public decimal itemprice { get; set; }
        public decimal totalprice { get; set; }
        public GroceryStoreModel store { get; set; }
        public string brand { get; set; }
        public string section { get; set; }
        public int quantity { get; set; }
        public decimal weight { get; set; }
        public DateTime date { get; set; }
        public bool onsale { get; set; }
 
    }
}
