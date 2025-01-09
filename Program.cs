using PokemonApi.Services;
using PokemonApi.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<PokemonDatabaseSettings>(
    builder.Configuration.GetSection("PokemonDatabaseSettings"));

builder.Services.AddSingleton<IPokemonService, PokemonService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
