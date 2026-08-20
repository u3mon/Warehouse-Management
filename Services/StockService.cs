using Npgsql;

public class StockService: IStockService
{
    private string connectionString = "Host = localhost; Port = 5432; Database = WarehouseManegment; Username = postgres; password = 09108076pk";

    public void ShowAllStocks()
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var cmd = new NpgsqlCommand("select s.id as stock_id, p.name as product_name, w.name as warehouse_name, s.quantity as quantity from stock s join products p on p.id = s.productid join warehouses w on w.id = s.warehouseid order by stock_id;", conn);
        var data = cmd.ExecuteReader();
        while (data.Read())
        {
            System.Console.WriteLine();
            System.Console.WriteLine("id."+data["stock_id"]+"  product name: "+data["product_name"]+"  warehouse: "+data["warehouse_name"]+"  quantity: "+data["quantity"]);
        }
    }

    public void AddNewStock(int productId, int warehouseId, int quantity)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var command = new NpgsqlCommand($"insert into stock (productid, warehouseid, quantity) values({productId}, {warehouseId}, {quantity})", conn);
        var res = command.ExecuteNonQuery();
        if(res > 0)
            System.Console.WriteLine("successfully added ✅");
        else
            System.Console.WriteLine("smth went wrong ❌");
    }

    public void UpdateStock(int id, int productId, int warehouseId, int quantity)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var command = new NpgsqlCommand($"update stock set productid = {productId}, warehouseid = {warehouseId}, quantity = {quantity} where id = {id}", conn);
        var res = command.ExecuteNonQuery();
        if(res > 0)
            System.Console.WriteLine("updated ✅");
        else
            System.Console.WriteLine("smth went wrong ❌");
    }

    public void DeleteStock(int id)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var command = new NpgsqlCommand($"Delete from stock where id = {id}", conn);
        var res = command.ExecuteNonQuery();
        if(res > 0)
            System.Console.WriteLine("deleted ✅");
        else
            System.Console.WriteLine("smth went wrong ❌");
    }
}