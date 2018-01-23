using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TopHundred.Entities;

namespace TopHundred
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<Customer, IdentityRole>(cfg => { cfg.User.RequireUniqueEmail = true; })
                .AddEntityFrameworkStores<IcoListContext>();
            services.AddTransient<Seed>();
            var connectionString = Configuration["connectionStrings:localConnection"];
            services.AddDbContext<IcoListContext>(cfg => { cfg.UseSqlServer(connectionString); });
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
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
                //seeder.SeedDatabase().Wait();
            }

            app.UseMvc(cfg =>
            {
                cfg.MapRoute("default",
                    "{controller}/{action}/{id?}", new {controller = "App", action = "Index"});
            });
        }
    }
}
