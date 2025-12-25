namespace Sims4ModConstructor.Models;

public class Trait
{
    public string Name { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public string Description { get; set; } = "";
    public TraitCategory Category { get; set; } = TraitCategory.Personality;
    public List<string> ConflictingTraits { get; set; } = new();
}

public enum TraitCategory
{
    Personality,
    Lifestyle,
    Social,
    Hobby,
    Career
}
