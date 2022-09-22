using CustomerApplication.DB;
using CustomerApplication.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerApplication.Data
{
    public class CustomerTypeRepository : ICustomerTypeRepository
    {
        private CustomerContext context;
        private DbSet<CustomerType> custypeEntity;
        public CustomerTypeRepository(CustomerContext context)
        {
            this.context = context;
            custypeEntity = context.Set<CustomerType>();
        }

        public void DeleteCustomerType(long id)
        {
            CustomerType customertype = GetCustomerType(id);
            custypeEntity.Remove(customertype);
            context.SaveChanges();
        }

        public IEnumerable<CustomerType> GetAllCustomerTypes()
        {
            return custypeEntity.AsEnumerable();
        }

        public CustomerType GetCustomerType(long id)
        {
            return custypeEntity.SingleOrDefault(s => s.Id == id);
        }

        public void SaveCustomerType(CustomerType customertype)
        {
            context.Entry(customertype).State = EntityState.Added;
            context.SaveChanges();
        }

        public void UpdateCustomerType(CustomerType customerType)
        {
            context.SaveChanges();
        }
    }
}
