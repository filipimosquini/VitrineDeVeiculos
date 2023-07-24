using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Api.Configurations;

public static class AuthenticationSetup
{
    public static IServiceCollection AddingAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var secret = configuration.GetSection("Identity")?["Secret"];
        var key = Encoding.ASCII.GetBytes(secret);

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
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        return services;
    }
}