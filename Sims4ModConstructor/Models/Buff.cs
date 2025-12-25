namespace Sims4ModConstructor.Models;

public class Buff
{
    public string Name { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public string Description { get; set; } = "";
    public MoodType MoodType { get; set; } = MoodType.Happy;
    public int MoodWeight { get; set; } = 1;
    public int Duration { get; set; } = 240; // in sim minutes
    public bool IsVisible { get; set; } = true;
}

public enum MoodType
{
    Happy,
    Sad,
    Angry,
    Playful,
    Flirty,
    Confident,
    Focused,
    Energized,
    Uncomfortable,
    Embarrassed,
    Tense,
    Bored,
    Fine
}
