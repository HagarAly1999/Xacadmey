using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Xacadmey.Models;
using Xacadmey.Repositary;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Xacadmey
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("CS");
            services.AddDbContext<Academy>(optionsBuilder =>
            optionsBuilder.UseSqlServer(connectionString));

            services.AddScoped<ITraineeRepository, TraineeRepositary>();
            services.AddScoped<IDepartmentRepository, DepartmentRepositary>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IinstructorRepository,InstructorRepository>();

            services.AddControllersWithViews();
            services.AddIdentity<ApplicationUser, IdentityRole>(
                Options => Options.Password.RequireDigit = false

                ).AddEntityFrameworkStores<Academy>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
