using Valuator.Repository;

namespace Valuator;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddScoped<ITextRepository, TextRepository>();
        builder.Services.AddStackExchangeRedisCache(options => {
            options.Configuration = "localhost:6379";
            options.InstanceName = "local";
        });
        var app = builder.Build();
        
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
