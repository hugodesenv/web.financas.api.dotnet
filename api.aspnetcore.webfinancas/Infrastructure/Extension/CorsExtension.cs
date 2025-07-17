namespace api.aspnetcore.webfinancas.Infrastructure.Extension
{
    public static class CorsExtension
    {
        public static IServiceCollection CorsInitializationExtension(this IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(["http://localhost:3000", "http://127.0.0.1:3000", "http://localhost:3001", "http://127.0.0.1:3001"])
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            services.AddControllers();

            return services;
        }
    }
}
