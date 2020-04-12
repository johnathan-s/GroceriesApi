using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceriesApi.Models
{
    public interface IGroceryDueDate
    {
        DateTime? sellByDate { get; set; }
    }
}
