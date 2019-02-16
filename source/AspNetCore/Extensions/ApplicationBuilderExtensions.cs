using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace DotNetCore.AspNetCore
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseCorsDefault(this IApplicationBuilder application)
        {
            application.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        }

        public static void UseExceptionDefault(this IApplicationBuilder application, IHostingEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                application.UseDatabaseErrorPage();
                application.UseDeveloperExceptionPage();
            }

            application.UseMiddleware<ExceptionMiddleware>();
        }

        public static void UseHstsDefault(this IApplicationBuilder application, IHostingEnvironment environment)
        {
            if (!environment.IsDevelopment())
            {
                application.UseHsts();
            }
        }

        public static void UseSwaggerDefault(this IApplicationBuilder application, string name)
        {
            application.UseSwagger();
            application.UseSwaggerUI(cfg => cfg.SwaggerEndpoint($"/swagger/{name}/swagger.json", name));
        }
    }
}
