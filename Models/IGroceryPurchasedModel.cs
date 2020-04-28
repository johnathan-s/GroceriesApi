using System;
using System.Collections.Generic;
using System.Text;

namespace GroceriesApi.Models
{
    public interface IGroceryPurchasedModel : IGroceryModel, IGroceryDueDate
    {
        decimal itemprice { get; set; }
        decimal totalprice { get; set; }
        GroceryStoreModel store { get; set; }
        DateTime date { get; set; }
        bool onsale { get; set; }
        string section { get; set; }

    }
}
