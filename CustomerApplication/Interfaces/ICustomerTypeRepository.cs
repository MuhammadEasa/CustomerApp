using CustomerApplication.DB;

namespace CustomerApplication.Interfaces
{
    public interface ICustomerTypeRepository
    {
        void SaveCustomerType(CustomerType customertype);
        IEnumerable<CustomerType> GetAllCustomerTypes();
        CustomerType GetCustomerType(long id);
        void DeleteCustomerType(long id);
        void UpdateCustomerType(CustomerType customerType);
    }
}
