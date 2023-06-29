using APIPayment.Application.Commands.Demand.V1.Create;
using APIPayment.Application.Commands.Payment.V1.Create;
using APIPayment.Domain.Contracts;
using APIPayment.Application;
using APIPayment.Application.Strategies;
using APIPayment.Infra.Repository;
using APIPayment.Infra.Repository;
using APIPayment.Infra.Repository.Context;
using APIPayment.Infra.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using APIPayment.Domain.Contexts;

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
            services.AddFactories();
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<CreateDemandCommandHandler>());
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
            services.AddScoped<DbContext,APIPaymentContext>();
            services.AddScoped(typeof(IRepository<>), typeof(SQLRepository<>));
            services.AddScoped<ITesteRepository, TesteRepository>();
          
        }

        private static void AddFactories(this IServiceCollection services)
        {
            services.AddScoped<IPaymentFactory, PaymentFactory>();
        }
        
        private static void AddStrategies(this IServiceCollection services)
        {
            services.AddScoped<Strategy>();
            services.AddScoped<IStrategy, Pix>();
            services.AddScoped<IStrategy, Credit>();
            services.AddScoped<IStrategy, Debt>();
            services.AddScoped<IStrategy, Ticket>();
        }

        private static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
