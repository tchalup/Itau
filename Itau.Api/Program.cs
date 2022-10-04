using Itau.Api.Data;
using Itau.Dados;
using Itau.Dados.Contextos;
using Itau.Dados.Repositorios;
using Itau.Dominio.Interfaces;
using Itau.Dominio.Interfaces.Repositorios;
using Itau.TheCat.Dados.Config;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ItauConnection");
builder.Services.AddDbContext<ItauContexto>(x => x.UseSqlServer(connectionString));

var theCatConfig = new TheCatConfig();
builder.Configuration.GetSection("TheCatAPI").Bind(theCatConfig);
builder.Services.AddSingleton(theCatConfig);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<Itau.TheCat.Dominio.Interfaces.Repositorios.IRacaRepositorio, Itau.TheCat.Dados.Repositorios.RacaRepositorio>();
builder.Services.AddScoped<ItauDBInitializer, ItauDBInitializer>();

builder.Services.AddScoped<IImagemCategoriaRepositorio, ImagemCategoriaRepositorio>();
builder.Services.AddScoped<IOrigemRepositorio, OrigemRepositorio>();
builder.Services.AddScoped<IRacaRepositorio, RacaRepositorio>();
builder.Services.AddScoped<ITemperamentoRepositorio, TemperamentoRepositorio>();

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithMachineName()
    .WriteTo.Debug()
    .WriteTo.Console()
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
    {
        AutoRegisterTemplate = true,
        IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
    })
    .Enrich.WithProperty("Environment", environment)
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

Console.WriteLine($@"ConnectionStrings__ItauConnection: {connectionString}
                     TheCatAPI__URI: {theCatConfig.URI}
                     ElasticConfiguration__Uri: {configuration["ElasticConfiguration:Uri"]}
                     environment: {environment}");


var app = builder.Build();

await SeedData(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static async Task SeedData(WebApplication app)
{
    using var scope = app.Services.CreateScope();

    var dbContext = scope.ServiceProvider.GetRequiredService<ItauContexto>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();

    var itauDBInitializer = scope.ServiceProvider.GetRequiredService<ItauDBInitializer>();
    await itauDBInitializer.Seed();
}