using Sims4ModConstructor.Models;

namespace Sims4ModConstructor;

public partial class InteractionDialog : Form
{
    public Interaction? Interaction { get; private set; }
    
    private TextBox txtName = null!;
    private TextBox txtDisplayName = null!;
    private TextBox txtDescription = null!;
    private ComboBox cmbCategory = null!;
    private NumericUpDown numPriority = null!;
    private CheckBox chkAutonomous = null!;
    private ListBox lstBuffs = null!;
    private TextBox txtNewBuff = null!;
    private Button btnAddBuff = null!;
    private Button btnRemoveBuff = null!;
    
    public InteractionDialog(Interaction? interaction = null)
    {
        InitializeComponent();
        
        if (interaction != null)
        {
            Interaction = interaction;
            LoadInteraction();
        }
        else
        {
            Interaction = new Interaction();
        }
    }
    
    private void LoadInteraction()
    {
        if (Interaction == null) return;
        
        txtName.Text = Interaction.Name;
        txtDisplayName.Text = Interaction.DisplayName;
        txtDescription.Text = Interaction.Description;
        cmbCategory.SelectedIndex = (int)Interaction.Category;
        numPriority.Value = Interaction.Priority;
        chkAutonomous.Checked = Interaction.IsAutonomous;
        
        lstBuffs.Items.Clear();
        foreach (var buff in Interaction.BuffsToApply)
        {
            lstBuffs.Items.Add(buff);
        }
    }
    
    private void BtnOK_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBox.Show("Name is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        if (Interaction != null)
        {
            Interaction.Name = txtName.Text;
            Interaction.DisplayName = txtDisplayName.Text;
            Interaction.Description = txtDescription.Text;
            Interaction.Category = (InteractionCategory)cmbCategory.SelectedIndex;
            Interaction.Priority = (int)numPriority.Value;
            Interaction.IsAutonomous = chkAutonomous.Checked;
            
            Interaction.BuffsToApply.Clear();
            foreach (var item in lstBuffs.Items)
            {
                if (item != null)
                {
                    var buffName = item.ToString();
                    if (buffName != null)
                        Interaction.BuffsToApply.Add(buffName);
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
    
    private void BtnAddBuff_Click(object? sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtNewBuff.Text))
        {
            lstBuffs.Items.Add(txtNewBuff.Text);
            txtNewBuff.Clear();
        }
    }
    
    private void BtnRemoveBuff_Click(object? sender, EventArgs e)
    {
        if (lstBuffs.SelectedIndex >= 0)
        {
            lstBuffs.Items.RemoveAt(lstBuffs.SelectedIndex);
        }
    }
    
    private void InitializeComponent()
    {
        this.Text = "Interaction Editor";
        this.Size = new Size(500, 550);
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
        cmbCategory.Items.AddRange(Enum.GetNames(typeof(InteractionCategory)));
        cmbCategory.SelectedIndex = 0;
        
        Label lblPriority = new Label { Text = "Priority:", Location = new Point(20, 180), Width = 120 };
        numPriority = new NumericUpDown { Location = new Point(150, 177), Width = 100, Minimum = 1, Maximum = 100, Value = 1 };
        
        chkAutonomous = new CheckBox { Text = "Is Autonomous", Location = new Point(150, 210), Width = 200 };
        
        Label lblBuffs = new Label { Text = "Buffs to Apply:", Location = new Point(20, 240), Width = 120 };
        lstBuffs = new ListBox { Location = new Point(150, 237), Size = new Size(200, 100) };
        
        txtNewBuff = new TextBox { Location = new Point(150, 345), Width = 200 };
        btnAddBuff = new Button { Text = "Add Buff", Location = new Point(360, 343), Size = new Size(90, 25) };
        btnAddBuff.Click += BtnAddBuff_Click;
        
        btnRemoveBuff = new Button { Text = "Remove", Location = new Point(360, 280), Size = new Size(90, 25) };
        btnRemoveBuff.Click += BtnRemoveBuff_Click;
        
        Button btnOK = new Button { Text = "OK", Location = new Point(250, 450), Size = new Size(100, 35) };
        btnOK.Click += BtnOK_Click;
        
        Button btnCancel = new Button { Text = "Cancel", Location = new Point(360, 450), Size = new Size(100, 35) };
        btnCancel.Click += BtnCancel_Click;
        
        this.Controls.AddRange(new Control[] {
            lblName, txtName,
            lblDisplayName, txtDisplayName,
            lblDescription, txtDescription,
            lblCategory, cmbCategory,
            lblPriority, numPriority,
            chkAutonomous,
            lblBuffs, lstBuffs,
            txtNewBuff, btnAddBuff, btnRemoveBuff,
            btnOK, btnCancel
        });
        
        this.AcceptButton = btnOK;
        this.CancelButton = btnCancel;
    }
}
