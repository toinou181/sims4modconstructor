namespace Sims4ModConstructor;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        // Menu
        MenuStrip menuStrip = new MenuStrip();
        ToolStripMenuItem fileMenu = new ToolStripMenuItem("&File");
        ToolStripMenuItem menuNew = new ToolStripMenuItem("&New Project", null, MenuNewProject_Click);
        ToolStripMenuItem menuOpen = new ToolStripMenuItem("&Open Project...", null, MenuOpenProject_Click);
        ToolStripMenuItem menuSave = new ToolStripMenuItem("&Save Project...", null, MenuSaveProject_Click);
        ToolStripMenuItem menuExport = new ToolStripMenuItem("&Export Mod...", null, MenuExportMod_Click);
        ToolStripMenuItem menuExit = new ToolStripMenuItem("E&xit", null, MenuExit_Click);
        
        fileMenu.DropDownItems.Add(menuNew);
        fileMenu.DropDownItems.Add(menuOpen);
        fileMenu.DropDownItems.Add(menuSave);
        fileMenu.DropDownItems.Add(new ToolStripSeparator());
        fileMenu.DropDownItems.Add(menuExport);
        fileMenu.DropDownItems.Add(new ToolStripSeparator());
        fileMenu.DropDownItems.Add(menuExit);
        
        menuStrip.Items.Add(fileMenu);
        
        // Main container
        TabControl tabControl = new TabControl();
        tabControl.Dock = DockStyle.Fill;
        
        // Project Info Tab
        TabPage tabProject = new TabPage("Project Info");
        GroupBox grpProject = new GroupBox { Text = "Project Settings", Dock = DockStyle.Fill, Padding = new Padding(10) };
        
        Label lblProjectName = new Label { Text = "Project Name:", Location = new Point(20, 30), Width = 100 };
        txtProjectName = new TextBox { Location = new Point(130, 27), Width = 300 };
        
        Label lblAuthor = new Label { Text = "Author:", Location = new Point(20, 60), Width = 100 };
        txtAuthor = new TextBox { Location = new Point(130, 57), Width = 300 };
        
        Label lblVersion = new Label { Text = "Version:", Location = new Point(20, 90), Width = 100 };
        txtVersion = new TextBox { Location = new Point(130, 87), Width = 150, Text = "1.0.0" };
        
        Label lblModType = new Label { Text = "Mod Type:", Location = new Point(20, 120), Width = 100 };
        cmbModType = new ComboBox { Location = new Point(130, 117), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
        cmbModType.Items.AddRange(new object[] { "XML", "Python", "Both" });
        cmbModType.SelectedIndex = 0;
        
        Label lblDescription = new Label { Text = "Description:", Location = new Point(20, 150), Width = 100 };
        txtDescription = new TextBox { Location = new Point(130, 147), Width = 300, Height = 100, Multiline = true, ScrollBars = ScrollBars.Vertical };
        
        grpProject.Controls.AddRange(new Control[] { lblProjectName, txtProjectName, lblAuthor, txtAuthor, lblVersion, txtVersion, lblModType, cmbModType, lblDescription, txtDescription });
        tabProject.Controls.Add(grpProject);
        
        // Interactions Tab
        TabPage tabInteractions = new TabPage("Interactions");
        GroupBox grpInteractions = new GroupBox { Text = "Interactions", Dock = DockStyle.Fill, Padding = new Padding(10) };
        
        lstInteractions = new ListBox { Location = new Point(20, 30), Size = new Size(500, 300) };
        
        btnAddInteraction = new Button { Text = "Add", Location = new Point(540, 30), Size = new Size(100, 30) };
        btnAddInteraction.Click += BtnAddInteraction_Click;
        
        btnEditInteraction = new Button { Text = "Edit", Location = new Point(540, 70), Size = new Size(100, 30) };
        btnEditInteraction.Click += BtnEditInteraction_Click;
        
        btnDeleteInteraction = new Button { Text = "Delete", Location = new Point(540, 110), Size = new Size(100, 30) };
        btnDeleteInteraction.Click += BtnDeleteInteraction_Click;
        
        grpInteractions.Controls.AddRange(new Control[] { lstInteractions, btnAddInteraction, btnEditInteraction, btnDeleteInteraction });
        tabInteractions.Controls.Add(grpInteractions);
        
        // Buffs Tab
        TabPage tabBuffs = new TabPage("Buffs");
        GroupBox grpBuffs = new GroupBox { Text = "Buffs", Dock = DockStyle.Fill, Padding = new Padding(10) };
        
        lstBuffs = new ListBox { Location = new Point(20, 30), Size = new Size(500, 300) };
        
        btnAddBuff = new Button { Text = "Add", Location = new Point(540, 30), Size = new Size(100, 30) };
        btnAddBuff.Click += BtnAddBuff_Click;
        
        btnEditBuff = new Button { Text = "Edit", Location = new Point(540, 70), Size = new Size(100, 30) };
        btnEditBuff.Click += BtnEditBuff_Click;
        
        btnDeleteBuff = new Button { Text = "Delete", Location = new Point(540, 110), Size = new Size(100, 30) };
        btnDeleteBuff.Click += BtnDeleteBuff_Click;
        
        grpBuffs.Controls.AddRange(new Control[] { lstBuffs, btnAddBuff, btnEditBuff, btnDeleteBuff });
        tabBuffs.Controls.Add(grpBuffs);
        
        // Traits Tab
        TabPage tabTraits = new TabPage("Traits");
        GroupBox grpTraits = new GroupBox { Text = "Traits", Dock = DockStyle.Fill, Padding = new Padding(10) };
        
        lstTraits = new ListBox { Location = new Point(20, 30), Size = new Size(500, 300) };
        
        btnAddTrait = new Button { Text = "Add", Location = new Point(540, 30), Size = new Size(100, 30) };
        btnAddTrait.Click += BtnAddTrait_Click;
        
        btnEditTrait = new Button { Text = "Edit", Location = new Point(540, 70), Size = new Size(100, 30) };
        btnEditTrait.Click += BtnEditTrait_Click;
        
        btnDeleteTrait = new Button { Text = "Delete", Location = new Point(540, 110), Size = new Size(100, 30) };
        btnDeleteTrait.Click += BtnDeleteTrait_Click;
        
        grpTraits.Controls.AddRange(new Control[] { lstTraits, btnAddTrait, btnEditTrait, btnDeleteTrait });
        tabTraits.Controls.Add(grpTraits);
        
        // Add tabs to tab control
        tabControl.TabPages.Add(tabProject);
        tabControl.TabPages.Add(tabInteractions);
        tabControl.TabPages.Add(tabBuffs);
        tabControl.TabPages.Add(tabTraits);
        
        // Form settings
        this.MainMenuStrip = menuStrip;
        this.Controls.Add(tabControl);
        this.Controls.Add(menuStrip);
        this.ClientSize = new Size(700, 500);
        this.Text = "Sims 4 Mod Constructor";
        this.StartPosition = FormStartPosition.CenterScreen;
    }

    #endregion
    
    private TextBox txtProjectName = null!;
    private TextBox txtAuthor = null!;
    private TextBox txtVersion = null!;
    private TextBox txtDescription = null!;
    private ComboBox cmbModType = null!;
    
    private ListBox lstInteractions = null!;
    private Button btnAddInteraction = null!;
    private Button btnEditInteraction = null!;
    private Button btnDeleteInteraction = null!;
    
    private ListBox lstBuffs = null!;
    private Button btnAddBuff = null!;
    private Button btnEditBuff = null!;
    private Button btnDeleteBuff = null!;
    
    private ListBox lstTraits = null!;
    private Button btnAddTrait = null!;
    private Button btnEditTrait = null!;
    private Button btnDeleteTrait = null!;
}
