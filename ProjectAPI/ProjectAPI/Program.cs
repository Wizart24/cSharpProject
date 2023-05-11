using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using DataAccess.Repositories;
using ProjectAPI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ProjectAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Connection to DataBase
			var connectionString = builder.Configuration.GetConnectionString("Local");

			builder.Services.AddDbContext<GameDbContext>(
				options => options.UseSqlServer(connectionString)
			);

			// Add services to the container
			builder.Services.AddScoped<IRepository<Game>, GameRepository>();
			builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
			builder.Services.AddScoped<IRepository<Order>, OrderRepository>();

			// Add services to the container
			builder.Services.AddScoped<CreateGameService>();
			builder.Services.AddScoped<UpdateGameService>();
			builder.Services.AddScoped<CreateCustomerService>();
			builder.Services.AddScoped<CreateOrderService>();
			builder.Services.AddScoped<LoggingServices>();

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}