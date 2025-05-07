using api.aspnetcore.webfinancas.Domain.Model;
using api.aspnetcore.webfinancas.Infrastructure.Extension;
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

WebApplication app = builder.Build();

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
