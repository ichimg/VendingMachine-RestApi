using Microsoft.EntityFrameworkCore;
using VendingMachine.DataAccess;
using VendingMachine.DataAccess.DataAccess;
using VendingMachine.Domain;
using VendingMachine.Domain.Abstractions;
using VendingMachine.Logic;
using VendingMachine.Logic.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Allow CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Add Database Connection
builder.Services.AddDbContext<VendingMachineDbContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("VendingMachineDbConnectionString")));

// Add Repositories
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISaleService, SaleService>();

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
