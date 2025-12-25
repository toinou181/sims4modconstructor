using Sims4ModConstructor.Models;
using Sims4ModConstructor.Services;

namespace Sims4ModConstructor;

public partial class MainForm : Form
{
    private readonly ProjectService _projectService = new();
    
    public MainForm()
    {
        InitializeComponent();
        LoadProjectToUI();
    }
    
    private void LoadProjectToUI()
    {
        var project = _projectService.CurrentProject;
        txtProjectName.Text = project.ProjectName;
        txtAuthor.Text = project.Author;
        txtVersion.Text = project.Version;
        txtDescription.Text = project.Description;
        cmbModType.SelectedIndex = (int)project.ModType;
        
        RefreshInteractionsList();
        RefreshBuffsList();
        RefreshTraitsList();
    }
    
    private void RefreshInteractionsList()
    {
        lstInteractions.Items.Clear();
        foreach (var interaction in _projectService.CurrentProject.Interactions)
        {
            lstInteractions.Items.Add($"{interaction.DisplayName} ({interaction.Name})");
        }
    }
    
    private void RefreshBuffsList()
    {
        lstBuffs.Items.Clear();
        foreach (var buff in _projectService.CurrentProject.Buffs)
        {
            lstBuffs.Items.Add($"{buff.DisplayName} ({buff.Name})");
        }
    }
    
    private void RefreshTraitsList()
    {
        lstTraits.Items.Clear();
        foreach (var trait in _projectService.CurrentProject.Traits)
        {
            lstTraits.Items.Add($"{trait.DisplayName} ({trait.Name})");
        }
    }
    
    // Menu handlers
    private void MenuNewProject_Click(object? sender, EventArgs e)
    {
        if (MessageBox.Show("Create a new project? Unsaved changes will be lost.", "New Project", 
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            _projectService.NewProject();
            LoadProjectToUI();
        }
    }
    
    private void MenuOpenProject_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Filter = "Sims 4 Mod Project (*.s4mp)|*.s4mp|All Files (*.*)|*.*",
            Title = "Open Project"
        };
        
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                _projectService.LoadProject(dialog.FileName);
                LoadProjectToUI();
                MessageBox.Show("Project loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading project: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
    private void MenuSaveProject_Click(object? sender, EventArgs e)
    {
        SaveProjectToModel();
        
        using var dialog = new SaveFileDialog
        {
            Filter = "Sims 4 Mod Project (*.s4mp)|*.s4mp|All Files (*.*)|*.*",
            Title = "Save Project",
            DefaultExt = "s4mp"
        };
        
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                _projectService.SaveProject(dialog.FileName);
                MessageBox.Show("Project saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving project: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
    private void MenuExportMod_Click(object? sender, EventArgs e)
    {
        SaveProjectToModel();
        
        using var dialog = new FolderBrowserDialog
        {
            Description = "Select folder to export mod files"
        };
        
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                _projectService.ExportMod(dialog.SelectedPath);
                MessageBox.Show($"Mod exported successfully to:\n{dialog.SelectedPath}", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting mod: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
    private void MenuExit_Click(object? sender, EventArgs e)
    {
        Close();
    }
    
    private void SaveProjectToModel()
    {
        var project = _projectService.CurrentProject;
        project.ProjectName = txtProjectName.Text;
        project.Author = txtAuthor.Text;
        project.Version = txtVersion.Text;
        project.Description = txtDescription.Text;
        project.ModType = (ModType)cmbModType.SelectedIndex;
    }
    
    // Interaction handlers
    private void BtnAddInteraction_Click(object? sender, EventArgs e)
    {
        using var dialog = new InteractionDialog();
        if (dialog.ShowDialog() == DialogResult.OK && dialog.Interaction != null)
        {
            _projectService.CurrentProject.Interactions.Add(dialog.Interaction);
            RefreshInteractionsList();
        }
    }
    
    private void BtnEditInteraction_Click(object? sender, EventArgs e)
    {
        if (lstInteractions.SelectedIndex >= 0)
        {
            var interaction = _projectService.CurrentProject.Interactions[lstInteractions.SelectedIndex];
            using var dialog = new InteractionDialog(interaction);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                RefreshInteractionsList();
            }
        }
    }
    
    private void BtnDeleteInteraction_Click(object? sender, EventArgs e)
    {
        if (lstInteractions.SelectedIndex >= 0)
        {
            if (MessageBox.Show("Delete this interaction?", "Confirm", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _projectService.CurrentProject.Interactions.RemoveAt(lstInteractions.SelectedIndex);
                RefreshInteractionsList();
            }
        }
    }
    
    // Buff handlers
    private void BtnAddBuff_Click(object? sender, EventArgs e)
    {
        using var dialog = new BuffDialog();
        if (dialog.ShowDialog() == DialogResult.OK && dialog.Buff != null)
        {
            _projectService.CurrentProject.Buffs.Add(dialog.Buff);
            RefreshBuffsList();
        }
    }
    
    private void BtnEditBuff_Click(object? sender, EventArgs e)
    {
        if (lstBuffs.SelectedIndex >= 0)
        {
            var buff = _projectService.CurrentProject.Buffs[lstBuffs.SelectedIndex];
            using var dialog = new BuffDialog(buff);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                RefreshBuffsList();
            }
        }
    }
    
    private void BtnDeleteBuff_Click(object? sender, EventArgs e)
    {
        if (lstBuffs.SelectedIndex >= 0)
        {
            if (MessageBox.Show("Delete this buff?", "Confirm", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _projectService.CurrentProject.Buffs.RemoveAt(lstBuffs.SelectedIndex);
                RefreshBuffsList();
            }
        }
    }
    
    // Trait handlers
    private void BtnAddTrait_Click(object? sender, EventArgs e)
    {
        using var dialog = new TraitDialog();
        if (dialog.ShowDialog() == DialogResult.OK && dialog.Trait != null)
        {
            _projectService.CurrentProject.Traits.Add(dialog.Trait);
            RefreshTraitsList();
        }
    }
    
    private void BtnEditTrait_Click(object? sender, EventArgs e)
    {
        if (lstTraits.SelectedIndex >= 0)
        {
            var trait = _projectService.CurrentProject.Traits[lstTraits.SelectedIndex];
            using var dialog = new TraitDialog(trait);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                RefreshTraitsList();
            }
        }
    }
    
    private void BtnDeleteTrait_Click(object? sender, EventArgs e)
    {
        if (lstTraits.SelectedIndex >= 0)
        {
            if (MessageBox.Show("Delete this trait?", "Confirm", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _projectService.CurrentProject.Traits.RemoveAt(lstTraits.SelectedIndex);
                RefreshTraitsList();
            }
        }
    }
}
