using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Owner.API.Middlewares;
using Owner.Business.Abstract;
using Owner.Business.Concrete;
using Owner.DataAccess.Abstract;
using Owner.DataAccess.Concrete;
using Owner.DataAccess.Concrete.Dapper;
using Owner.DataAccess.Context;
using System.Reflection;

namespace Owner.API
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
          
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Owner.API", Version = "v1" });
            });

            //services.AddDbContext<OwnerDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
            //services.AddDbContext<OwnerDbContext>();
            services.AddSingleton<OwnerDapperContext>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IOwnerRepository), typeof(DapperOwnwerRepository));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IOwnerService, OwnerManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Owner.API v1"));
            }

            app.UseHttpsRedirection();

            
            app.UseRouting();

            app.UseExceptionMiddleware();

            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
