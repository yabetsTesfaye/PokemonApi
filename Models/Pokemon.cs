namespace PokemonApi.Models;

public class Pokemon
{
    public string Id { get; set; } // MongoDB ObjectId
    public string Name { get; set; }
    public string Type { get; set; }
    public string Ability { get; set; }
    public int Level { get; set; }
}
