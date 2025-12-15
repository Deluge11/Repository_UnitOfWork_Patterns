

using Microsoft.EntityFrameworkCore;
using Repository_UOW.Core.Interfaces;
using Repository_UOW.EF;
using Repository_UOW.EF.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();


var connectionString = builder.Configuration.GetConnectionString("Default");


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString,
        sqlServerOptions => sqlServerOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name)));




builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
