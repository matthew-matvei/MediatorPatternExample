using System.Collections.Generic;
using MediatorPatternExample.Handlers;
using MediatorPatternExample.Mediator;
using MediatorPatternExample.Models.DTOs;
using MediatorPatternExample.Models.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorPatternExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IMediator, Mediator.Mediator>();
            services.AddTransient<IRequestHandler<IEnumerable<ValueDTO>, ValuesQuery>>();
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
