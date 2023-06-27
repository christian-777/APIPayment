using APIPayment.Domain.Contexts;
using APIPayment.Domain.Contracts;
using APIPayment.Domain.Entities;
using APIPayment.Domain.Factory;
using APIPayment.Domain.Strategies;
using APIPayment.Infra.Repository;
using MongoDB.Driver;
using APIPayment.Domain.Commands.Demand.V1.Create;
using APIPayment.Domain.Commands.Payment.V1.Create;
using APIPayment;

var builder = WebApplication.CreateBuilder(args);

//dependency injection 

var config = builder.Configuration;

builder.Services.AddInjections(config);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
