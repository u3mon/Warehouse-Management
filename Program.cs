var service = new ProductcService();
while (true)
{
    System.Console.WriteLine("====================================================");
    System.Console.WriteLine(@"
    1 - Show all products 
    2 - Add new product 
    3 - Update product
    4 - Delete product
    0 - Exit!");
    System.Console.WriteLine("====================================================");
    var action = Console.ReadLine();
    switch (action)
    {
        case "1":
            service.ShowAllProducts();
            break;
        case "2":
            System.Console.Write("Enter name of product: ");
            string? name = Console.ReadLine();
            System.Console.Write("Enter description of product: ");
            string? description = Console.ReadLine();
            System.Console.Write("Enter price of product: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            System.Console.Write("Enter weight of product: ");
            decimal weight = Convert.ToDecimal(Console.ReadLine());
            System.Console.Write("Enter categoryid of products: ");
            int categoryid = Convert.ToInt32(Console.ReadLine());

            service.AddNewProduct(name, description, price, weight, categoryid);
            break;
        case "3":
            System.Console.Write("Enter product id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter new product description: ");
            string newDescription = Console.ReadLine();
            service.UpdateDescriptionOfProduct(id, newDescription);
            break;
        case "4":
            System.Console.Write("Enter product id to delete: ");
            int di = Convert.ToInt32(Console.ReadLine());
            service.DeleteProduct(di);
            break;
        case "0":
            return;
    }
}