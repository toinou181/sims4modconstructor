using System.Text;
using System.Xml.Linq;
using Sims4ModConstructor.Models;

namespace Sims4ModConstructor.Generators;

public class XmlGenerator
{
    public string GenerateInteractionXml(Interaction interaction, ModProject project)
    {
        var doc = new XDocument(
            new XDeclaration("1.0", "utf-8", null),
            new XElement("Interaction",
                new XAttribute("name", interaction.Name),
                new XElement("DisplayName", interaction.DisplayName),
                new XElement("Description", interaction.Description),
                new XElement("Category", interaction.Category.ToString()),
                new XElement("Priority", interaction.Priority),
                new XElement("Autonomous", interaction.IsAutonomous),
                new XElement("Buffs",
                    interaction.BuffsToApply.Select(b => new XElement("Buff", b))
                )
            )
        );
        
        return doc.ToString();
    }
    
    public string GenerateBuffXml(Buff buff)
    {
        var doc = new XDocument(
            new XDeclaration("1.0", "utf-8", null),
            new XElement("Buff",
                new XAttribute("name", buff.Name),
                new XElement("DisplayName", buff.DisplayName),
                new XElement("Description", buff.Description),
                new XElement("MoodType", buff.MoodType.ToString()),
                new XElement("MoodWeight", buff.MoodWeight),
                new XElement("Duration", buff.Duration),
                new XElement("Visible", buff.IsVisible)
            )
        );
        
        return doc.ToString();
    }
    
    public string GenerateTraitXml(Trait trait)
    {
        var doc = new XDocument(
            new XDeclaration("1.0", "utf-8", null),
            new XElement("Trait",
                new XAttribute("name", trait.Name),
                new XElement("DisplayName", trait.DisplayName),
                new XElement("Description", trait.Description),
                new XElement("Category", trait.Category.ToString()),
                new XElement("ConflictingTraits",
                    trait.ConflictingTraits.Select(t => new XElement("Trait", t))
                )
            )
        );
        
        return doc.ToString();
    }
    
    public string GenerateModInfoXml(ModProject project)
    {
        var doc = new XDocument(
            new XDeclaration("1.0", "utf-8", null),
            new XElement("ModInfo",
                new XElement("Name", project.ProjectName),
                new XElement("Author", project.Author),
                new XElement("Version", project.Version),
                new XElement("Description", project.Description),
                new XElement("InteractionCount", project.Interactions.Count),
                new XElement("BuffCount", project.Buffs.Count),
                new XElement("TraitCount", project.Traits.Count)
            )
        );
        
        return doc.ToString();
    }
}
