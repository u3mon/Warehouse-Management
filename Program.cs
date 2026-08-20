using System.Reflection.Metadata;

var service = new CategoriesServices();
var serviceProduct = new ProductcService();
var serviceWarehouse = new WarehousesServices();


while (true)
{
    System.Console.WriteLine("====================================================");
    System.Console.WriteLine(@"
    1 - Show all categories.
    2 - Add new category.
    3 - Update category description.
    4 - Delete category.
    5 - Show all products. 
    6 - Add new product. 
    7 - Update product.
    8 - Delete product.
    9 - Show all warehouses.
    10 - Add new warehouse.
    11 - Update warehouse.
    12 - Delete warehouse.
    0 - 🚷 Exit!");
    System.Console.WriteLine("====================================================");
    var action = Console.ReadLine();
    switch (action)
    {
         case "1":
            service.ShowAllCategories();
            break;
        
        case "2":
            System.Console.Write("Enter new category: ");
            var nc = Console.ReadLine();
            service.AddNewCategory(nc);
            break;
        
        case "3":
            System.Console.WriteLine("Enter category id: ");
            var id = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter new category description: ");
            var nd = Console.ReadLine();
            service.UpdateDescriptionOfCategory(id, nd);
            break;
        
        case "4":
            System.Console.WriteLine("Enter category id: ");
            var idd = Convert.ToInt32(Console.ReadLine());
            service.DeleteCategory(idd);
            break;
        case "5":
            serviceProduct.ShowAllProducts();
            break;
        case "6":
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

            serviceProduct.AddNewProduct(name, description, price, weight, categoryid);
            break;
        case "7":
            System.Console.Write("Enter product id: ");
            int pid = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter new product description: ");
            string newDescription = Console.ReadLine();
            serviceProduct.UpdateDescriptionOfProduct(pid, newDescription);
            break;
        case "8":
            System.Console.Write("Enter product id to delete: ");
            int di = Convert.ToInt32(Console.ReadLine());
            serviceProduct.DeleteProduct(di);
            break;
        case "9":
            serviceWarehouse.ShowAllWarehouses();
            break;
        case "10":
            System.Console.Write("Enter name of warehouse: ");
            string wname = Console.ReadLine();
            Console.Write("Enter adress of warehouse: ");
            string wadress = Console.ReadLine();
            Console.Write("is active 'true' or 'false': ");
            string isActive = Console.ReadLine();
            bool isactive;
            if(isActive == "true")
                isactive = true;
            else
                isactive = false;
            serviceWarehouse.AddNewWarehouse(wname, wadress, isactive);
            break;
        case "11":
            System.Console.Write("Enter warehouse's id to update: ");
            int wid = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter new warehouse's name: ");
            string newwname = Console.ReadLine();
            System.Console.Write("Enter new warehouse's adress");
            string newwadress = Console.ReadLine();
            System.Console.Write("Is active 'true' or 'false': ");
            string i = Console.ReadLine();
            bool newwisActive;
            if(i == "true")
                newwisActive = true;
            else
                newwisActive = false;
            serviceWarehouse.UpdateWarehouse(wid, newwname, newwadress, newwisActive);
            break;
        case "12":
            System.Console.Write("Enter warehouse's id to delete: ");
            var iddd = Convert.ToInt32(Console.ReadLine());
            serviceWarehouse.DeleteWarehouse(iddd);
            break;
        case "0":
            return;
    }
}