using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TopHundred.Entities;

namespace TopHundred
{
    public class Startup
    {
        private IHostingEnvironment _env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<Customer, IdentityRole>(cfg => { cfg.User.RequireUniqueEmail = true; })
                .AddEntityFrameworkStores<IcoListContext>();
            services.AddTransient<Seed>();
            var connectionString = Configuration["connectionStrings:DefaultConnection"];          
            services.AddDbContext<IcoListContext>(cfg => { cfg.UseSqlServer(connectionString); });
            services.AddMvc(opt =>
            {
                if (_env.IsProduction())
                {
                    opt.Filters.Add(new RequireHttpsAttribute());
                }
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<Seed>();
                seeder.SeedDatabase().Wait();
            }

            app.UseMvc(cfg =>
            {
                cfg.MapRoute("default",
                    "{controller}/{action}/{id?}", new {controller = "icoslist", action = "Index"});
            });
        }
    }
}
