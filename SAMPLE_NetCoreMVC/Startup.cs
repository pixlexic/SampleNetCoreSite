

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SAMPLE_NetCoreMVC.Services;
using SAMPLE_NetCoreMVC.Helpers;
//using Microsoft.AspNetCore.Mvc.NewtonsoftJson;



namespace SAMPLE_NetCoreMVC
{
    public class Startup
    {

      //  private readonly AuthService _authService;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
          //  _authService = new AuthService();

            // SchedulerService.InitScheduler();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {



           

            var appsetting = Configuration
               .GetSection("AppSettings")
               .Get<AppSettings>();


            var connectionString = Configuration.GetConnectionString("SampleDBConnection");

            var connection = Configuration
                .GetSection("ConnectionStrings")
                .Get<ConnectionSettings>();

            if (appsetting != null && connection != null)
            {
                services.AddSingleton<IAppSettingsModel, AppSettingsModel>(serviceProvider => new AppSettingsModel(appsetting));
                services.AddSingleton<IConnectionStringModel, ConnectionStringModel>(serviceProvider => new ConnectionStringModel(connection));
            }

            services.AddCors();



            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always;
                options.Secure = CookieSecurePolicy.Always;

            });




            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });



        //    _authService.ConfigureJwtUri(services, Configuration);

            // Angular's default header name for sending the XSRF token.
            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-XSRF-TOKEN";
                options.Cookie.Name = "XSRF-TOKEN";
                options.Cookie.HttpOnly = true;
                options.Cookie.Path = "/";
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;

            });





            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeFolder("/");
                options.Conventions.AllowAnonymousToPage("/Login");
                options.Conventions.AllowAnonymousToPage("/Front/Contact");

            });


              services.AddScoped<IDataService, DataService>();

            //  services.AddScoped<IListService, ListService>();
            //  services.AddScoped<IPasswordService, PasswordService>();


            services.AddSingleton(Configuration);


            services.AddControllersWithViews();

            services.AddServerSideBlazor();

            services.AddHealthChecks();

            services.AddRazorPages();




            //   _authService.setPolicies(services);


        


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAntiforgery antiforgery)
        {



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



      



            app.UseCors(builder => builder
              .WithOrigins("http://localhost:4200", "http://localhost:63535/", "https://localhost:44305/", "http://localhost:4300", "https://localhost:44347/")
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials()

                      //  .AllowAnyOrigin()

                      );


            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = ctx => {
                    ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                    ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
                    ctx.Context.Response.Headers.Append("Access-Control-Allow-Credentials", "true");
                },

            });


          //  app.UseMiddleware(typeof(SecureMiddleware));
            app.UseHttpsRedirection();
              app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseDeveloperExceptionPage();


   

            _ = app.Use(next => context =>
            {

                if (context.Request.Path.Value != null)
                {
                    string path = context.Request.Path.Value;

                    if (
                        string.Equals(path, "/", StringComparison.OrdinalIgnoreCase) ||
                         string.Equals(path, "/angular", StringComparison.OrdinalIgnoreCase) ||
                          string.Equals(path, "/react", StringComparison.OrdinalIgnoreCase))


                    {
                        // The request token can be sent as a JavaScript-readable cookie, 
                        // and Angular uses it by default.
                        //   context.Response.Cookies.Delete("XSRF-TOKEN");
                        var tokens = antiforgery.GetAndStoreTokens(context);

                        if (tokens.RequestToken != null)
                        {
                            context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                            new CookieOptions() { HttpOnly = false });

                        }
                    }
                }
                return next(context);
            });


            // app.UseCookiePolicy();
            //  app.UseSession();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Builder}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
     name: "default",
     pattern: "{controller=Home}/{action=Index}/{id?}");


                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();


            });

            
     
       


        }





    }
}
