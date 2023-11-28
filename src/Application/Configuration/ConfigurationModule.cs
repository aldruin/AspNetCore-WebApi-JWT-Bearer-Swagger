using CashFlowAPI.Application.Users.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using CashFlowAPI.Application.Users.Interfaces;
using CashFlowAPI.Application.Sheets.Interfaces;
using CashFlowAPI.Application.Sheets.Services;
using CashFlowAPI.Application.Finance.Interfaces;
using CashFlowAPI.Application.Finance.Services;
using CashFlowAPI.Application.Jwt.Interfaces;
using CashFlowAPI.Application.Jwt.Services;

namespace CashFlowAPI.Application.Configuration;
public static class ConfigurationModule
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services,
                IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(ConfigurationModule).Assembly);

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ISheetService, SheetService>();
        services.AddScoped<IFinancialEntryService, FinancialEntryService>();
        services.AddScoped<IFinancialExpenseService, FinancialExpenseService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddHttpClient();

        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );
        });

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JwtSecurity:SecurityKey"])),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true
            };
        });

        var info = new OpenApiInfo();
        info.Version = "V1";
        info.Title = "API CashFlow";

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", info);
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Insira o token JWT desta maneira : Bearer {seu token}",
                Name = "Authorization",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"

            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In= ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
        });

        return services;
    }
}