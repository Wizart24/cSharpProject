using DataAccess.Entities;
using DataAccess.Repositories;
using Moq;
using ProjectAPI.Models.Customers;
using ProjectAPI.Models.Games;
using ProjectAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAPI.Tests.Services
{
	[TestClass]
	public class CreateCustomerServiceTest
	{
		[TestMethod]
		public async Task ResultsOfCallContainValuesFromRepositoryResult()
		{
			// Arrange
			var customersRepositoryMocked = new Mock<IRepository<Customer>>();
			var createCustomerService = new CreateCustomerService(customersRepositoryMocked.Object);
			var createCustomerModel = new CreateCustomerModel(
				"Petras",
				"qweasdzxc123",
				"petras147@gmail.com",
				869573442,
				"Klaipedos g. 55, Siauliai",
				"user"
			);

			// Act
			var result = await createCustomerService.CallAsync(createCustomerModel);

			// Assert
			Assert.AreEqual("Petras", result.Name);
			Assert.AreEqual("qweasdzxc123", result.Password);
			Assert.AreEqual("petras147@gmail.com", result.Email);
			Assert.AreEqual(869573442, result.PhoneNumber);
			Assert.AreEqual("Klaipedos g. 55, Siauliai", result.Address);
			Assert.AreEqual("user", result.Role);
		}
	}
}
