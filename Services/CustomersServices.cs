using Npgsql;

public class CustomersService: ICustomersService
{
    private string connectionString = "Host = localhost; Port = 5432; Database = WarehouseManegment; Username = postgres; password = 09108076pk";

    public void ShowAllCustomers()
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var command = new NpgsqlCommand("select * from customers order by id", conn);
        var data = command.ExecuteReader();
        while (data.Read())
        {
            System.Console.WriteLine();
            System.Console.WriteLine("id."+data["id"]+"  fullname: "+data["fullname"]+"  email: "+data["email"]+"  phone number: "+data["phonenumber"]+"   adress: "+data["address"]);
        }
    }
    public void AddNewCustomer(string fullname, string email, string phonenumber, string address)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var command = new NpgsqlCommand($"Insert into customers (fullname, email, phonenumber, address) values('{fullname}', '{email}', '{phonenumber}', '{address}')", conn);
        var res = command.ExecuteNonQuery();
        if(res > 0)
            System.Console.WriteLine("seccessfully added ✅");
        else
            System.Console.WriteLine("smth went wrong ❌");
    }
    public void UpdateCustomer(int id, string fullname, string email, string phonenumber, string address)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var command = new NpgsqlCommand($"Update customers set fullname = '{fullname}', email = '{email}', phonenumber = '{phonenumber}', address = '{address}' where id = {id}", conn);
        var res = command.ExecuteNonQuery();
        if(res > 0)
            System.Console.WriteLine("updated ✅");
        else
            System.Console.WriteLine("smth went wrong ❌");
    }
    public void DeleteCustomer(int id)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();
        var command = new NpgsqlCommand($"Delete from customers where id = {id}",conn);
        var res = command.ExecuteNonQuery();
        if(res > 0)
            System.Console.WriteLine("deleted ✅");
        else
            System.Console.WriteLine("smth went wrong ❌");
    }
}