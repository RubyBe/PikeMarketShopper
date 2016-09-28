using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
        .AddJsonFile("appsettings.json");
      Configuration = builder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {
      // Provide services for authorization
      services.AddAuthorization();
      services.AddMvc();
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