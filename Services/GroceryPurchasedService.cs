using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceriesApi.Models;

namespace GroceriesApi.Services
{
    public class GroceryPurchasedService
    {

        private readonly IMongoCollection<GroceryPurchasedModel> _groceryPurchasedModels;

        public GroceryPurchasedService(IGroceryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _groceryPurchasedModels = database.GetCollection<GroceryPurchasedModel>(settings.GroceryPurchasedCollectionName);
        }

        public List<GroceryPurchasedModel> Get() =>
            _groceryPurchasedModels.Find(groceryPurchasedModel => true).ToList();

        public GroceryPurchasedModel Get(string id) =>
            _groceryPurchasedModels.Find<GroceryPurchasedModel>(groceryPurchasedModel => groceryPurchasedModel.id == id).FirstOrDefault();

        public List<GroceryPurchasedModel> Get(DateTime purchasedDate) =>
            _groceryPurchasedModels.Find(groceryPurchasedModel => groceryPurchasedModel.date == purchasedDate).ToList();

        public List<GroceryPurchasedModel> Get(DateTime purchasedDateStart, DateTime PurchasedDateEnd) =>
            _groceryPurchasedModels.Find(groceryPurchasedModel => (groceryPurchasedModel.date >= purchasedDateStart && groceryPurchasedModel.date <= PurchasedDateEnd)).ToList();

        public GroceryPurchasedModel Create(GroceryPurchasedModel groceryPurchasedModel)
        {
            _groceryPurchasedModels.InsertOne(groceryPurchasedModel);
            return groceryPurchasedModel;
        }

        public void Update(string id, GroceryPurchasedModel groceryPurchasedModelIn) =>
            _groceryPurchasedModels.ReplaceOne(groceryPurchasedModel => groceryPurchasedModel.id == id, groceryPurchasedModelIn);

        public void Remove(GroceryPurchasedModel groceryPurchasedModelIn) =>
            _groceryPurchasedModels.DeleteOne(groceryPurchasedModel => groceryPurchasedModel.id == groceryPurchasedModelIn.id);

        public void Remove(string id) =>
            _groceryPurchasedModels.DeleteOne(groceryPurchasedModel => groceryPurchasedModel.id == id);
    }

}
