using api.aspnetcore.webfinancas.Application.UseCase.Account;
using api.aspnetcore.webfinancas.Domain.Interface;
using api.aspnetcore.webfinancas.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace api.aspnetcore.webfinancas.Infrastructure.Extension
{
    public static class AccountExtension
    {
        public static IServiceCollection AccountExtensionDeclaration(this IServiceCollection services)
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

            // Injections
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IGenerateTokenUseCase, GenerateTokenUseCase>();
            services.AddScoped<IAuthenticationUseCase, AuthenticationUseCase>();

            return services;
        }
    }
}
