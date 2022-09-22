using CustomerApplication.DB;
using CustomerApplication.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerApplication.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerContext context;
        private DbSet<tblCustomer> customerEntity;
        ICustomerRepository _customerRepository;
        public CustomerRepository(CustomerContext context)
        {
            this.context = context;
            customerEntity = context.Set<tblCustomer>();
        }
        public void DeleteCustomer(long id)
        {
            tblCustomer customer = GetCustomer(id);
            customerEntity.Remove(customer);
            context.SaveChanges();
        }

        public IEnumerable<tblCustomer> GetAllCustomers()
        {
            return customerEntity.AsEnumerable();
        }

        public tblCustomer GetCustomer(long id)
        {
            return customerEntity.SingleOrDefault(s => s.Id == id);
        }

        public void SaveCustomer(tblCustomer customer)
        {
            context.Entry(customer).State = EntityState.Added;
            context.SaveChanges();
        }

        public void UpdateCustomer(tblCustomer customer)
        {
            context.SaveChanges();
        }
    }
}
