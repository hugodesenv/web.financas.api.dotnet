using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace api.aspnetcore.webfinancas.Infrastructure.Configuration
{
    public static class AuthConfiguration
    {
        public static IServiceCollection JWTConfiguration(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "Hugo Souza",
                    ValidAudience = "Audience HG",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("My_Random_k3y_here_by_hugoSouza.2025"))
                };
            });

            return services;
        }
    }
}
