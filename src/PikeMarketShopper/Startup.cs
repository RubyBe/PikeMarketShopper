using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PikeMarketShopper.Models;

namespace PikeMarketShopper
{
  public class Startup
  {
    public IConfigurationRoot Configuration { get; set; }
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {
      // Provide services for authorization
      services.AddAuthorization(options =>
      {
        options.AddPolicy("AdministratorOnly", policy => policy.RequireRole("Administrator"));
      });
      services.AddMvc(config =>
      {
        var policy = new AuthorizationPolicyBuilder()
          .RequireAuthenticatedUser()
          .Build();
        config.Filters.Add(new AuthorizeFilter(policy));
      });
      services.AddDbContext<PikeMarketDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
      // Provide services for authentication
      services.AddIdentity<ApplicationUser, ApplicationRole>()
          .AddEntityFrameworkStores<PikeMarketDbContext>()
          .AddDefaultTokenProviders();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseIdentity();
      app.UseStaticFiles();
      app.UseCookieAuthentication(new CookieAuthenticationOptions
      {
        AuthenticationScheme = "Cookie",
        LoginPath = new PathString("/Account/Login/"),
        AccessDeniedPath = new PathString("/Account/Forbidden/"),
        AutomaticAuthenticate = true,
        AutomaticChallenge = true
      });
      app.UseMvc(routes =>
      {
        routes.MapRoute(
          name: "default",
          template: "{controller=Home}/{action=Index}/{id?}"); 
      });

      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Hey Hey Hello!");
      });
    }
  }
}