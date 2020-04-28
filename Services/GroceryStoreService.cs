using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceriesApi.Models;

namespace GroceriesApi.Services
{
    public class GroceryStoreService
    {

        private readonly IMongoCollection<GroceryStoreModel> _groceryStoreModels;

        public GroceryStoreService(IGroceryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _groceryStoreModels = database.GetCollection<GroceryStoreModel>(settings.GroceryStoreCollectionName);
        }

        public List<GroceryStoreModel> Get() =>
            _groceryStoreModels.Find(groceryStoreModel => true).ToList();

        public GroceryStoreModel Get(string id) =>
            _groceryStoreModels.Find<GroceryStoreModel>(groceryStoreModel => groceryStoreModel.id == id).FirstOrDefault();

        public GroceryStoreModel Create(GroceryStoreModel groceryStoreModel)
        {
            _groceryStoreModels.InsertOne(groceryStoreModel);
            return groceryStoreModel;
        }

        public void Update(string id, GroceryStoreModel groceryStoreModelIn) =>
            _groceryStoreModels.ReplaceOne(groceryStoreModel => groceryStoreModel.id == id, groceryStoreModelIn);

        public void Remove(GroceryStoreModel groceryStoreModelIn) =>
            _groceryStoreModels.DeleteOne(groceryStoreModel => groceryStoreModel.id == groceryStoreModelIn.id);

        public void Remove(string id) =>
            _groceryStoreModels.DeleteOne(groceryStoreModel => groceryStoreModel.id == id);
    }
}

