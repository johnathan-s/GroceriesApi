using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceriesApi.Models
{
    public class GroceryDueDate : IGroceryDueDate, IGroceryModel
    {
        
        public string id { get; set; }
        public string grocery { get; set; }
        public DateTime? sellByDate { get; set; }
    }
}
