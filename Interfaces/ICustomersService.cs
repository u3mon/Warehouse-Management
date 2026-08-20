public interface ICustomersService
{
    void ShowAllCustomers();
    void AddNewCustomer(string fullname, string email, string phonenumber, string address);
    void UpdateCustomer(int id, string fullname, string email, string phonenumber, string address);
    void DeleteCustomer(int id);
}