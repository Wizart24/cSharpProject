using DataAccess.Entities;
using DataAccess.Repositories;
using ProjectAPI.Models.Customers;
using ProjectAPI.Models.Games;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ProjectAPI.Services
{
    public class CreateCustomerService
    {
        private IRepository<Customer> _customerRepository;

        public CreateCustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerModel> CallAsync(CreateCustomerModel model)
        {
            Validate(model);

            var customerEntity = new Customer()
            {
                Name = model.Name,
                Password = model.Password,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Role = model.Role,
            };

            await _customerRepository.CreateAsync(customerEntity);

            return new CustomerModel(
                customerEntity.Id,
                customerEntity.Name,
                customerEntity.Password,
                customerEntity.Email,
                customerEntity.PhoneNumber,
                customerEntity.Address,
                customerEntity.Role
            );
        }

        private void Validate(CreateCustomerModel model)
        {
            // Email
            if (!IsEmailValid(model.Email))
            {
                var validationResult = new ValidationResult(
                    "Incorrect Email!",
                    new[] { "Email" }
                );

                throw new ValidationException(validationResult, null, model.Email);
            }

            // Name
            if (string.IsNullOrEmpty(model.Name))
            {
                var validationResult = new ValidationResult(
                    "Name is mandatory!",
                    new[] { "Name" }
                );

                throw new ValidationException(validationResult, null, null);
            }

            // Password
            if (string.IsNullOrEmpty(model.Password))
            {
                var validationResult = new ValidationResult(
                    "Password is mandatory!",
                    new[] { "Password" }
                );

                throw new ValidationException(validationResult, null, null);
            }

            // Address
            if (string.IsNullOrEmpty(model.Address))
            {
                var validationResult = new ValidationResult(
                    "Address is mandatory!",
                    new[] { "Address" }
                );

                throw new ValidationException(validationResult, null, null);
            }
        }

        private bool IsEmailValid(string email)
        {
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            return Regex.IsMatch(email, pattern);
        }
    }
}
