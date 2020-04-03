using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GroceriesApi.Models
{
    public class GroceryPurchasedModel : IGroceryPurchasedModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public decimal itemprice { get; set; }
        public decimal totalprice { get; set; }
        public string section { get; set; }
        public string store { get; set; }
        public string brand { get; set; }
        public string grocery { get; set; }
        public decimal quantity { get; set; }
        public DateTime date { get; set; }
    }
}
