using System;
using Avander.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Avander
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
                    {
                        options.AddPolicy(name: MyAllowSpecificOrigins,
                                          builder =>
                                          {
                                              builder.WithOrigins("http://localhost:8080")
                                                                .AllowAnyHeader()
                                                                .AllowAnyMethod()
                                                                .WithExposedHeaders("X-Pagination");;
                                          });
                    });

            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("AvanderConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // services.AddScoped<IMeasurementRepo, MockMeasurementRepo>();
            services.AddScoped<IMeasurementRepo, SqlMeasurementRepo>();
            // services.AddScoped<IMeasurementPointRepo, MockMeasurementPointRepo>();
            services.AddScoped<IMeasurementPointRepo, SqlMeasurementPointRepo>();
            // services.AddScoped<IShopRepo, MockShopRepo>();
            services.AddScoped<IShopRepo, SqlShopeRepo>();
            // services.AddScoped<IVehicleRepo, MockVehicleRepo>();
            services.AddScoped<IVehicleRepo, SqlVehicleRepo>();

            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
