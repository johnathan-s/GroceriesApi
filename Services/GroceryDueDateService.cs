using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceriesApi.Models;

namespace GroceriesApi.Services
{
    public class GroceryDueDateService
    {

        private readonly IMongoCollection<GroceryDueDateModel> _groceryDueDatetModels;

        public GroceryDueDateService(IGroceryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _groceryDueDatetModels = database.GetCollection<GroceryDueDateModel>(settings.GroceryDueDateCollectionName);
        }

        public List<GroceryDueDateModel> Get() =>
            _groceryDueDatetModels.Find(GroceryDueDateModel => true).ToList();

        public GroceryDueDateModel Get(string id) =>
            _groceryDueDatetModels.Find<GroceryDueDateModel>(GroceryDueDateModel => GroceryDueDateModel.id == id).FirstOrDefault();

        public GroceryDueDateModel Create(GroceryDueDateModel groceryDueDateModel)
        {
            _groceryDueDatetModels.InsertOne(groceryDueDateModel);
            return groceryDueDateModel;
        }

        public void Update(string id, GroceryDueDateModel groceryDueDateModelIn) =>
            _groceryDueDatetModels.ReplaceOne(groceryDueDateModel => groceryDueDateModel.id == id, groceryDueDateModelIn);

        public void Remove(GroceryDueDateModel groceryDueDateModelIn) =>
            _groceryDueDatetModels.DeleteOne(groceryDueDateModel => groceryDueDateModel.id == groceryDueDateModelIn.id);

        public void Remove(string id) =>
            _groceryDueDatetModels.DeleteOne(groceryDueDateModel => groceryDueDateModel.id == id);
    }
}

