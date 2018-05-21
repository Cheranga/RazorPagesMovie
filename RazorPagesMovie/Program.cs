using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RazorPagesMovie.Models;

namespace RazorPagesMovie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    // Migrate the database
                    MigrateDatabase<MovieContext>(serviceProvider);

                    SeedData.Initialize(scope.ServiceProvider);
                }
                catch (Exception exception)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, $"{exception.Message}{Environment.NewLine}{exception.StackTrace}");
                }
            }


            host.Run();
        }

        private static void MigrateDatabase<TDbContext>(IServiceProvider serviceProvider) where TDbContext : DbContext
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var context = serviceProvider.GetRequiredService<TDbContext>();
            if (context == null)
            {
                throw new ArgumentException(typeof(TDbContext).Name);
            }

            context.Database.Migrate();
        }


        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}