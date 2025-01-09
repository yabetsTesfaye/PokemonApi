using PokemonApi.Models;

namespace PokemonApi.Services;

public interface IPokemonService
{
    Task<List<Pokemon>> GetAsync();
    Task<List<Pokemon>> GetByTypeAsync(string type);
    Task<Pokemon?> GetByIdAsync(string id);
    Task CreateAsync(Pokemon newPokemon);
    Task UpdateAsync(string id, Pokemon updatedPokemon);
    Task RemoveAsync(string id);
}
