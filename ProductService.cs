using Npgsql;

public class ProductcService
{
     string connectionString = 
    "Host = localhost; Port = 5432; Database = WarehouseManegment; Username = postgres; password = 09108076pk";
    
    public void ShowAllProducts()
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var cmd = new NpgsqlCommand("select p.id AS product_id, p.name AS product_name, p.price AS product_price, c.name AS category_name from products p join categories c on p.categoryid = c.id;", conn);
        var data = cmd.ExecuteReader();
        while (data.Read())
        {
            System.Console.WriteLine();
            System.Console.WriteLine("id."+data["product_id"]+"  product: "+data["product_name"]+"   price: "+data["product_price"]+"  category: "+data["category_name"]);
        }
    }
    
    public void AddNewProduct(string newName, string newDescription, decimal newPrice, decimal newWeight, int newCategoryid)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var command = new NpgsqlCommand($"insert into products(name, description, price, weight, categoryid) values('{newName}', '{newDescription}', {newPrice}, {newWeight}, {newCategoryid})", conn);
        var res = command.ExecuteNonQuery();
        if(res > 0)
            System.Console.WriteLine("successfully added ✅");
        else
            System.Console.WriteLine("smth went wrong ❌");
    }

    public void UpdateDescriptionOfProduct(int id, string newDescription)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var command = new NpgsqlCommand($"update products set description = '{newDescription}' where id = {id}", conn);
        var res = command.ExecuteNonQuery();
        if(res > 0)
            System.Console.WriteLine("updated ✅");
        else 
            System.Console.WriteLine("smth went wrong ❌");
    }

    public void DeleteProduct(int id)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var command = new NpgsqlCommand($"Delete from products where id = {id}", conn);
        var res = command.ExecuteNonQuery();
        if(res > 0)
            System.Console.WriteLine("deleted ✅");
        else 
            System.Console.WriteLine("smth went wrong ❌");
    }
}