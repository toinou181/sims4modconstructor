using System.Text.Json;
using Sims4ModConstructor.Models;

namespace Sims4ModConstructor.Services;

public class ProjectService
{
    public ModProject CurrentProject { get; set; } = new();
    
    public void NewProject()
    {
        CurrentProject = new ModProject();
    }
    
    public void SaveProject(string filePath)
    {
        var json = JsonSerializer.Serialize(CurrentProject, new JsonSerializerOptions 
        { 
            WriteIndented = true 
        });
        File.WriteAllText(filePath, json);
    }
    
    public void LoadProject(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var project = JsonSerializer.Deserialize<ModProject>(json);
        if (project != null)
        {
            CurrentProject = project;
        }
    }
    
    public void ExportMod(string outputDirectory)
    {
        Directory.CreateDirectory(outputDirectory);
        
        var xmlGen = new Generators.XmlGenerator();
        var pythonGen = new Generators.PythonGenerator();
        
        // Export based on mod type
        if (CurrentProject.ModType == ModType.XML || CurrentProject.ModType == ModType.Both)
        {
            ExportXmlMod(outputDirectory, xmlGen);
        }
        
        if (CurrentProject.ModType == ModType.Python || CurrentProject.ModType == ModType.Both)
        {
            ExportPythonMod(outputDirectory, pythonGen);
        }
    }
    
    private void ExportXmlMod(string outputDirectory, Generators.XmlGenerator xmlGen)
    {
        var xmlDir = Path.Combine(outputDirectory, "XML");
        Directory.CreateDirectory(xmlDir);
        
        // Export mod info
        File.WriteAllText(
            Path.Combine(xmlDir, "ModInfo.xml"),
            xmlGen.GenerateModInfoXml(CurrentProject)
        );
        
        // Export interactions
        if (CurrentProject.Interactions.Any())
        {
            var interactionsDir = Path.Combine(xmlDir, "Interactions");
            Directory.CreateDirectory(interactionsDir);
            foreach (var interaction in CurrentProject.Interactions)
            {
                File.WriteAllText(
                    Path.Combine(interactionsDir, $"{interaction.Name}.xml"),
                    xmlGen.GenerateInteractionXml(interaction, CurrentProject)
                );
            }
        }
        
        // Export buffs
        if (CurrentProject.Buffs.Any())
        {
            var buffsDir = Path.Combine(xmlDir, "Buffs");
            Directory.CreateDirectory(buffsDir);
            foreach (var buff in CurrentProject.Buffs)
            {
                File.WriteAllText(
                    Path.Combine(buffsDir, $"{buff.Name}.xml"),
                    xmlGen.GenerateBuffXml(buff)
                );
            }
        }
        
        // Export traits
        if (CurrentProject.Traits.Any())
        {
            var traitsDir = Path.Combine(xmlDir, "Traits");
            Directory.CreateDirectory(traitsDir);
            foreach (var trait in CurrentProject.Traits)
            {
                File.WriteAllText(
                    Path.Combine(traitsDir, $"{trait.Name}.xml"),
                    xmlGen.GenerateTraitXml(trait)
                );
            }
        }
    }
    
    private void ExportPythonMod(string outputDirectory, Generators.PythonGenerator pythonGen)
    {
        var pythonDir = Path.Combine(outputDirectory, "Python");
        Directory.CreateDirectory(pythonDir);
        
        // Export main script
        File.WriteAllText(
            Path.Combine(pythonDir, "__init__.py"),
            pythonGen.GenerateMainScript(CurrentProject)
        );
        
        // Export interactions
        if (CurrentProject.Interactions.Any())
        {
            var interactionsDir = Path.Combine(pythonDir, "interactions");
            Directory.CreateDirectory(interactionsDir);
            File.WriteAllText(Path.Combine(interactionsDir, "__init__.py"), "");
            
            foreach (var interaction in CurrentProject.Interactions)
            {
                File.WriteAllText(
                    Path.Combine(interactionsDir, $"{interaction.Name.ToLower()}.py"),
                    pythonGen.GenerateInteractionPython(interaction, CurrentProject)
                );
            }
        }
        
        // Export buffs
        if (CurrentProject.Buffs.Any())
        {
            var buffsDir = Path.Combine(pythonDir, "buffs");
            Directory.CreateDirectory(buffsDir);
            File.WriteAllText(Path.Combine(buffsDir, "__init__.py"), "");
            
            foreach (var buff in CurrentProject.Buffs)
            {
                File.WriteAllText(
                    Path.Combine(buffsDir, $"{buff.Name.ToLower()}.py"),
                    pythonGen.GenerateBuffPython(buff)
                );
            }
        }
        
        // Export traits
        if (CurrentProject.Traits.Any())
        {
            var traitsDir = Path.Combine(pythonDir, "traits");
            Directory.CreateDirectory(traitsDir);
            File.WriteAllText(Path.Combine(traitsDir, "__init__.py"), "");
            
            foreach (var trait in CurrentProject.Traits)
            {
                File.WriteAllText(
                    Path.Combine(traitsDir, $"{trait.Name.ToLower()}.py"),
                    pythonGen.GenerateTraitPython(trait)
                );
            }
        }
        
        // Create README
        var readme = $@"# {CurrentProject.ProjectName}

**Author:** {CurrentProject.Author}
**Version:** {CurrentProject.Version}

{CurrentProject.Description}

## Installation
1. Copy the Python folder contents to a .ts4script file
2. Place the .ts4script file in your Sims 4 Mods folder
3. Enable script mods in game settings

## Contents
- Interactions: {CurrentProject.Interactions.Count}
- Buffs: {CurrentProject.Buffs.Count}
- Traits: {CurrentProject.Traits.Count}
";
        File.WriteAllText(Path.Combine(pythonDir, "README.md"), readme);
    }
}
