using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceriesApi.Models
{
    public class GroceryDatabaseSettings : IGroceryDatabaseSettings
    {
        public string GroceryListCollectionName { get; set; }
        public string GroceryPurchasedCollectionName { get; set; }
        public string GroceryDueDateCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
