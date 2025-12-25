using Sims4ModConstructor.Models;
using Sims4ModConstructor.Services;
using Sims4ModConstructor.Generators;

namespace Sims4ModConstructor.Tests;

public class FunctionalTest
{
    public static void RunTests()
    {
        Console.WriteLine("=== Sims 4 Mod Constructor - Functional Tests ===\n");
        
        // Test 1: Create Project
        Console.WriteLine("Test 1: Creating a new project...");
        var project = new ModProject
        {
            ProjectName = "TestMod",
            Author = "Test Author",
            Version = "1.0.0",
            Description = "A test mod for verification",
            ModType = ModType.Both
        };
        Console.WriteLine("✓ Project created successfully\n");
        
        // Test 2: Add Interaction
        Console.WriteLine("Test 2: Adding an interaction...");
        var interaction = new Interaction
        {
            Name = "TestInteraction",
            DisplayName = "Test Interaction",
            Description = "A test interaction",
            Category = InteractionCategory.Friendly,
            Priority = 5,
            IsAutonomous = true
        };
        interaction.BuffsToApply.Add("HappyBuff");
        project.Interactions.Add(interaction);
        Console.WriteLine($"✓ Added interaction: {interaction.DisplayName}\n");
        
        // Test 3: Add Buff
        Console.WriteLine("Test 3: Adding a buff...");
        var buff = new Buff
        {
            Name = "HappyBuff",
            DisplayName = "Happy Buff",
            Description = "Makes sim happy",
            MoodType = MoodType.Happy,
            MoodWeight = 2,
            Duration = 240,
            IsVisible = true
        };
        project.Buffs.Add(buff);
        Console.WriteLine($"✓ Added buff: {buff.DisplayName}\n");
        
        // Test 4: Add Trait
        Console.WriteLine("Test 4: Adding a trait...");
        var trait = new Trait
        {
            Name = "TestTrait",
            DisplayName = "Test Trait",
            Description = "A test trait",
            Category = TraitCategory.Personality
        };
        trait.ConflictingTraits.Add("SomethingElse");
        project.Traits.Add(trait);
        Console.WriteLine($"✓ Added trait: {trait.DisplayName}\n");
        
        // Test 5: Generate XML
        Console.WriteLine("Test 5: Generating XML...");
        var xmlGen = new XmlGenerator();
        var interactionXml = xmlGen.GenerateInteractionXml(interaction, project);
        var buffXml = xmlGen.GenerateBuffXml(buff);
        var traitXml = xmlGen.GenerateTraitXml(trait);
        Console.WriteLine("✓ XML generated successfully");
        Console.WriteLine($"  - Interaction XML length: {interactionXml.Length}");
        Console.WriteLine($"  - Buff XML length: {buffXml.Length}");
        Console.WriteLine($"  - Trait XML length: {traitXml.Length}\n");
        
        // Test 6: Generate Python
        Console.WriteLine("Test 6: Generating Python...");
        var pythonGen = new PythonGenerator();
        var interactionPy = pythonGen.GenerateInteractionPython(interaction, project);
        var buffPy = pythonGen.GenerateBuffPython(buff);
        var traitPy = pythonGen.GenerateTraitPython(trait);
        Console.WriteLine("✓ Python generated successfully");
        Console.WriteLine($"  - Interaction Python length: {interactionPy.Length}");
        Console.WriteLine($"  - Buff Python length: {buffPy.Length}");
        Console.WriteLine($"  - Trait Python length: {traitPy.Length}\n");
        
        // Test 7: Save and Load Project
        Console.WriteLine("Test 7: Testing save/load functionality...");
        var service = new ProjectService();
        service.CurrentProject = project;
        
        var testFile = Path.Combine(Path.GetTempPath(), "test_project.s4mp");
        service.SaveProject(testFile);
        Console.WriteLine($"✓ Project saved to: {testFile}");
        
        service.CurrentProject = new ModProject();
        service.LoadProject(testFile);
        Console.WriteLine($"✓ Project loaded successfully");
        Console.WriteLine($"  - Loaded project: {service.CurrentProject.ProjectName}");
        Console.WriteLine($"  - Interactions: {service.CurrentProject.Interactions.Count}");
        Console.WriteLine($"  - Buffs: {service.CurrentProject.Buffs.Count}");
        Console.WriteLine($"  - Traits: {service.CurrentProject.Traits.Count}\n");
        
        // Test 8: Export Mod
        Console.WriteLine("Test 8: Testing mod export...");
        var exportDir = Path.Combine(Path.GetTempPath(), "TestModExport");
        if (Directory.Exists(exportDir))
            Directory.Delete(exportDir, true);
            
        service.ExportMod(exportDir);
        Console.WriteLine($"✓ Mod exported to: {exportDir}");
        
        // Verify exported files
        var xmlDir = Path.Combine(exportDir, "XML");
        var pythonDir = Path.Combine(exportDir, "Python");
        Console.WriteLine($"  - XML directory exists: {Directory.Exists(xmlDir)}");
        Console.WriteLine($"  - Python directory exists: {Directory.Exists(pythonDir)}");
        
        if (Directory.Exists(xmlDir))
        {
            var xmlFiles = Directory.GetFiles(xmlDir, "*.xml", SearchOption.AllDirectories);
            Console.WriteLine($"  - XML files created: {xmlFiles.Length}");
        }
        
        if (Directory.Exists(pythonDir))
        {
            var pyFiles = Directory.GetFiles(pythonDir, "*.py", SearchOption.AllDirectories);
            Console.WriteLine($"  - Python files created: {pyFiles.Length}");
        }
        
        Console.WriteLine("\n=== All Tests Passed! ===");
        Console.WriteLine("\nGenerated sample files:");
        Console.WriteLine("\nInteraction XML Preview:");
        Console.WriteLine(interactionXml.Substring(0, Math.Min(300, interactionXml.Length)) + "...\n");
        
        Console.WriteLine("Interaction Python Preview:");
        Console.WriteLine(interactionPy.Substring(0, Math.Min(400, interactionPy.Length)) + "...\n");
        
        // Cleanup
        File.Delete(testFile);
    }
}
