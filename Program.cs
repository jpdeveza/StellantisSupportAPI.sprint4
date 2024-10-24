using Microsoft.EntityFrameworkCore;
using StellantisSupportAPI.Data;
using StellantisSupportAPI.MLModels;

var builder = WebApplication.CreateBuilder(args);

// Adicionar o serviço de recomendação
builder.Services.AddSingleton<ProductRecommender>();

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDbConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Construa o app após configurar todos os serviços
var app = builder.Build();

// Configure o middleware para usar Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stellantis Support API v1");
});

// Adicione o middleware de roteamento e controle
app.UseAuthorization();
app.MapControllers();

app.Run();
