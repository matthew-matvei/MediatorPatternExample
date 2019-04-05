using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using MediatorPatternExample.Handlers;
using MediatorPatternExample.Handlers.Commands;
using MediatorPatternExample.Handlers.Queries;
using MediatorPatternExample.Models;
using MediatorPatternExample.Models.Commands;
using MediatorPatternExample.Models.Queries;
using MediatorPatternExample.Repositories;
using MediatorPatternExample.UnitsOfWork;
using MediatorPatternExample.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorPatternExample.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddRequestHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<ValuesQuery, IEnumerable<ValueModel>>, ValuesQueryHandler>();
            services.AddTransient<IRequestHandler<ValueQuery, ValueModel>, ValueQueryHandler>();
            services.AddTransient<IRequestHandler<CreateValueCommand, ValueModel>>(provider =>
            {
                var valuesUnitOfWork = provider.GetRequiredService<IValuesUnitOfWork>();
                var mapper = provider.GetRequiredService<IMapper>();
                var validator = provider.GetRequiredService<IValidator<CreateValueCommand>>();

                return new CreateValueCommandHandler.WithArgumentChecking(
                    new CreateValueCommandHandler(valuesUnitOfWork, mapper),
                    validator);
            });
            services.AddTransient<IRequestHandler<UpdateValueCommandWithId>, UpdateValueCommandWithIdHandler>();

            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddTransient<IValuesReadRepository, ValuesReadRepository>();
            services.AddTransient<IValuesUnitOfWork, ValuesUnitOfWork>();

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateValueCommand>, CreateValueCommandValidator>();

            return services;
        }
    }
}
