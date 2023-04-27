using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ApiGasolineras.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("_dbContext") ?? throw new InvalidOperationException("Connection string '_dbContextConnection' not found.");

builder.Services.AddDbContext<_dbApiContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApiGasolinerasUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<_dbApiContext>();

// Add services to the container.

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllers();

app.Run();
