namespace ProjectAPI.Models.Games
{
	public class GameModel : GameBaseModel
	{
		public GameModel(
			int id,
			string title,
			string genre,
			int year,
			string publisher,
			decimal price,
			bool inStock)
			: base(
				  title,
				  genre,
				  year,
				  publisher,
				  price,
				  inStock)
		{
			Id = id;
		}

		public int Id { get; }
    }
}
