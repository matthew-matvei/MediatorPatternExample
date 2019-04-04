using System.Collections.Generic;
using AutoMapper;
using MediatorPatternExample.Handlers;
using MediatorPatternExample.Mediator;
using MediatorPatternExample.Models;
using MediatorPatternExample.Models.Queries;
using MediatorPatternExample.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorPatternExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddMvc();
            services.AddTransient<IMediator, Mediator.Mediator>();
            services.AddTransient<IRequestHandler<ValuesQuery, IEnumerable<ValueModel>>>();
            services.AddTransient<IValuesReadRepository, ValuesReadRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
