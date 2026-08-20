public interface IWarehousesService
{
    void ShowAllWarehouses();
    void AddNewWarehouse(string name, string adress, bool isactive);
    void UpdateWarehouse(int id, string name, string adress, bool isActive);
    void DeleteWarehouse(int id);
}