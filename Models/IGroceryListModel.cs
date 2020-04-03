using System;
using System.Collections.Generic;
using System.Text;

namespace GroceriesApi.Models
{
    public interface IGroceryListModel : IGroceryModel
    {
        bool onlist { get; set; }
    }
}
