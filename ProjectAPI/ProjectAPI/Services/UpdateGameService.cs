using DataAccess.Entities;
using DataAccess.Repositories;
using ProjectAPI.Models.Games;

namespace ProjectAPI.Services
{
	public class UpdateGameService
	{
		private IRepository<Game> _gameRepository;

		public UpdateGameService(IRepository<Game> gameRepository)
		{
			_gameRepository = gameRepository;
		}

		public async Task<GameModel> CallAsync(UpdateGameModel model, int id)
		{
			var gameEntity = await _gameRepository.GetAync(id);

			if (gameEntity != null)
			{
				gameEntity.Title = model.Title;
				gameEntity.Genre = model.Genre;
				gameEntity.Year = model.Year;
				gameEntity.Publisher = model.Publisher;
				gameEntity.Price = model.Price;
				gameEntity.InStock = model.InStock;

				await _gameRepository.UpdateAsync(gameEntity);
			}

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
	}
}
