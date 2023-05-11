using DataAccess.Entities;
using DataAccess.Repositories;
using Moq;
using ProjectAPI.Models.Games;
using ProjectAPI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAPI.Tests.Services
{
	[TestClass]
	public class CreateGameServiceTest
	{
		[TestMethod]
		public async Task ResultsOfCallContainValuesFromRepositoryResult()
		{
			// Arrange
			var gamesRepositoryMocked = new Mock<IRepository<Game>>();
			var createGameService = new CreateGameService(gamesRepositoryMocked.Object);
			var createGameModel = new CreateGameModel(
				"Dota 2",
				"MMORPG",
				2011,
				"Valve",
				00.00M,
				true
			);

			// Act
			var result = await createGameService.CallAsync(createGameModel);

			// Assert
			Assert.AreEqual("Dota 2", result.Title);
			Assert.AreEqual("MMORPG", result.Genre);
			Assert.AreEqual(2011, result.Year);
			Assert.AreEqual("Valve", result.Publisher);
			Assert.AreEqual(00.00M, result.Price);
			Assert.AreEqual(true, result.InStock);
		}
	}
}
