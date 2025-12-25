using System.Text;
using Sims4ModConstructor.Models;

namespace Sims4ModConstructor.Generators;

public class PythonGenerator
{
    public string GenerateInteractionPython(Interaction interaction, ModProject project)
    {
        var sb = new StringBuilder();
        
        sb.AppendLine("import sims4.commands");
        sb.AppendLine("from interactions import ParticipantType");
        sb.AppendLine("from event_testing.results import TestResult");
        sb.AppendLine("from sims4.localization import LocalizationHelperTuning");
        sb.AppendLine("from interactions.base.immediate_interaction import ImmediateSuperInteraction");
        sb.AppendLine();
        
        sb.AppendLine($"class {interaction.Name}(ImmediateSuperInteraction):");
        sb.AppendLine($"    \"\"\"");
        sb.AppendLine($"    {interaction.Description}");
        sb.AppendLine($"    Display Name: {interaction.DisplayName}");
        sb.AppendLine($"    \"\"\"");
        sb.AppendLine();
        
        sb.AppendLine("    def _run_interaction_gen(self, timeline):");
        sb.AppendLine("        # Interaction logic here");
        sb.AppendLine("        target = self.target");
        sb.AppendLine("        sim = self.sim");
        sb.AppendLine();
        
        if (interaction.BuffsToApply.Any())
        {
            sb.AppendLine("        # Apply buffs");
            foreach (var buff in interaction.BuffsToApply)
            {
                sb.AppendLine($"        # Apply buff: {buff}");
                sb.AppendLine($"        # sim.add_buff('{buff}')");
            }
            sb.AppendLine();
        }
        
        sb.AppendLine("        return True");
        sb.AppendLine();
        
        sb.AppendLine("    @classmethod");
        sb.AppendLine("    def _test(cls, target, context, **kwargs):");
        sb.AppendLine("        # Test if interaction is available");
        sb.AppendLine("        return TestResult.TRUE");
        
        return sb.ToString();
    }
    
    public string GenerateBuffPython(Buff buff)
    {
        var sb = new StringBuilder();
        
        sb.AppendLine("import sims4.commands");
        sb.AppendLine("from buffs.buff import Buff");
        sb.AppendLine("from sims4.tuning.tunable import TunableRange");
        sb.AppendLine();
        
        sb.AppendLine($"class {buff.Name}(Buff):");
        sb.AppendLine($"    \"\"\"");
        sb.AppendLine($"    {buff.Description}");
        sb.AppendLine($"    Display Name: {buff.DisplayName}");
        sb.AppendLine($"    Mood: {buff.MoodType}");
        sb.AppendLine($"    \"\"\"");
        sb.AppendLine();
        
        sb.AppendLine("    INSTANCE_TUNABLES = {");
        sb.AppendLine($"        'mood_type': '{buff.MoodType.ToString().ToLower()}',");
        sb.AppendLine($"        'mood_weight': {buff.MoodWeight},");
        sb.AppendLine($"        'buff_duration': {buff.Duration},");
        sb.AppendLine($"        'visible': {buff.IsVisible.ToString().ToLower()}");
        sb.AppendLine("    }");
        sb.AppendLine();
        
        sb.AppendLine("    def _on_add(self, *args, **kwargs):");
        sb.AppendLine("        # Called when buff is added");
        sb.AppendLine("        super()._on_add(*args, **kwargs)");
        sb.AppendLine();
        
        sb.AppendLine("    def _on_remove(self, *args, **kwargs):");
        sb.AppendLine("        # Called when buff is removed");
        sb.AppendLine("        super()._on_remove(*args, **kwargs)");
        
        return sb.ToString();
    }
    
    public string GenerateTraitPython(Trait trait)
    {
        var sb = new StringBuilder();
        
        sb.AppendLine("import sims4.commands");
        sb.AppendLine("from traits.traits import Trait");
        sb.AppendLine();
        
        sb.AppendLine($"class {trait.Name}(Trait):");
        sb.AppendLine($"    \"\"\"");
        sb.AppendLine($"    {trait.Description}");
        sb.AppendLine($"    Display Name: {trait.DisplayName}");
        sb.AppendLine($"    Category: {trait.Category}");
        sb.AppendLine($"    \"\"\"");
        sb.AppendLine();
        
        if (trait.ConflictingTraits.Any())
        {
            sb.AppendLine("    # Conflicting traits:");
            foreach (var conflictingTrait in trait.ConflictingTraits)
            {
                sb.AppendLine($"    # - {conflictingTrait}");
            }
            sb.AppendLine();
        }
        
        sb.AppendLine("    def _on_add(self, *args, **kwargs):");
        sb.AppendLine("        # Called when trait is added to sim");
        sb.AppendLine("        super()._on_add(*args, **kwargs)");
        sb.AppendLine();
        
        sb.AppendLine("    def _on_remove(self, *args, **kwargs):");
        sb.AppendLine("        # Called when trait is removed from sim");
        sb.AppendLine("        super()._on_remove(*args, **kwargs)");
        
        return sb.ToString();
    }
    
    public string GenerateMainScript(ModProject project)
    {
        var sb = new StringBuilder();
        
        sb.AppendLine("# Sims 4 Mod: " + project.ProjectName);
        sb.AppendLine("# Author: " + project.Author);
        sb.AppendLine("# Version: " + project.Version);
        sb.AppendLine("# Description: " + project.Description);
        sb.AppendLine();
        sb.AppendLine("import sims4.commands");
        sb.AppendLine();
        sb.AppendLine("# Import all interactions, buffs, and traits");
        sb.AppendLine("# Add your imports here");
        sb.AppendLine();
        sb.AppendLine("@sims4.commands.Command('mod_info', command_type=sims4.commands.CommandType.Live)");
        sb.AppendLine("def show_mod_info(_connection=None):");
        sb.AppendLine($"    sims4.commands.output(f'Mod: {project.ProjectName}', _connection)");
        sb.AppendLine($"    sims4.commands.output(f'Author: {project.Author}', _connection)");
        sb.AppendLine($"    sims4.commands.output(f'Version: {project.Version}', _connection)");
        sb.AppendLine("    return True");
        
        return sb.ToString();
    }
}
