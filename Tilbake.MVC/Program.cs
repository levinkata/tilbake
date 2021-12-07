using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using Tilbake.Core.Context;
using Tilbake.EF.IoC;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Areas.Identity.Data;
using Tilbake.MVC.Extensions;
using Tilbake.MVC.Mapping;
using Tilbake.MVC.Services;
using Tilbake.MVC.Validators;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .ReadFrom.Configuration(ctx.Configuration));

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());  //  Added for Autofac by Levi Nkata

    // Register services directly with Autofac here. Don't
    // call builder.Populate(), that happens in AutofacServiceProviderFactory.
    builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModule()));  //  Added for Autofac by Levi Nkata

    // Configure Serilog logging to the console.
    builder.Logging.AddSerilog();

    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("Tilbake");

    builder.Services.AddDbContext<TilbakeDbContext>(options =>
            options.UseSqlServer(connectionString));

    builder.Services.AddDbContext<IdentityDbContext>(options =>
            options.UseSqlServer(connectionString));

    builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddDefaultUI()
            .AddEntityFrameworkStores<IdentityDbContext>()
            .AddDefaultTokenProviders();

    builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();

    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddTransient<IEmailSender, EmailSender>(i =>
            new EmailSender(builder.Configuration["EmailSender:Host"],
                builder.Configuration.GetValue<int>("EmailSender:Port"),
                builder.Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                builder.Configuration["EmailSender:Username"],
                builder.Configuration["EmailSender:Password"]
                )
            );

    builder.Services.AddControllersWithViews()
            .AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<BankValidator>();
                options.DisableDataAnnotationsValidation = true;
            });

    builder.Services.AddRazorPages();

    builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("EmailId", policy =>
                    policy.RequireClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "levi.nkata@outlook.com"));
                
                options.AddPolicy("CreateRole", policy =>
                    policy.RequireRole("Admin"));
            });

    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseGlobalExceptionMiddleware();     //  Added by Levi Nkata 22/11/2021 for Global Error Handling

        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    // Write streamlined request completion events, instead of the more verbose ones from the framework.
    // To use the default framework request logging instead, remove this line and set the "Microsoft"
    // level in appsettings.json to "Information".
    app.UseSerilogRequestLogging(); // Added by Levi Nkata 22/11/2021

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.MapRazorPages();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}
