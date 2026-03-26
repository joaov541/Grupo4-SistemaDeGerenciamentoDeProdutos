using GerenciamentoDeProdutos.WebAPI.BdContextLoja;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LojaContext>(optionsAction =>
{
    optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

app.UseAuthorization();

app.MapControllers();

app.Run();
