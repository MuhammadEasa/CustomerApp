using CustomerApplication.Data;
using CustomerApplication.DB;
using CustomerApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("GetAllCustomers")]
        public List<tblCustomer> GetAllCustomers()
        {
            var lst = new List<tblCustomer>();
            try
            {
                lst = _customerRepository.GetAllCustomers().ToList();
                return lst;
            }
            catch (Exception e)
            {
                return lst;
            }

        }
        [HttpPost]
        [Route("AddCustomer")]
        public string AddCustomer(tblCustomer obj)
        {
            string result = "-1";
            try
            {
                 _customerRepository.SaveCustomer(obj);
                result = "1";
                return result;
            }
            catch (Exception e)
            {

                return "-1";
            }
        }

        [HttpGet]
        [Route("GetCustomerById")]
        public tblCustomer GetCustomerById(int id)
        {
            tblCustomer obj = new tblCustomer();
            try
            {
                obj = _customerRepository.GetCustomer(id);
                return obj;
            }
            catch (Exception e)
            {
                return obj;
            }
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        public string UpdateCustomer(tblCustomer obj)
        {
            string result = "-1";
            try
            {
                tblCustomer customer = _customerRepository.GetCustomer(obj.Id);
                customer.Name = obj.Name;
                customer.CustomerTypeId = obj.CustomerTypeId;
                customer.Description = obj.Description;
                customer.CustomerTypeId = obj.CustomerTypeId;
                customer.Address = obj.Address;
                customer.City = obj.City;
                customer.State = obj.State;
                customer.Zip = obj.Zip;
                _customerRepository.UpdateCustomer(customer);
                result = "1";
                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }
        [HttpPost]
        [Route("DeleteCustomer")]
        public string DeleteBrand(int id)
        {
            string result = "-1";
            try
            {
                 _customerRepository.DeleteCustomer(id);
                result = "1"
;                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }

    }
}
