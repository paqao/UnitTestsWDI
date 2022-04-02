using Microsoft.EntityFrameworkCore;
using WDIUnitTests.DatabaseLayer;
using WDIUnitTests.DatabaseLayer.Data;
using WDIUnitTests.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WDIDbContext>(
                options => options
                    .UseInMemoryDatabase("WDIDb"));
builder.Services.AddScoped<IDataRepository<Order>, EFDataRepository<Order>>();
builder.Services.AddScoped<IDataRepository<BlogPost>, EFDataRepository<BlogPost>>();

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

public partial class Program
{

}