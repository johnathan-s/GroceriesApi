using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceriesApi.Models
{
    public class GroceryStoreModel : IGroceryStoreModel
    {
        public string id { get; set; }
        public string storename { get; set; }
    }
}
