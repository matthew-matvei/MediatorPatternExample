using AutoMapper;
using MediatorPatternExample.Extensions;
using MediatorPatternExample.Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorPatternExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAutoMapper()
                .AddMvc();

            services
                .AddTransient<IMediator, Mediator.Mediator>()
                .AddRequestHandlers()
                .AddPersistence();
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
