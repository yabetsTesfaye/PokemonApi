using Microsoft.AspNetCore.Mvc;
using PokemonApi.Models;
using PokemonApi.Services;

namespace PokemonApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    private readonly IPokemonService _pokemonService;

    public PokemonController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Pokemon>>> Get() =>
        await _pokemonService.GetAsync();

    [HttpGet("type/{type}")]
    public async Task<IActionResult> GetByType(string type)
    {
        var pokemons = await _pokemonService.GetByTypeAsync(type);
        if (pokemons == null || !pokemons.Any())
        {
            return NotFound(new { Message = $"No Pokémon found with type '{type}'." });
        }
        return Ok(pokemons);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pokemon>> GetById(string id)
    {
        var pokemon = await _pokemonService.GetByIdAsync(id);

        if (pokemon is null)
            return NotFound();

        return pokemon;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Pokemon newPokemon)
    {
        await _pokemonService.CreateAsync(newPokemon);
        return CreatedAtAction(nameof(GetById), new { id = newPokemon.Id }, newPokemon);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Pokemon updatedPokemon)
    {
        var pokemon = await _pokemonService.GetByIdAsync(id);

        if (pokemon is null)
            return NotFound();

        updatedPokemon.Id = pokemon.Id;
        await _pokemonService.UpdateAsync(id, updatedPokemon);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var pokemon = await _pokemonService.GetByIdAsync(id);

        if (pokemon is null)
            return NotFound();

        await _pokemonService.RemoveAsync(id);

        return NoContent();
    }
}
