using MediatR;
using System.Reflection;
using Transactions.API.Validation;
using Transactions.Application.Commands;
using Transactions.Application.Mappers;
using FluentValidation;
using Transactions.Application.Interfaces;
using Transactions.Application.Services;
using Transactions.Infrastructure;
using Transactions.API.Middlewares;

namespace Transactions.API.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterCommonServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationProfile).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(AddTransactionHandler))));
            services.AddValidatorsFromAssemblyContaining<AddTransactionValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }

        public static void RegisterSpecificServices(this IServiceCollection services)
        {
            services.AddScoped<ICSVService, CSVService>();
            services.AddScoped<IXMLService, XMLService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IFileHandlerService, FileHandlerService>();
            services.AddTransient<ExceptionHandler>();
        }
    }
}
