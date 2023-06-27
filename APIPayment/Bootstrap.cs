using APIPayment.Domain.Commands.Demand.V1.Create;
using APIPayment.Domain.Commands.Payment.V1.Create;
using APIPayment.Domain.Contexts;
using APIPayment.Domain.Contracts;
using APIPayment.Domain.Factory;
using APIPayment.Domain.Strategies;
using APIPayment.Domain.UoW;
using APIPayment.Infra.Repository;
using APIPayment.Infra.Repository.Context;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;

namespace APIPayment
{
    public static class Bootstrap
    {
        public static IServiceCollection AddInjections(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddRepositories(configuration);
            services.AddMappers();
            services.AddCommands();
            services.AddStrategies();
            services.AddContexts();
            services.AddFactories();
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<IMediaTRDependencyInjection>());
            services.AddRepositoriesContexts();
            services.AddUnitOfWork();

            return services;
        }

        private static void AddCommands(this IServiceCollection services)
        {
            services.AddScoped<CreatePaymentCommandHandler>();
            services.AddScoped<CreateDemandCommandHandler>();
        }

        private static void AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CreateDemandCommandProfile), typeof(CreatePaymentCommandProfile));
        }

        private static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoSettings = configuration.GetSection(nameof(MongoRepositorySettings));
            var mongoClient = MongoClientSettings.FromConnectionString(mongoSettings.Get<MongoRepositorySettings>().ConnectionString);

            services.Configure<MongoRepositorySettings>(mongoSettings);
            services.AddSingleton<IMongoClient>(new MongoClient(mongoClient));
            services.AddSingleton(typeof(IRepository<>), typeof(MongoRepository<>));
        }

        private static void AddContexts(this IServiceCollection services)
        {
            services.AddScoped<StrategyContext>();
        }

        private static void AddFactories(this IServiceCollection services)
        {
            services.AddScoped<IPaymentFactory, PaymentFactory>();
        }
        
        private static void AddStrategies(this IServiceCollection services)
        {
            services.AddScoped<IStrategy, Pix>();
            services.AddScoped<IStrategy, Credit>();
            services.AddScoped<IStrategy, Debt>();
            services.AddScoped<IStrategy, Ticket>();
        }

        private static void AddRepositoriesContexts(this IServiceCollection services)
        {
            services.AddSingleton<IMongoContext, MongoContext>();
        }

        private static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
        }
    }
}
