using Sims4ModConstructor.Models;

namespace Sims4ModConstructor;

public partial class BuffDialog : Form
{
    public Buff? Buff { get; private set; }
    
    private TextBox txtName = null!;
    private TextBox txtDisplayName = null!;
    private TextBox txtDescription = null!;
    private ComboBox cmbMoodType = null!;
    private NumericUpDown numMoodWeight = null!;
    private NumericUpDown numDuration = null!;
    private CheckBox chkVisible = null!;
    
    public BuffDialog(Buff? buff = null)
    {
        InitializeComponent();
        
        if (buff != null)
        {
            Buff = buff;
            LoadBuff();
        }
        else
        {
            Buff = new Buff();
        }
    }
    
    private void LoadBuff()
    {
        if (Buff == null) return;
        
        txtName.Text = Buff.Name;
        txtDisplayName.Text = Buff.DisplayName;
        txtDescription.Text = Buff.Description;
        cmbMoodType.SelectedIndex = (int)Buff.MoodType;
        numMoodWeight.Value = Buff.MoodWeight;
        numDuration.Value = Buff.Duration;
        chkVisible.Checked = Buff.IsVisible;
    }
    
    private void BtnOK_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBox.Show("Name is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        if (Buff != null)
        {
            Buff.Name = txtName.Text;
            Buff.DisplayName = txtDisplayName.Text;
            Buff.Description = txtDescription.Text;
            Buff.MoodType = (MoodType)cmbMoodType.SelectedIndex;
            Buff.MoodWeight = (int)numMoodWeight.Value;
            Buff.Duration = (int)numDuration.Value;
            Buff.IsVisible = chkVisible.Checked;
        }
        
        DialogResult = DialogResult.OK;
        Close();
    }
    
    private void BtnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
    
    private void InitializeComponent()
    {
        this.Text = "Buff Editor";
        this.Size = new Size(500, 400);
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
        
        Label lblMoodType = new Label { Text = "Mood Type:", Location = new Point(20, 150), Width = 120 };
        cmbMoodType = new ComboBox { Location = new Point(150, 147), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
        cmbMoodType.Items.AddRange(Enum.GetNames(typeof(MoodType)));
        cmbMoodType.SelectedIndex = 0;
        
        Label lblMoodWeight = new Label { Text = "Mood Weight:", Location = new Point(20, 180), Width = 120 };
        numMoodWeight = new NumericUpDown { Location = new Point(150, 177), Width = 100, Minimum = -10, Maximum = 10, Value = 1 };
        
        Label lblDuration = new Label { Text = "Duration (min):", Location = new Point(20, 210), Width = 120 };
        numDuration = new NumericUpDown { Location = new Point(150, 207), Width = 100, Minimum = 1, Maximum = 10000, Value = 240 };
        
        chkVisible = new CheckBox { Text = "Visible in UI", Location = new Point(150, 240), Width = 200, Checked = true };
        
        Button btnOK = new Button { Text = "OK", Location = new Point(250, 300), Size = new Size(100, 35) };
        btnOK.Click += BtnOK_Click;
        
        Button btnCancel = new Button { Text = "Cancel", Location = new Point(360, 300), Size = new Size(100, 35) };
        btnCancel.Click += BtnCancel_Click;
        
        this.Controls.AddRange(new Control[] {
            lblName, txtName,
            lblDisplayName, txtDisplayName,
            lblDescription, txtDescription,
            lblMoodType, cmbMoodType,
            lblMoodWeight, numMoodWeight,
            lblDuration, numDuration,
            chkVisible,
            btnOK, btnCancel
        });
        
        this.AcceptButton = btnOK;
        this.CancelButton = btnCancel;
    }
}
