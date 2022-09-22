using CustomerApplication.DB;
using CustomerApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace CustomerApplication.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerContext _dbcontext;
        private ICustomerRepository _customerRepository;
        private ICustomerTypeRepository _customertypeRepository;
        public CustomerController(CustomerContext dbcontext, ICustomerRepository customerRepository, ICustomerTypeRepository customertypeRepository)
        {
            _dbcontext = dbcontext;
            _customerRepository = customerRepository;
            _customertypeRepository = customertypeRepository;
        }

        public IActionResult Index()
        {


            IEnumerable<tblCustomer> model = _customerRepository.GetAllCustomers().Select(s => new tblCustomer
            {
                Id = s.Id,
                Name = s.Name,
                CustomerTypeId = s.CustomerTypeId,
                Description = s.Description,
                Address = s.Address,
                City = s.City,
                State = s.State,
                Zip = s.Zip,
                LastUpdated = s.LastUpdated


            });

            ViewBag.CustomerTypes = _customertypeRepository.GetAllCustomerTypes().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult AddEditCustomer(long? id, tblCustomer model)
        {
            try
            {
                    model.LastUpdated = DateTime.Now;

                    if (model.Id>0)
                    {
                        tblCustomer customer= _customerRepository.GetCustomer(model.Id);
                        customer.Name = model.Name;
                        customer.CustomerTypeId = model.CustomerTypeId;
                        customer.Description = model.Description;
                        customer.CustomerTypeId = model.CustomerTypeId;
                        customer.Address = model.Address;
                        customer.City = model.City;
                        customer.State = model.State;
                        customer.Zip = model.Zip;
                        _customerRepository.UpdateCustomer(customer);
                    }
                    else
                    {
                        
                        _customerRepository.SaveCustomer(model);
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

        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                _customerRepository.DeleteCustomer(id);
                return RedirectToAction(nameof(Index), "Customer");
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
            return RedirectToAction(nameof(Index), "Customer");
        }
    }
}
