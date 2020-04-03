using System;
using System.Collections.Generic;
using System.Text;

namespace GroceriesApi.Models
{
    public interface IGroceryPurchasedModel : IGroceryModel
    {
        decimal itemprice { get; set; }
        decimal totalprice { get; set; }
        string store { get; set; }
        DateTime date { get; set; }
    }
}
