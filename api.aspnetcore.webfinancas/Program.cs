using api.aspnetcore.webfinancas.Domain.Model;
using api.aspnetcore.webfinancas.Infrastructure.Extension;
using api.aspnetcore.webfinancas.Infrastructure.Interface;
using api.aspnetcore.webfinancas.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .CorsInitializationExtension()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AuthConfigExtension()
    .ScopedDeclarationExtension()
    .AddDbContext<DatabaseContext>(options => options.UseNpgsql(
        builder.Configuration.GetConnectionString("DatabaseFinancas"))
);

// Injections
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();
