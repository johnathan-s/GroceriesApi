using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
        public GroceryStoreModel store { get; set; }
        public string brand { get; set; }
        public string grocery { get; set; }
        public decimal quantity { get; set; }
        public DateTime date { get; set; }
        public bool onsale { get; set; }
        public DateTime? sellByDate { get; set; }
        public string section { get; set; }
    }
}
