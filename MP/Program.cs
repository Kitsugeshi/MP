using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MP.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();


string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MarketDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options =>
              {
                  options.LoginPath = "/Login";
                  options.AccessDeniedPath = "/Login";
              });



var app = builder.Build();


app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name:"default",
	pattern: "{controller=Products}/{action=Index}");

app.Run();
