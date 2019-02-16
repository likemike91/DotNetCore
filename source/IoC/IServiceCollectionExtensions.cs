using DotNetCore.Logging;
using DotNetCore.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Reflection;

namespace DotNetCore.IoC
{
    public static class IServiceCollectionExtensions
    {
        public static void AddClassesMatchingInterfacesFrom(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.Scan(scan => scan
                .FromAssemblies(assemblies)
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }

        public static void AddCriptography(this IServiceCollection services, string key)
        {
            services.AddSingleton<ICriptography>(_ => new Criptography(key));
        }

        public static void AddDbContextEnsureCreatedMigrate<T>(this IServiceCollection services, Action<DbContextOptionsBuilder> options) where T : DbContext
        {
            services.AddDbContextPool<T>(options);
            var context = services.GetService<T>();
            context.Database.EnsureCreated();
            context.Database.Migrate();
        }

        public static void AddDbContextInMemoryDatabase<T>(this IServiceCollection services) where T : DbContext
        {
            services.AddDbContextPool<T>(options => options.UseInMemoryDatabase(typeof(T).Name));
            services.GetService<T>().Database.EnsureCreated();
        }

        public static void AddHash(this IServiceCollection services)
        {
            services.AddSingleton<IHash, Hash>();
        }

        public static void AddJsonWebToken(this IServiceCollection services, string key, TimeSpan expires)
        {
            services.AddJsonWebToken(new JsonWebTokenSettings(key, expires));
        }

        public static void AddJsonWebToken(this IServiceCollection services, string key, TimeSpan expires, string audience, string issuer)
        {
            services.AddJsonWebToken(new JsonWebTokenSettings(key, expires, audience, issuer));
        }

        public static void AddJsonWebToken(this IServiceCollection services, JsonWebTokenSettings jsonWebTokenSettings)
        {
            services.AddSingleton<IJsonWebTokenSettings>(_ => jsonWebTokenSettings);
            services.AddSingleton<IJsonWebToken, JsonWebToken>();
        }

        public static void AddLogger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ILogger>(_ => new Logger(configuration));
        }

        public static void AddSpaStaticFiles(this IServiceCollection services, string rootPath)
        {
            services.AddSpaStaticFiles(spa => spa.RootPath = rootPath);
        }

        public static T GetService<T>(this IServiceCollection services)
        {
            return services.BuildServiceProvider().GetService<T>();
        }
    }
}
