using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITRoot.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace ITRoot
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
           
            services.AddDbContext<ApplicationDbContext>(options=> 
            options.UseSqlServer(
                 Configuration.GetConnectionString("DefaultConnection")));

             services.AddControllersWithViews(options => {
                 //Add authorization to all controllers using filters.
                 var policy = new AuthorizationPolicyBuilder()
                                    .RequireAuthenticatedUser().Build();
                  options.Filters.Add(new AuthorizeFilter(policy: policy));
             });
             
             services.AddIdentity<ApplicationUser , IdentityRole>()    
                        .AddEntityFrameworkStores<ApplicationDbContext>();

             services.Configure<IdentityOptions>(opt => {
                 opt.Password.RequireUppercase = false;
                 opt.Password.RequiredLength = 8;
             });
             services.AddScoped<IInvoiceRepository,InvoiceRepository>();
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
