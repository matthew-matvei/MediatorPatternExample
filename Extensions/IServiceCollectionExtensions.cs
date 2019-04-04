using System.Collections.Generic;
using MediatorPatternExample.Handlers;
using MediatorPatternExample.Handlers.Queries;
using MediatorPatternExample.Models;
using MediatorPatternExample.Models.Queries;
using MediatorPatternExample.Repositories;
using MediatorPatternExample.UnitsOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorPatternExample.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddRequestHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<ValuesQuery, IEnumerable<ValueModel>>, ValuesQueryHandler>();
            services.AddTransient<IRequestHandler<ValueQuery, ValueModel>, ValueQueryHandler>();

            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddTransient<IValuesReadRepository, ValuesReadRepository>();
            services.AddTransient<IValuesUnitOfWork, ValuesUnitOfWork>();

            return services;
        }
    }
}
