using System;
using System.Collections.Generic;
using System.Text;

namespace GroceriesApi.Models
{
    public interface IGroceryListModel : IGroceryModel
    {
        bool onlist { get; set; }
        string section { get; set; }
        string brand { get; set; }
        decimal quantity { get; set; }
    }
}
