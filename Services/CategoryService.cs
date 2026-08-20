using Npgsql;

public class CategoriesServices
{
    string connectionString = 
    "Host = localhost; Port = 5432; Database = WarehouseManegment; Username = postgres; password = 09108076pk";
    
    public void ShowAllCategories()
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var cmd = new NpgsqlCommand("select * from categories", conn);
        var data = cmd.ExecuteReader();
        while (data.Read())
        {
            System.Console.WriteLine(data["id"]+" "+data["Name"]);
        }
    }
    public void AddNewCategory(string newCategory)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var command = new NpgsqlCommand($"insert into categories(name) values('{newCategory}')", conn);
        var res = command.ExecuteNonQuery();
        if(res > 0)
            System.Console.WriteLine("successfully added ✅");
        else
            System.Console.WriteLine("smth went wrong ❌");
    }
    public void UpdateDescriptionOfCategory(int id, string newDescription)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var cmd = new NpgsqlCommand($"update categories set description = '{newDescription}' where id = {id}", conn);
        var res = cmd.ExecuteNonQuery();
        if(res > 0)
           System.Console.WriteLine("updated ✅");
        else 
            System.Console.WriteLine("smth went wrong ❌");
    }
    public void DeleteCategory(int id)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var cmd = new NpgsqlCommand($"delete from categories where id = {id}", conn);
        var res = cmd.ExecuteNonQuery();
        if(res > 0)
            System.Console.WriteLine("deleted ✅");
        else
            System.Console.WriteLine("smth went wrong ❌");
    }
}
