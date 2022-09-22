using CustomerApplication.DB;

namespace CustomerApplication.Interfaces
{

        public interface ICustomerRepository
        {
            void SaveCustomer(tblCustomer customer);
            IEnumerable<tblCustomer> GetAllCustomers();
            tblCustomer GetCustomer(long id);
            void DeleteCustomer(long id);
            void UpdateCustomer(tblCustomer customer);
        }
}
