namespace ProjectAPI.Services
{
	public class LoggingServices
	{
		public void Write(string message)
		{
			using (var writer = new StreamWriter($"Logs{DateTime.Now.ToString("yyyyMMdd")}.txt", true))
			{
				writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff")} - {message}");
			}
		}
	}
}
