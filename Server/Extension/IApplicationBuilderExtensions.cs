using DataModel;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Server.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net;

namespace Server.Extension
{
    public static class IApplicationBuilderExtensions
    {
        public static void AddApiAuthentication(
            this IServiceCollection services,
            IOptions<JwtOptions> jwtOptions)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false, //валидация издателя
                        ValidateAudience = false, //валидация получателя
                        ValidateLifetime = true, //время жизни токена
                        ValidateIssuerSigningKey = true, //валидация ключа издателя
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey)) //алгоритм кодирования с передачей секретного ключа
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["auth-cookie"];
                            return Task.CompletedTask;
                        }
                    };
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireClaim("roleId", "1");
                });
                options.AddPolicy("Boss", policy =>
                {
                    policy.RequireClaim("roleId", "2");
                });
                options.AddPolicy("User", policy =>
                {
                    policy.RequireClaim("roleId", "3");
                });
            }
            
            );
        }

    }
}
