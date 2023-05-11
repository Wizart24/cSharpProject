using DataAccess.Entities;
using DataAccess.Repositories;
using ProjectAPI.Models.Customers;
using ProjectAPI.Models.Games;
using System.ComponentModel.DataAnnotations;

namespace ProjectAPI.Services
{
	public class CreateGameService
	{
		private IRepository<Game> _gameRepository;

		public CreateGameService(IRepository<Game> gameRepository)
		{
			_gameRepository = gameRepository;
		}

		public async Task<GameModel> CallAsync(CreateGameModel model)
		{
			Validate(model);

			var gameEntity = new Game()
			{
				Title = model.Title,
				Genre = model.Genre,
				Year = model.Year,
				Publisher = model.Publisher,
				Price = model.Price,
				InStock = model.InStock,
			};

			await _gameRepository.CreateAsync(gameEntity);

			return new GameModel(
				gameEntity.Id,
				gameEntity.Title,
				gameEntity.Genre,
				gameEntity.Year,
				gameEntity.Publisher,
				gameEntity.Price,
				gameEntity.InStock
			);
		}

		private void Validate(CreateGameModel model)
		{
			// Title
			if (string.IsNullOrEmpty(model.Title))
			{
				var validationResult = new ValidationResult(
					"Game Title is mandatory!",
					new[] { "Title" }
				);

				throw new ValidationException(validationResult, null, null);
			}

			// Genre
			if (string.IsNullOrEmpty(model.Genre))
			{
				var validationResult = new ValidationResult(
					"Game Genre is mandatory!",
					new[] { "Genre" }
				);

				throw new ValidationException(validationResult, null, null);
			}

			// Publisher
			if (string.IsNullOrEmpty(model.Publisher))
			{
				var validationResult = new ValidationResult(
					"Game Publisher is mandatory!",
					new[] { "Publisher" }
				);

				throw new ValidationException(validationResult, null, null);
			}
		}
	}
}
