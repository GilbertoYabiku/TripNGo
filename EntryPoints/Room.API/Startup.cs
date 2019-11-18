using System;
using Application.Interfaces;
using Application.Services;
using Application.Mappings;
using AutoMapper;
using Core.CQRS;
using Domain.BoundedContexts.RoomContext.Commands.Room;
using Domain.BoundedContexts.RoomContext.Handlers;
using Domain.BoundedContexts.RoomContext.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Bus;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.BoundedContexts.RoomContext.Commands.Hotel;

namespace Room.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepository, RoomRepository>();

            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IHotelRepository, HotelRepository>();

            services.AddScoped<IHandler<CreateRoomCommand>, RoomCommandHandler>();
            services.AddScoped<IHandler<UpdateRoomCommand>, RoomCommandHandler>();
            services.AddScoped<IHandler<RemoveRoomCommand>, RoomCommandHandler>();

            services.AddScoped<IHandler<CreateHotelCommand>, HotelCommandHandler>();
            services.AddScoped<IHandler<UpdateHotelCommand>, HotelCommandHandler>();
            services.AddScoped<IHandler<RemoveHotelCommand>, HotelCommandHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IBus, InMemoryBus>();

            ConfigureAutomapper(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ConfigurationContext>(options =>
                options.UseSqlServer(
                    Configuration["ConnectionStrings:DefaultConnection"],
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    })
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static void ConfigureAutomapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
