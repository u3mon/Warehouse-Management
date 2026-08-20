using Npgsql;

public class WarehousesServices : IWarehousesService
{
     string connectionString = "Host = localhost; Port = 5432; Database = WarehouseManegment; Username = postgres; password = 09108076pk";

    public void ShowAllWarehouses()
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var cmd = new NpgsqlCommand("select * from warehouses", conn);
        var data = cmd.ExecuteReader();
        while (data.Read())
        {
            System.Console.WriteLine();
            System.Console.WriteLine("id."+data["id"]+"   warehouse_name"+data["name"]+"   warehouse_adress"+data["adress"]+"   isactive: "+data["isactive"]);
        }
    }
    public void AddNewWarehouse(string name, string adress, bool isactive)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var command = new NpgsqlCommand($"insert into warehouses(name, adress, isactive) values('{name}', '{adress}', {isactive})", conn);
        var res = command.ExecuteNonQuery();
        if(res > 0)
            System.Console.WriteLine("seccessfully added ✅");
        else 
            System.Console.WriteLine("smth went wrong ❌");
    }

    public void UpdateWarehouse(int id, string name, string adress, bool isActive)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var command = new NpgsqlCommand($"update warehouses set name = '{name}', adress = '{adress}', isactive = {isActive} where id = {id}", conn);
        var res = command.ExecuteNonQuery();
        if(res > 0)
            System.Console.WriteLine("seccessfully added ✅");
        else 
            System.Console.WriteLine("smth went wrong ❌");
    }

    public void DeleteWarehouse(int id)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var command = new NpgsqlCommand($"delete from warehouse where id = {id}", conn);
        var res = command.ExecuteNonQuery();
        if(res > 0)
            System.Console.WriteLine("seccessfully added ✅");
        else 
            System.Console.WriteLine("smth went wrong ❌");
    }
}