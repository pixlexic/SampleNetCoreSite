using Microsoft.AspNetCore.Identity;

namespace SAMPLE_NetCoreMVC;

public class Program
{




    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddServerSideBlazor();

        builder.Services.AddHealthChecks();

        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

     

     

        app.UseCors(builder => builder
          .WithOrigins("http://localhost:4200", "http://localhost:4201", "https://localhost:44305/")
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



        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapRazorPages();
        app.MapBlazorHub();


        app.Run();
    }
}

