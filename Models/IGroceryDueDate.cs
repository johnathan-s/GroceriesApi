using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GroceriesApi.Models
{
    public interface IGroceryDueDate
    {
        string id { get; set; }
        string groceryid { get; set; }
        DateTime? sellByDate { get; set; }
    }
}
