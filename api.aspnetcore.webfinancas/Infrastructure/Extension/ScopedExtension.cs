using api.aspnetcore.webfinancas.Application.UseCase.Account;
using api.aspnetcore.webfinancas.Application.UseCase.Purpose;
using api.aspnetcore.webfinancas.Infrastructure.Interface;
using api.aspnetcore.webfinancas.Infrastructure.Repository;

namespace api.aspnetcore.webfinancas.Infrastructure.Extension
{
    public static class ScopedExtension
    {
        public static IServiceCollection ScopedDeclarationExtension(this IServiceCollection services)
        {
            // Injections
            services.AddScoped<IAccountRepository, AccountRepository>()
                .AddScoped<IGenerateTokenUseCase, GenerateTokenUseCase>()
                .AddScoped<IAuthenticationUseCase, AuthenticationUseCase>()
                .AddScoped<IPurposeRepository, PurposeRepository>()
                .AddScoped<IPersonRepository, PersonRepository>()
                .AddScoped<IPurposeFindAllUseCase, PurposeFindAllUseCase>()
                .AddScoped<IPurposeFindByID, PurposeFindByID>();
            
            return services;
        }
    }
}
