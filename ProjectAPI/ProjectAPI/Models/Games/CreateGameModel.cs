namespace ProjectAPI.Models.Games
{
	public class CreateGameModel : GameBaseModel
	{
		public CreateGameModel(
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
		}
	}
}
