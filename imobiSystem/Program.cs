using Autofac;
using Autofac.Core;
using imobiSystem.Infrastructure.CrossCutting.IOC;
using imobiSystem.Infrastrusture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(i =>
{
    i.SwaggerDoc("v1", new OpenApiInfo { Title = "API imobi System", Version = "v1" });
});

ContainerBuilder containerBuilder = new ContainerBuilder();
containerBuilder.RegisterModule(new ModuleIOC());

builder.Services.AddDbContext<SqlContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("imobiSystem.API")));

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
