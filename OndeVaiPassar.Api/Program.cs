using System;
using OndeVaiPassar.Domain.Interfaces;
using OndeVaiPassar.Persistence.Context;
using OndeVaiPassar.Query.Sports;
using OndeVaiPassar.QueryStore.Sports;
using Microsoft.EntityFrameworkCore;
using OndeVaiPassar.Persistence;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

//services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

services.AddSingleton<DbConnectionFactory>();
services.AddScoped<ISportRepository, SportRepository>();
services.AddScoped<ISportQueryStore, SportQueryStore>();

services.AddControllers();
services.AddEndpointsApiExplorer();
//services.AddSwaggerGen();
services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
