using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProjectAPI.Models.Customers;
using ProjectAPI.Models.Games;
using ProjectAPI.Services;
using System.ComponentModel.DataAnnotations;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private IRepository<Customer> _customerRepository;
        private CreateCustomerService _createCustomerService;
        private LoggingServices _loggingServices;

        public CustomersController(
            IRepository<Customer> customerRepository,
            CreateCustomerService createCustomerService,
            LoggingServices loggingServices)
        {
            _customerRepository = customerRepository;
            _createCustomerService = createCustomerService;
            _loggingServices = loggingServices;
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            var customers = await _customerRepository.ListAsync();

            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCustomerModel customerModel)
        {
            _loggingServices.Write("Customer Service Has Started!");

            try
            {
                var customer = await _createCustomerService.CallAsync(customerModel);

                return Ok(customer);
            }
            catch (ValidationException ex)
            {
                _loggingServices.Write(
                    $"{ex.Value} " +
                    $"{ex.ValidationResult.ErrorMessage} " +
                    $"{ex.ValidationResult.MemberNames.First()} " +
                    $"{ex.ToString()}");

                return BadRequest(ex.Message);
            }
            catch (SqlException ex)
            {
                _loggingServices.Write(ex.ToString());
                return StatusCode(500, "Database Problems!");
            }
            catch (Exception ex)
            {
                _loggingServices.Write(ex.ToString());
                return StatusCode(500, "Some Problems!");
            }
            finally
            {
                _loggingServices.Write("Customer Service Has Ended!");
            }
        }
    }
}
