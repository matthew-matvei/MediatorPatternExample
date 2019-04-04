using System.Collections.Generic;
using AutoMapper;
using MediatorPatternExample.Extensions;
using MediatorPatternExample.Handlers;
using MediatorPatternExample.Handlers.Queries;
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
            services.AddRequestHandlers();
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
