using Sims4ModConstructor.Models;

namespace Sims4ModConstructor;

public partial class TraitDialog : Form
{
    public Trait? Trait { get; private set; }
    
    private TextBox txtName = null!;
    private TextBox txtDisplayName = null!;
    private TextBox txtDescription = null!;
    private ComboBox cmbCategory = null!;
    private ListBox lstConflictingTraits = null!;
    private TextBox txtNewTrait = null!;
    private Button btnAddTrait = null!;
    private Button btnRemoveTrait = null!;
    
    public TraitDialog(Trait? trait = null)
    {
        InitializeComponent();
        
        if (trait != null)
        {
            Trait = trait;
            LoadTrait();
        }
        else
        {
            Trait = new Trait();
        }
    }
    
    private void LoadTrait()
    {
        if (Trait == null) return;
        
        txtName.Text = Trait.Name;
        txtDisplayName.Text = Trait.DisplayName;
        txtDescription.Text = Trait.Description;
        cmbCategory.SelectedIndex = (int)Trait.Category;
        
        lstConflictingTraits.Items.Clear();
        foreach (var conflictingTrait in Trait.ConflictingTraits)
        {
            lstConflictingTraits.Items.Add(conflictingTrait);
        }
    }
    
    private void BtnOK_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBox.Show("Name is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        if (Trait != null)
        {
            Trait.Name = txtName.Text;
            Trait.DisplayName = txtDisplayName.Text;
            Trait.Description = txtDescription.Text;
            Trait.Category = (TraitCategory)cmbCategory.SelectedIndex;
            
            Trait.ConflictingTraits.Clear();
            foreach (var item in lstConflictingTraits.Items)
            {
                if (item != null)
                {
                    var traitName = item.ToString();
                    if (traitName != null)
                        Trait.ConflictingTraits.Add(traitName);
                }
            }
        }
        
        DialogResult = DialogResult.OK;
        Close();
    }
    
    private void BtnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
    
    private void BtnAddTrait_Click(object? sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtNewTrait.Text))
        {
            lstConflictingTraits.Items.Add(txtNewTrait.Text);
            txtNewTrait.Clear();
        }
    }
    
    private void BtnRemoveTrait_Click(object? sender, EventArgs e)
    {
        if (lstConflictingTraits.SelectedIndex >= 0)
        {
            lstConflictingTraits.Items.RemoveAt(lstConflictingTraits.SelectedIndex);
        }
    }
    
    private void InitializeComponent()
    {
        this.Text = "Trait Editor";
        this.Size = new Size(500, 450);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        
        Label lblName = new Label { Text = "Name (Internal):", Location = new Point(20, 20), Width = 120 };
        txtName = new TextBox { Location = new Point(150, 17), Width = 300 };
        
        Label lblDisplayName = new Label { Text = "Display Name:", Location = new Point(20, 50), Width = 120 };
        txtDisplayName = new TextBox { Location = new Point(150, 47), Width = 300 };
        
        Label lblDescription = new Label { Text = "Description:", Location = new Point(20, 80), Width = 120 };
        txtDescription = new TextBox { Location = new Point(150, 77), Width = 300, Height = 60, Multiline = true };
        
        Label lblCategory = new Label { Text = "Category:", Location = new Point(20, 150), Width = 120 };
        cmbCategory = new ComboBox { Location = new Point(150, 147), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
        cmbCategory.Items.AddRange(Enum.GetNames(typeof(TraitCategory)));
        cmbCategory.SelectedIndex = 0;
        
        Label lblConflicting = new Label { Text = "Conflicting Traits:", Location = new Point(20, 180), Width = 120 };
        lstConflictingTraits = new ListBox { Location = new Point(150, 177), Size = new Size(200, 100) };
        
        txtNewTrait = new TextBox { Location = new Point(150, 285), Width = 200 };
        btnAddTrait = new Button { Text = "Add", Location = new Point(360, 283), Size = new Size(90, 25) };
        btnAddTrait.Click += BtnAddTrait_Click;
        
        btnRemoveTrait = new Button { Text = "Remove", Location = new Point(360, 220), Size = new Size(90, 25) };
        btnRemoveTrait.Click += BtnRemoveTrait_Click;
        
        Button btnOK = new Button { Text = "OK", Location = new Point(250, 350), Size = new Size(100, 35) };
        btnOK.Click += BtnOK_Click;
        
        Button btnCancel = new Button { Text = "Cancel", Location = new Point(360, 350), Size = new Size(100, 35) };
        btnCancel.Click += BtnCancel_Click;
        
        this.Controls.AddRange(new Control[] {
            lblName, txtName,
            lblDisplayName, txtDisplayName,
            lblDescription, txtDescription,
            lblCategory, cmbCategory,
            lblConflicting, lstConflictingTraits,
            txtNewTrait, btnAddTrait, btnRemoveTrait,
            btnOK, btnCancel
        });
        
        this.AcceptButton = btnOK;
        this.CancelButton = btnCancel;
    }
}
