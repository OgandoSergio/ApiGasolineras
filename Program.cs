using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ApiGasolineras.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ApiGasolineras.Servicios;
using ApiGasolineras.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("_dbContext") ?? throw new InvalidOperationException("Connection string '_dbContextConnection' not found.");

builder.Services.AddDbContext<_dbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
        options => builder.Configuration.Bind("JwtSettings", options));

builder.Services.AddDefaultIdentity<AspNetUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<_dbContext>();

builder.Services.AddScoped<IGasolinerasService, GasolinerasService>();
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
