using Autofac;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Tilbake.Application.Mapping;
using Tilbake.Application.Services;
using Tilbake.Application.Validators;
using Tilbake.Infrastructure.IoC;
using Tilbake.Infrastructure.Persistence.Context;

namespace Tilbake.MVC
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TilbakeDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Tilbake")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddTransient<IEmailSender, EmailSender>(i =>
                new EmailSender(
                    Configuration["EmailSender:Host"],
                    Configuration.GetValue<int>("EmailSender:Port"),
                    Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    Configuration["EmailSender:Username"],
                    Configuration["EmailSender:Password"]
                )
            );

            services.AddControllersWithViews()
                    .AddFluentValidation(s =>
                    {
                        s.RegisterValidatorsFromAssemblyContaining<BankResourceValidator>();
                        // s.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());                        
                        s.DisableDataAnnotationsValidation = true;
                    })
                    .AddRazorRuntimeCompilation();
            
            services.AddRazorPages()
                    .AddRazorRuntimeCompilation();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("EmailId", policy =>
                    policy.RequireClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "levi.nkata@outlook.com"));

                options.AddPolicy("CreateRole", policy =>
                    policy.RequireRole("Admin"));
            });

            services.AddAutoMapper(typeof(ModelToResourceProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDY3MzY0QDMxMzkyZTMyMmUzMGpPNGZYUWRadXdCdFNBVHZGOEs2dzl3QWxHUXZUdmxEeEFpY1p6Qm1Delk9");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
                endpoints.MapRazorPages();
            });
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public static void ConfigureContainer(ContainerBuilder builder)
        {
            // Add any Autofac modules or registrations.
            // This is called AFTER ConfigureServices so things you
            // register here OVERRIDE things registered in ConfigureServices.
            //
            // You must have the call to AddAutofac in the Program.Main
            // method or this won't be called.
            builder.RegisterModule(new AutofacModule());
        }
    }
}
