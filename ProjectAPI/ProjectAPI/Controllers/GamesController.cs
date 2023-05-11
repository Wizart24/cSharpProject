using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProjectAPI.Models.Games;
using ProjectAPI.Services;
using System.ComponentModel.DataAnnotations;

namespace ProjectAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GamesController : ControllerBase
	{
		private IRepository<Game> _gameRepository;
		private CreateGameService _createGameService;
		private UpdateGameService _updateGameService;
		private LoggingServices _loggingServices;

		public GamesController(
			IRepository<Game> gameRepository, 
			CreateGameService createGameService,
			UpdateGameService updateGameService,
			LoggingServices loggingServices) 
		{
			_gameRepository = gameRepository;
			_createGameService = createGameService;
			_updateGameService = updateGameService;
			_loggingServices = loggingServices;
		}

		[HttpGet]
		public async Task<IActionResult> ListAsync()
		{
			var games = await _gameRepository.ListAsync();

			return Ok(games);
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(CreateGameModel gameModel)
		{
			_loggingServices.Write("Game Controller Has Started!");

			try
			{
				var game = await _createGameService.CallAsync(gameModel);

				return Ok(game);
			}
			catch(ValidationException ex)
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
				_loggingServices.Write("Game Controller Has Ended!");
			}
		}

		[HttpPatch("{id}")]
		public async Task<IActionResult> UpdateAsync(UpdateGameModel gameModel, int id)
		{
			var game = await _updateGameService.CallAsync(gameModel, id);

			return Ok(game);
		}
	}
}
