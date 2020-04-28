using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceriesApi.Models
{
    interface IGroceryStoreModel
    {
        string id { get; set; }
        string storename { get; set; }
    }
}
