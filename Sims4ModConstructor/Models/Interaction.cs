namespace Sims4ModConstructor.Models;

public class Interaction
{
    public string Name { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public string Description { get; set; } = "";
    public InteractionCategory Category { get; set; } = InteractionCategory.Social;
    public int Priority { get; set; } = 1;
    public bool IsAutonomous { get; set; } = false;
    public List<string> BuffsToApply { get; set; } = new();
}

public enum InteractionCategory
{
    Social,
    Friendly,
    Funny,
    Mean,
    Mischief,
    Romance,
    Special
}
