using MongoDB.Driver;
using PokemonApi.Models;
using PokemonApi.Settings;
using Microsoft.Extensions.Options; 

namespace PokemonApi.Services;

public class PokemonService : IPokemonService
{
    private readonly IMongoCollection<Pokemon> _pokemonCollection;

    public PokemonService(IOptions<PokemonDatabaseSettings> dbSettings)
    {
        var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

        _pokemonCollection = mongoDatabase.GetCollection<Pokemon>(dbSettings.Value.CollectionName);
    }

    public async Task<List<Pokemon>> GetAsync() =>
        await _pokemonCollection.Find(_ => true).ToListAsync();

    public async Task<List<Pokemon>> GetByTypeAsync(string type)=>
         await _pokemonCollection.Find(p => p.Type == type).ToListAsync();

    public async Task<Pokemon?> GetByIdAsync(string id) =>
        await _pokemonCollection.Find(p => p.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Pokemon newPokemon) =>
        await _pokemonCollection.InsertOneAsync(newPokemon);

    public async Task UpdateAsync(string id, Pokemon updatedPokemon) =>
        await _pokemonCollection.ReplaceOneAsync(p => p.Id == id, updatedPokemon);

    public async Task RemoveAsync(string id) =>
        await _pokemonCollection.DeleteOneAsync(p => p.Id == id);
}
