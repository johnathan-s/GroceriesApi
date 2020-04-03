using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceriesApi.Models;

namespace GroceriesApi.Services
{
    public class GroceryListService
    {

        private readonly IMongoCollection<GroceryListModel> _groceryListModels;

        public GroceryListService(IGroceryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _groceryListModels = database.GetCollection<GroceryListModel>(settings.GroceryListCollectionName);
        }

        public List<GroceryListModel> Get() =>
            _groceryListModels.Find(groceryListModel => true).ToList();

        public GroceryListModel Get(string id) =>
            _groceryListModels.Find<GroceryListModel>(groceryListModel => groceryListModel.id == id).FirstOrDefault();

        public GroceryListModel Create(GroceryListModel groceryListModel)
        {
            _groceryListModels.InsertOne(groceryListModel);
            return groceryListModel;
        }

        public void Update(string id, GroceryListModel groceryListModelIn) =>
            _groceryListModels.ReplaceOne(groceryListModel => groceryListModel.id == id, groceryListModelIn);

        public void Remove(GroceryListModel groceryListModelIn) =>
            _groceryListModels.DeleteOne(groceryListModel => groceryListModel.id == groceryListModelIn.id);

        public void Remove(string id) =>
            _groceryListModels.DeleteOne(groceryListModel => groceryListModel.id == id);
    }
}

