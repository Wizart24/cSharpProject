namespace ProjectAPI.Models.Games
{
	public class GameBaseModel
	{
		public GameBaseModel(
			string title, 
			string genre, 
			int year, 
			string publisher, 
			decimal price, 
			bool inStock)
		{
			Title = title;
			Genre = genre;
			Year = year;
			Publisher = publisher;
			Price = price;
			InStock = inStock;
		}

		public string Title { get; }
        public string Genre { get; }
		public int Year { get; }
		public string Publisher { get; }
		public decimal Price { get; }
		public bool InStock { get; }
	}
}
