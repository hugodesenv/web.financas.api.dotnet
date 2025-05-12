using api.aspnetcore.webfinancas.Application.UseCase.Account;
using api.aspnetcore.webfinancas.Application.UseCase.Person;
using api.aspnetcore.webfinancas.Application.UseCase.Purpose;
using api.aspnetcore.webfinancas.Domain.Repository;
using api.aspnetcore.webfinancas.Infrastructure.Interface;

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
                .AddScoped<IPersonRepository, PersonRepository>()
                .AddScoped<IPurposeRepository, PurposeRepository>()
                .AddScoped<IPurposeFindAllUseCase, PurposeFindAllUseCase>()
                .AddScoped<IPurposeFindByIDUseCase, PurposeFindByID>()
                .AddScoped<IPurposeInsertUseCase, InsertPurposeUseCase>()
                .AddScoped<IFindAllPersonUseCase, FindAllPersonUseCase>()
                .AddScoped<IFindPersonByIDUseCase, FindPersonByIDUseCase>()
                .AddScoped<IInsertPersonUseCase, InsertPersonUseCase>()
                .AddScoped<IDeletePersonUseCase, DeletePersonUseCase>()
                .AddScoped<IUpdatePersonUseCase, UpdatePersonUseCase>();
            
            return services;
        }
    }
}
