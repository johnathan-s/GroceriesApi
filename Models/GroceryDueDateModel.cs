using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GroceriesApi.Models
{
    public class GroceryDueDateModel : IGroceryDueDate, IGroceryModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string grocery { get; set; }
        public DateTime? sellByDate { get; set; }
    }
}
