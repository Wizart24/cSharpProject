namespace ProjectAPI.Models.Games
{
	public class UpdateGameModel : GameModel
	{
		public UpdateGameModel(
			int id, 
			string title, 
			string genre, 
			int year, 
			string publisher, 
			decimal price, 
			bool inStock) 
			: base(
				  id, 
				  title, 
				  genre, 
				  year, 
				  publisher, 
				  price,
				  inStock)
		{
		}
	}
}
