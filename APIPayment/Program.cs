using APIPayment.Domain.Contexts;
using APIPayment.Domain.Services;
using APIPayment.Domain.Contracts;
using APIPayment.Domain.Entities;
using APIPayment.Domain.Factory;
using APIPayment.Domain.Strategies;
using APIPayment.Infra.Repository;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStrategy, Pix>();
builder.Services.AddScoped<IStrategy, Credit>();
builder.Services.AddScoped<IStrategy, Debt>();
builder.Services.AddScoped<IStrategy, Ticket>();

builder.Services.AddScoped<IPaymentFactory, PaymentFactory>();

builder.Services.AddScoped<StrategyContext>();
builder.Services.AddScoped<PaymentService>();

var mongoSettings= builder.Configuration.GetSection(nameof(MongoRepositorySettings));
var mongoClient= MongoClientSettings.FromConnectionString(mongoSettings.Get<MongoRepositorySettings>().ConnectionString);


builder.Services.Configure<MongoRepositorySettings>(mongoSettings);
builder.Services.AddSingleton<IMongoClient>(new MongoClient(mongoClient));

builder.Services.AddSingleton<IRepository<Payment>, MongoRepository<Payment>>();

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
