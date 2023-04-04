using CrocodileGame.Api;
using CrocodileGame.BussinessLogic.Services;
using CrocodileGame.DataAccess.PostgreSQL;
using CrocodileGame.DataAccess.PostgreSQL.Repositories;
using CrocodileGame.Domain.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CrocodileGame
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
            services.AddCors();

            services.AddAutoMapper(typeof(ApiMappingProfile),typeof(DataAccessMappingProfile));

            services.AddTransient<ITopicRepository, TopicRepository>();

            services.AddTransient<ITopicService, TopicService>();

            services.AddTransient<ICardRepository, CardRepository>();

            services.AddTransient<ICardService, CardService>();

            services.AddDbContext<CrocodileGameContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("CrocodileGameContext")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CrocodileGame API", Version = "v1" });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CrocodileGame");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(options => options
                .WithOrigins(new[] { "http://localhost:3000", "https://localhost:3000" })
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
