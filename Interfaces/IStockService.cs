public interface IStockService
{
    void ShowAllStocks();
    void AddNewStock(int productId, int warehouseId, int quantity);
    void UpdateStock(int id, int productId, int warehouseId, int quantity);
    void DeleteStock(int id);

}