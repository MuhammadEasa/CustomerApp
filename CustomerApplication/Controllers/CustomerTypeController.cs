using CustomerApplication.DB;
using CustomerApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApplication.Controllers
{
    public class CustomerTypeController : Controller
    {
        private readonly CustomerContext _dbcontext;
        private ICustomerTypeRepository _customerRepository;
        public CustomerTypeController(CustomerContext dbcontext, ICustomerTypeRepository customerRepository)
        {
            _dbcontext = dbcontext;
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<CustomerType> model = _customerRepository.GetAllCustomerTypes().Select(s => new CustomerType
            {
                Id = s.Id,
                Name = s.Name
            });
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult AddEditCustomerType(long? id, CustomerType model)
        {
            try
            {

                if (model.Id > 0)
                {
                    CustomerType customer = _customerRepository.GetCustomerType(model.Id);
                    customer.Name = model.Name;
                    _customerRepository.UpdateCustomerType(customer);
                }
                else
                {

                    _customerRepository.SaveCustomerType(model);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
                return BadRequest();
            }
            return Ok();
        }

        public IActionResult DeleteCustomerType(int id)
        {
            try
            {
                _customerRepository.DeleteCustomerType(id);
                return RedirectToAction(nameof(Index), "CustomerType");
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return RedirectToAction(nameof(Index), "CustomerType");
        }
    }
}
