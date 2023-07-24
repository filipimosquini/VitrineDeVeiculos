﻿using System.Text;
using Backend.Api.Sections;
using Backend.Infra.Configurations;
using Backend.Infra.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Api.Configurations;

public static class AuthenticationSetup
{
    public static IServiceCollection AddingAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextIdentityInjector(configuration);

        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddErrorDescriber<TraduzirMensagensIdentityParaPortugues>()
            .AddDefaultTokenProviders();

        var appSettingsSection = configuration.GetSection("Identity");
        services.Configure<Identity>(appSettingsSection);

        var identitySettings = appSettingsSection.Get<Identity>();
        var key = Encoding.ASCII.GetBytes(identitySettings.Secret);

        services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(auth =>
        {
            auth.RequireHttpsMetadata = false;
            auth.SaveToken = true;
            auth.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = identitySettings.ValidoEm,
                ValidIssuer = identitySettings.Emissor
            };
        });

        return services;
    }
}