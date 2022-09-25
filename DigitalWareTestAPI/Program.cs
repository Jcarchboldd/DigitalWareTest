using DigitalWare.DAL.Repositories;
using DigitalWare.Domain.Contrats;
using DigitalWare.Domain.Data;
using DigitalWare.Domain.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Server=localhost\\SQLEXPRESS;Initial Catalog=DigitalWare;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true;"));

//Order injection
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();

//Details injection
builder.Services.AddScoped<IDetailsRepository<Order_Detail>, EFDetailRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
