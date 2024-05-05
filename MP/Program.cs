using Microsoft.EntityFrameworkCore;
using MP.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();


string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MarketDbContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

app.MapControllerRoute(
	name:"default",
	pattern: "{controller=Products}/{action=Index}");

app.Run();
