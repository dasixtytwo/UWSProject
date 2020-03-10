using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using dasixtytwo.lib;
using Newtonsoft.Json;
using NSwag;
using NSwag.AspNetCore;

namespace WebApp2
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
          
          // Add ASPNETCore DBContext services.
          string connectionStrings = Configuration["ConnectionStrings:DefaultConnection"];
          services.AddDbContext<Northwind>(options => options.UseSqlServer(connectionStrings));
          
          // Add to Mvc the Json serialize setting option to avoid circular reference.
          services.AddMvc().AddJsonOptions(opts => opts.SerializerSettings.ReferenceLoopHandling 
            = ReferenceLoopHandling.Ignore); //Ignores any object that it as already serialzed

          /* 
           * Register the Swagger generator, and define a Swagger document 
           * for Northwind service
           */
          services.AddSwaggerDocument(config =>
          {
            config.PostProcess = document =>
            {
              document.Info.Version = "v1";
              document.Info.Title = "Northwind Service API";
              document.Info.Description = ".NET Core 2.0 webApp2 Coursework";
              document.Info.TermsOfService = "None";
              document.Info.Contact = new NSwag.OpenApiContact
              {
                Name = "B00351081",
                Email = "B00351081@studentmail.uws.ac.uk"
              };
            };
          });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            
            /*
             * this statement using swagger for testing API 
             * comment or delete the statement below if you don't want use swagger
             */
            app.MapWhen(r => r.Request.Path.Value.StartsWith("/swagger"), builder => {
              builder.UseMvc(routes =>
              {
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
              });
            });
        }
    }
}
