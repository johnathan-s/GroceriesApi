using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GroceriesApi.Models
{
    public class GroceryListModel : IGroceryListModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public bool onlist { get; set; }
        public string section { get; set; }
        public string brand { get; set; }
        public string grocery { get; set; }
        public int quantity { get; set; }
        public decimal weight { get; set; }
    }
}
