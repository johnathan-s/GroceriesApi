namespace GroceriesApi.Models
{
    public interface IGroceryDatabaseSettings
    {
        string GroceryListCollectionName { get; set; }
        string GroceryPurchasedCollectionName { get; set; }
        string GroceryDueDateCollectionName { get; set; }
        string GroceryStoreCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}