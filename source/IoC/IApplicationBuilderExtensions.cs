using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace DotNetCore.IoC
{
    public static class IApplicationBuilderExtensions
    {
        public static void UseSpaAngularServer(this IApplicationBuilder application, IHostingEnvironment environment, string sourcePath, string npmScript)
        {
            application.UseSpa(spa =>
            {
                spa.Options.SourcePath = sourcePath;

                if (environment.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript);
                }
            });
        }

        public static void UseSpaProxyServer(this IApplicationBuilder application, IHostingEnvironment environment, string sourcePath, string baseUri)
        {
            application.UseSpa(spa =>
            {
                spa.Options.SourcePath = sourcePath;

                if (environment.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer(baseUri);
                }
            });
        }
    }
}
