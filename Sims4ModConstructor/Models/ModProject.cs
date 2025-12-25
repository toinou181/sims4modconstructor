namespace Sims4ModConstructor.Models;

public class ModProject
{
    public string ProjectName { get; set; } = "NewMod";
    public string Author { get; set; } = "";
    public string Version { get; set; } = "1.0.0";
    public string Description { get; set; } = "";
    public ModType ModType { get; set; } = ModType.XML;
    
    public List<Interaction> Interactions { get; set; } = new();
    public List<Buff> Buffs { get; set; } = new();
    public List<Trait> Traits { get; set; } = new();
}

public enum ModType
{
    XML,
    Python,
    Both
}
