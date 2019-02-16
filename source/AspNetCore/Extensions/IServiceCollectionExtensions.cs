using System;
using DotNetCore.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;

namespace DotNetCore.AspNetCore
{
    public static class IServiceCollectionExtensions
    {
        public static void AddAuthenticationDefault(this IServiceCollection services)
        {
            var jsonWebTokenSettings = services.BuildServiceProvider().GetRequiredService<IJsonWebTokenSettings>();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jsonWebTokenSettings.Key));

            void JwtBearer(JwtBearerOptions jwtBearer)
            {
                jwtBearer.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = securityKey,
                    ValidAudience = jsonWebTokenSettings.Audience,
                    ValidIssuer = jsonWebTokenSettings.Issuer,
                    ValidateAudience = !string.IsNullOrEmpty(jsonWebTokenSettings.Audience),
                    ValidateIssuer = !string.IsNullOrEmpty(jsonWebTokenSettings.Issuer),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearer);
        }

        public static void AddMvcDefault(this IServiceCollection services)
        {
            void Mvc(MvcOptions mvc)
            {
                mvc.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
            }

            void Json(MvcJsonOptions json)
            {
                json.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            }

            services.AddMvc(Mvc).AddJsonOptions(Json);
        }

        public static void AddSwaggerDefault(this IServiceCollection services, string name)
        {
            services.AddSwaggerGen(cfg => cfg.SwaggerDoc(name, new Info()));
        }
    }
}
